using System;
using System.IO;

namespace FileSplitter
{

    class BufferedInputFileSteram : IDisposable
    {
        private byte[] cache;
        private Stream input;
        public BufferedInputFileSteram(Stream stream, int cacheSize)
        {
            this.input = stream;
            cache = new byte[cacheSize];
        }
        private int ptr = 0;
        private int read = 0;
        public int ReadByte()
        {
            //0 (index) => 1 (count)
            if (ptr >= read)
            {
                read = input.Read(cache, 0, cache.Length);
                ptr = 0;
                if (read > 0)
                {

                    return cache[ptr++];
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return cache[ptr++];
            }
        }

        public bool EOF { get { return input.Position > input.Length; } }

        public void Dispose()
        {
            if (input != null)
            {
                //Dispose
                input.Dispose();
                input = null;
            }

        }
    }
}
