﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api.Services
{
    public class Writer
    {
        FileStream fileStream;
        string extension;
        public Writer(string extension)
        {
            this.extension = extension;
        }
        public void Write(byte[] buffer, int id)
        {
            if (fileStream == null)
            {
                fileStream = new FileStream(id + "." + extension, FileMode.OpenOrCreate);
                fileStream.Write(buffer, 0, buffer.Length);
            }
            else
            {
                fileStream.Write(buffer, 0, buffer.Length);
            }
        }
        public void Close()
        {
            fileStream.Close();
        }
    }
}
