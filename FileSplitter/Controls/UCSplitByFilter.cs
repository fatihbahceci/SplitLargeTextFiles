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

namespace FileSplitter.Controls
{
    public partial class UCSplitByFilter : UserControl
    {
        private SplitByFilterConfig _config = new SplitByFilterConfig();
        public SplitByFilterConfig Config
        {
            get { return _config; }
            set
            {
                _config = value ?? new SplitByFilterConfig();
                bsConfig.DataSource = _config;
            }
        }
        public UCSplitByFilter()
        {
            InitializeComponent();
        }

        private string getFilePath(string fileName, string fileExt, int index)
        {
            return $@"{Config.OutputDirectory}\{fileName}_{ index.ToString().PadLeft(4, '0')}.{fileExt}";
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
                int MAXIMUM_OUTPUT_FILE_SIZE = Config.MaxFileSizeBytes;
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
