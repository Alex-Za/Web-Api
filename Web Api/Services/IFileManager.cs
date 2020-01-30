using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api.Services
{
    public interface IFileManager
    {
        int GetID(string extension);
        void Write(int id, byte[] buffer);
        void Close(int id);
    }
}
