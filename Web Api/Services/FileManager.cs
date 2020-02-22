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

        Writer writer;
        int id = 0;
        public int GetID(string extension)
        {
            writer = new Writer(extension);
            id += 1;
            return id;
        }
        Dictionary<int, Writer> allFiles = new Dictionary<int, Writer>();
        public void Write(int id, byte[] buffer)
        {

            if (!allFiles.ContainsKey(id))
            {
                allFiles.Add(id, writer);
                allFiles[id].Write(buffer, id);
            }
            else
            {
                allFiles[id].Write(buffer, id);
            }

        }
    }
}
