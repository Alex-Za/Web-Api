using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api.Services
{
    public class FileManager : IFileManager
    {
        public void Close(int id)
        {
            allFiles[id].Close();
        }

        public int GetID(string extension)
        {
            this.extension = extension;
            Random rnd = new Random();
            return rnd.Next(100000);
        }
        string extension;
        Dictionary<int, Writer> allFiles = new Dictionary<int, Writer>();
        public void Write(int id, byte[] buffer)
        {

            if (!allFiles.ContainsKey(id))
            {
                allFiles.Add(id, new Writer());
                allFiles[id].Write(buffer, id, extension);
            }
            else
            {
                allFiles[id].Write(buffer, id, extension);
            }

        }
    }
}
