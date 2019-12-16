using System;
using System.IO;

namespace FileSplitter
{

    class BufferedFileTunnel : IDisposable
    {
        private BufferedInputFileSteram input;
        private BufferedOutputFileSteram output;
        private int bufferSize = 0;


        public BufferedInputFileSteram Input { get => input; }
        public BufferedOutputFileSteram Output
        {
            get => output;
            private set
            {
                if (output != null)
                {
                    //Flush and dispose old output
                    output.Dispose();
                }
                output = value;
            }
        }

        public void OpenOutput(string path)
        {
            Output = new BufferedOutputFileSteram(File.OpenWrite(path), bufferSize);
        }

        public BufferedFileTunnel(string inputFile, int bufferSize = 4 * 1024 * 1024)
        {
            this.bufferSize = bufferSize;
            input = new BufferedInputFileSteram(File.OpenRead(inputFile), bufferSize);
        }

        public void Dispose()
        {
            if (input != null)
            {
                input.Dispose();
                input = null;
            }
            if (output != null)
            {
                output.Dispose();
                output = null;
            }
        }
    }
}
