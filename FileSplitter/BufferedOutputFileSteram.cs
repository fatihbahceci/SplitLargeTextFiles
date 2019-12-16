using System;
using System.IO;

namespace FileSplitter
{
    class BufferedOutputFileSteram : IDisposable
    {
        private byte[] cache;
        private Stream output;
        public BufferedOutputFileSteram(Stream stream, int cacheSize)
        {
            this.output = stream;
            cache = new byte[cacheSize];
        }
        private int ptr = 0;


        private void FlushData()
        {
            if (ptr > 0)
            {
                output.Write(cache, 0, ptr);
            }
            ptr = 0;
        }
        public void WriteByte(byte b)
        {
            //0 (index) => 1 (count)
            if (ptr >= cache.Length)
            {
                FlushData();
            }
            cache[ptr] = b;
            ptr++;
        }

        public void Dispose()
        {
            if (output != null)
            {
                FlushData();
                //Dispose
                output.Dispose();
                output = null;
            }

        }
    }
}
