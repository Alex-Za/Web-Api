using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api.Services
{
    public class FileManager : IFileManager
    {
        public void Close(int id)
        {
            
        }

        public int GetID(string extension)
        {
            return 1;
        }

        public void Write(int id, byte[] buffer)
        {

        }
    }
}
