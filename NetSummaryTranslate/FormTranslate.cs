using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetCore.zh_hans
{
    public partial class FormTranslate : Form
    {
        public FormTranslate()
        {
            InitializeComponent();
        }
        string exportPath = Environment.CurrentDirectory + "\\" + "zh-hans"; //指定翻译结果文件夹位置

        private Log log;

        private void button_Import_Click(object sender, EventArgs e)
        {
            OpenFileDialog openXml = new OpenFileDialog();
            openXml.Multiselect = true;
            openXml.Filter = "要翻译的文件,可多选|*.xml";
            if (openXml.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            TranslateTask.MaxNumOFConcurrent = int.Parse(this.cbMaxTasks.Text);

            string[] fileNames = openXml.FileNames; //获取文件列表
            progressBar_Translate.Value = 0;//设置当前值
            progressBar_Translate.Step = 1;//设置每次增长多少
            int totalTask = 0;
            for (int i = 0; i < fileNames.Length; i++)
            {
                if (File.Exists(exportPath + "\\" + Path.GetFileName(fileNames[i])))
                {
                    log.Logging(" 信息:" + Path.GetFileName(fileNames[i]) + " 已存在,跳过翻译!");
                    continue;
                }
                totalTask++;
                progressBar_Translate.Maximum = totalTask;//设置进度条最大长度值
                TranslateTask tf = new TranslateTask();
                tf.TranslateFilePath = fileNames[i];
                tf.SaveFilePath = exportPath;
                tf.AppId = this.textBox_appId.Text.Trim();
                tf.SecretKey = this.textBox_secretKey.Text.Trim();
                tf.TransFinish += Tf_TransFinish;
                tf.Loger = log;

                Thread thread_Translate = new Thread(tf.Start);
                thread_Translate.IsBackground = true;
                thread_Translate.Name = "Translate" + tf.TranslateFilePath;
                thread_Translate.Start();
            }
            if (totalTask > 0)
            {
                log.Logging(" 信息:" + " 开始翻译任务...");
            }
            else
            {
                log.Logging(" 信息:" + " 文件全部已翻译,没有需要翻译的任务。");
            }
        }

        private void Tf_TransFinish(object sender, object e)
        {
            TranslateTask translateFile = sender as TranslateTask;
            log.Logging(" 信息:" + translateFile.TranslateFilePath + " 翻译完成!");
            this.Invoke((MethodInvoker)(() =>
            {
                progressBar_Translate.Value += progressBar_Translate.Step;//更新进度条
                if (progressBar_Translate.Maximum == progressBar_Translate.Value)
                {
                    System.Diagnostics.Process.Start("explorer.exe", exportPath);   //翻译全部完成后，自动打开zh_hans文件夹，然后把zh_hans复制到对应的资源文件夹下面即可
                    log.Logging(" 信息: 本次翻译任务全部完成,共翻译文件" + progressBar_Translate.Maximum.ToString() + "个!");
                }
            }));
        }

        private void FormTranslate_Load(object sender, EventArgs e)
        {
            textBox_appId.Text = AppXml.XmlRead("百度APPID");
            textBox_secretKey.Text = AppXml.XmlRead("百度SecretKey");
            if (!Directory.Exists(exportPath))//如果不存在就创建
            {
                DirectoryInfo Gdir = new DirectoryInfo(Environment.CurrentDirectory);
                Gdir.CreateSubdirectory("zh-hans");
            }
            log = new Log(this.txtLog);
        }

        private void FormTranslate_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("确认退出吗?", "退出?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                AppXml.XmlWrite("百度APPID", textBox_appId.Text.Trim());
                AppXml.XmlWrite("百度SecretKey", textBox_secretKey.Text.Trim());
                Dispose();
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void cbMaxTasks_Leave(object sender, EventArgs e)
        {
            try
            {
                int.Parse(this.cbMaxTasks.Text);
            }
            catch (Exception)
            {
                this.cbMaxTasks.Text = "10";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.ShowDialog();
        }
    }
}
