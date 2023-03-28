using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using FileSplitter.Models;
using System.Runtime.Remoting.Channels;
using System.Text.RegularExpressions;

namespace FileSplitter.Controls
{
    public partial class UCSplitByFilter : UserControl
    {

        public static string ByteToString(long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; // suffixes for units
            if (byteCount == 0)
            {
                return "0 " + suf[0];
            }

            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 2);
            return (Math.Sign(byteCount) * num).ToString() + " " + suf[place];
        }

        private SplitByFilterConfig ___config;
        private SplitByFilterConfig initConfig(SplitByFilterConfig config = null)
        {
            if (config == null) config = new SplitByFilterConfig();
            lBytes.Text = ByteToString(config.MaxFileSizeBytes);

            config.PropertyChanged += (s, e) =>
            {
                switch (e.PropertyName)
                {
                    case nameof(SplitByFilterConfig.MaxFileSizeBytes):
                        lBytes.Text = ByteToString((s as SplitByFilterConfig).MaxFileSizeBytes);
                        break;
                }
            };
            return config;
        }
        public SplitByFilterConfig Config
        {
            get { return ___config ?? (___config = initConfig()); }
            set
            {
                ___config = initConfig(value);
                bsConfig.DataSource = ___config;
            }
        }

        private void setTooltip(Control ctrl, string text, string title = "Tip", bool instantShow = false)
        {
            var toolTip = new ToolTip()
            {
                Active = true,
                ToolTipTitle = title,
                ToolTipIcon = ToolTipIcon.Info,
                UseFading = true,
                UseAnimation = true,
                IsBalloon = true,
                ShowAlways = true,
                AutoPopDelay = 5000,
                ReshowDelay = 0,
                InitialDelay = 0,
                BackColor = Color.Red,
                ForeColor = Color.White
            };
            if (instantShow)
            {
                toolTip.Show(text, ctrl, 5000);
            }
            else
            {
                toolTip.SetToolTip(ctrl, text);
            }

        }
        const string EXTENDED_TT = @"Use Special Characters
\t: Horizontal Tab
\r: Carriage Return
\n: Line Feed
\0: ASCII 0
\\: Escape Character";
        const string DELIMITER_TT = @"Special Characters (In Extended Mode)
\t: Horizontal Tab
\r: Carriage Return
\n: Line Feed
\0: ASCII 0
\\: Escape Character";
        public UCSplitByFilter()
        {
            InitializeComponent();
            setTooltip(cbExtended, EXTENDED_TT);
            setTooltip(tDelimiter, DELIMITER_TT);
            //tDelimiter.MouseHover += (s, e) =>
            //{
            //    setTooltip(tDelimiter, DELIMITER_TT, instantShow: true);
            //};
        }

        private string getFilePath(string fileName, string fileExt, int index)
        {
            return $@"{Config.OutputDirectory}\{fileName}_{index.ToString().PadLeft(4, '0')}.{fileExt}";
        }

        private byte[] GetFilter()
        {
            if (Config.IsExtendedSplitterFilter)
            {
                return Encoding.UTF8.GetBytes(Config.SplitterFilter
                    .Replace("\\r", "\r")
                    .Replace("\\n", "\n")
                    .Replace("\\t", "\t")
                    .Replace("\\\\", "\\")
                    .Replace("\\0", "\0"));
            }
            else
            {
                return Encoding.UTF8.GetBytes(Config.SplitterFilter);
            }

        }

        private void btnSplit_Click(object sender, EventArgs e)
        {
            (sender as Button).Enabled = false;
            try
            {
                string SOURCE_FILE_PATH = Config.SourceFile;
                string TARGET_FILE_PREFIX = Path.GetFileNameWithoutExtension(SOURCE_FILE_PATH);
                string TARGET_FILE_EXTENSION = Path.GetExtension(Config.SourceFile);
                long MAXIMUM_OUTPUT_FILE_SIZE = Config.MaxFileSizeBytes;
                byte[] SPLIT_FILTER = GetFilter();

                int currentOutputFileNumber = 0;
                int bytesWrittenToCurrentOutputFile = 0;
                int totalBytesRead = 0;
                const int UPDATE_PER_BYTES = 1024 * 1024;
                using (BufferedFileTunnel tunnel = new BufferedFileTunnel(SOURCE_FILE_PATH))
                {
                    pb.Minimum = 0;
                    pb.Maximum = (int)(tunnel.Input.FileSize / UPDATE_PER_BYTES);

                    tunnel.OpenOutput(getFilePath(TARGET_FILE_PREFIX, TARGET_FILE_EXTENSION, currentOutputFileNumber));
                    int b = 0;
                    int filterPTR = 0;
                    while (!tunnel.Input.EOF)
                    {
                        b = tunnel.Input.ReadByte();
                        if (b >= 0)
                        {
                            //Always write data to file
                            tunnel.Output.WriteByte((byte)b);
                            bytesWrittenToCurrentOutputFile++;
                            totalBytesRead++;
                            if (totalBytesRead % UPDATE_PER_BYTES == 0)
                            {
                                pb.Value++;
                                pb.Refresh();
                                Application.DoEvents();
                            }
                            if (b == SPLIT_FILTER[filterPTR])
                            {
                                if (filterPTR < SPLIT_FILTER.Length - 1) //Filter is not yet matched totally 
                                {
                                    filterPTR++;
                                }
                                else // Filter is full matched
                                {
                                    filterPTR = 0;//reset filter ptr
                                    if (bytesWrittenToCurrentOutputFile >= MAXIMUM_OUTPUT_FILE_SIZE)//reached max length
                                    {
                                        bytesWrittenToCurrentOutputFile = 0;// reset file size counter
                                                                            //open new output file
                                        tunnel.OpenOutput(getFilePath(TARGET_FILE_PREFIX, TARGET_FILE_EXTENSION, ++currentOutputFileNumber));
                                    }//file is not splitted because of not reached max_file_size. Just continue
                                }
                            }
                            else //Filter not matched just reset filter ptr.
                            {
                                filterPTR = 0;
                            }
                        }
                        else // Second EOF check. 
                        {
                            break;
                        }

                        //Thread.Sleep(500); // experimental; perhaps try it
                    }//first EOF check
                }
                MessageBox.Show("End of process");
            }
            finally
            {
                (sender as Button).Enabled = true;
            }
        }

        private void btnSelectSourceFile_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDlg.InitialDirectory = Path.GetDirectoryName(Config.SourceFile);
            }
            catch { }
            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {
                Config.SourceFile = openFileDlg.FileName;
            }
        }

        private void btnSelectOutputDirectory_Click(object sender, EventArgs e)
        {
            try
            {
                folderDLG.SelectedPath = Config.OutputDirectory;
            }
            catch { }
            if (folderDLG.ShowDialog() == DialogResult.OK)
            {
                Config.OutputDirectory = folderDLG.SelectedPath;
            }
        }
    }
}
