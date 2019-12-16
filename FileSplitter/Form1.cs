using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace FileSplitter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private string getFilePath(string fileName, string fileExt, int index)
        {
            return $@"{tOutputDirectory.Text}\{fileName}_{ index.ToString().PadLeft(4, '0')}.{fileExt}";
        }

        private byte[] GetFilter()
        {
            if (cbExtended.Checked)
            {
                return Encoding.UTF8.GetBytes(tDelimiter.Text
                    .Replace("\\r", "\r")
                    .Replace("\\n", "\n")
                    .Replace("\\t", "\t")
                    .Replace("\\\\", "\\")
                    .Replace("\\0", "\0"));
            }
            else
            {
                return Encoding.UTF8.GetBytes(tDelimiter.Text);
            }

        }

        private void btnSplit_Click(object sender, EventArgs e)
        {
            string SOURCE_FILE_PATH = tSource.Text;
            string TARGET_FILE_PREFIX = Path.GetFileNameWithoutExtension(SOURCE_FILE_PATH);
            string TARGET_FILE_EXTENSION = Path.GetExtension(tSource.Text);
            int MAXIMUM_OUTPUT_FILE_SIZE = Convert.ToInt32(tMaxFileSize.Text);
            byte[] SPLIT_FILTER = GetFilter();

            int currentOutputFileNumber = 0;
            int bytesWrittenToCurrentOutputFile = 0;

            using (BufferedFileTunnel tunnel = new BufferedFileTunnel(SOURCE_FILE_PATH))
            {
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


        private void kelle()
        {
            const int BUFFER_SIZE = 1 * 1024 * 1024;
            byte[] buffer = new byte[BUFFER_SIZE];
            string fileName = Path.GetFileNameWithoutExtension(tSource.Text);
            string fileExt = Path.GetExtension(tSource.Text);
            int maxFileSize = Convert.ToInt32(tMaxFileSize.Text);
            string filter = tDelimiter.Text;
            if (cbExtended.Checked)
            {
                filter = filter
                    .Replace("\\r", "\r")
                    .Replace("\\n", "\r")
                    .Replace("\\t", "\r")
                    .Replace("\\\\", "\\")
                    .Replace("\\0", "\0");
            }
            byte[] bfilter = Encoding.UTF8.GetBytes(filter);
            using (Stream input = File.OpenRead(tSource.Text))
            {


                int index = 0;
                while (input.Position < input.Length)
                {
                    using (Stream output = File.Create($@"{tOutputDirectory.Text}\{fileName}_{ index.ToString().PadLeft(4, '0')}.{fileExt}"))
                    {
                        int remaining = maxFileSize, bytesRead;
                        while (remaining > 0 && (bytesRead = input.Read(buffer, 0,
                                Math.Min(remaining, BUFFER_SIZE))) > 0)
                        {
                            output.Write(buffer, 0, bytesRead);
                            remaining -= bytesRead;
                        }
                    }
                    index++;
                    Thread.Sleep(500); // experimental; perhaps try it
                }
            }
        }

        private void btnSelectSourceFile_Click(object sender, EventArgs e)
        {
            if (openFileDlg.ShowDialog() == DialogResult.OK)
            {

            }
        }
    }
}
