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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
       
/*
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
*/
    }
}
