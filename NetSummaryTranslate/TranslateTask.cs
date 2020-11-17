using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace NetCore.zh_hans
{
    class TranslateTask
    {
        /// <summary>
        /// 任务结束事件
        /// </summary>
        public event EventHandler TransFinish;
        /// <summary>
        /// 需要翻译的XML文件路径
        /// </summary>
        public string TranslateFilePath { get; set; }

        public Log Loger { get; set; }

        /// <summary>
        /// 需要保存翻译结果文件路径
        /// </summary>
        public string SaveFilePath { get; set; }

        /// <summary>
        /// 百度翻译AppID
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 百度翻译SecretKey
        /// </summary>
        public string SecretKey { get; set; }

        //多线性翻译,每次同时翻译文件最大并发数
        public static int MaxNumOFConcurrent = 5;
        //当前并发翻译数量合计
        private static int currentTotalNumOFConcurrent = 0;

        /// <summary>
        /// 是否需要再次开启超限通知.
        /// </summary>
        bool NeedOutOFGaugePromptAgain = true;

        public void Start()
        {
            lock (typeof(TranslateTask))
            {
                while (currentTotalNumOFConcurrent >= MaxNumOFConcurrent)
                {
                    if (NeedOutOFGaugePromptAgain)
                    {
                        Loger.Logging(" 信息: 并行任务超过最大数量,最大任务数:" + MaxNumOFConcurrent);
                        NeedOutOFGaugePromptAgain = false;
                    }
                    Thread.Sleep(10);
                }
                currentTotalNumOFConcurrent++;
                Loger.Logging(" 信息: "+ TranslateFilePath + "翻译线程开始,当前线程总数:" + currentTotalNumOFConcurrent);
            }
            //测试,模拟任务
            //Thread.Sleep(new Random().Next(1, 3) * 1000);
            //开始翻译
            TranslateFunc();

            if (TransFinish != null)
            {
                TransFinish(this, null);
            }
            currentTotalNumOFConcurrent--;
            NeedOutOFGaugePromptAgain = true;
            Loger.Logging(" 信息: " + TranslateFilePath + "翻译线程结束");
        }

        private void TranslateFunc()
        {
            #region 翻译
            string ReadXmlList = File.ReadAllText(TranslateFilePath, Encoding.UTF8).Trim(); //读取选定的Xml之一
            MatchCollection MatchVar;
            Regex MatchPic = new Regex("(?<=(" + "<summary>" + "))[.\\s\\S]*?(?=(" + "</summary>" + "))");//筛选标准
            MatchVar = MatchPic.Matches(ReadXmlList);//匹配<summary>中间的英文说明</summary>
            if (MatchVar.Count >= 1)
            {
                List<string> repeatList = new List<string>();//防重复翻译列表
                for (int k = 0; k < MatchVar.Count; k++)
                {
                    if (!repeatList.Contains(MatchVar[k].Value.Trim())) //判断是否已翻译过的字符串
                    {
                        repeatList.Add(MatchVar[k].Value.Trim());//添加到防重复翻译列表
                        string HWC = MatchVar[k].Value.Trim().Replace("\r\n", "");//处理掉字符中间的换行符
                        string okStr = ""; int tryings = 0; bool requesterror = false;
                        while ((tryings == 0) || ((requesterror) && (tryings <= 3)))
                        {
                            try
                            {
                                tryings++;
                                okStr = Translate.TranslateText(HWC, AppId, SecretKey); //执行翻译
                            }
                            catch (Exception err)
                            {
                                requesterror = true;
                                if (tryings == 3)
                                {
                                    Loger.Logging(TranslateFilePath + "  翻译错误:" + HWC + " 错误日志:" + err.Message );
                                }
                            }
                        }

                        if (okStr != null)
                        {
                            okStr = okStr.Replace("\\", "");//移除多余的转义符，否则VS不会正确显示摘要; 这里被%#！坑惨了，翻译了全部AspNetCore文档总共130万字符才发现，阿西吧。。。
                            okStr = okStr.Replace("环境名称。开发", "EnvironmentName.Development"); //同上
                            okStr = okStr.Replace("环境名称。暂存", "EnvironmentName.Staging"); //同上
                            okStr = okStr.Replace("环境名称。生产", "EnvironmentName.Production"); //同上
                            okStr = okStr.Replace("系统。异常", "System.Exception"); //同上
                            okStr = okStr.Replace("“", "\""); //同上
                            okStr = okStr.Replace("”", "\""); //同上
                                                              //至此接近完美了，硬伤是百度翻译词义的准确性，GoogleTranslate很不错，可惜我申请不了接口，要绑定支付方式，尝试过用协议调用https://translate.google.cn/，单位时间内对IP有翻译次数限制，挂代理速度及稳定性又很无奈，先将就下吧。。。
                            ReadXmlList = ReadXmlList.Replace(MatchVar[k].Value, MatchVar[k].Value + " | 百度译文：" + okStr + "\r\n            "); //原文+译文替换原文,后面换行加些空白字符保持格式一致性
                        }
                    }
                }

                string saveFilePath = SaveFilePath + "\\" + Path.GetFileName(TranslateFilePath);//保存翻译后的文档
                StreamWriter swStream;
                if (File.Exists(saveFilePath))
                {
                    swStream = new StreamWriter(saveFilePath, false);
                }
                else
                {
                    swStream = File.CreateText(saveFilePath);
                }

                swStream.Write(ReadXmlList);
                swStream.Flush();
                swStream.Close();
            }
            #endregion
        }
    }
}
