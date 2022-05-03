using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crackto_Wallet.FileManager
{
    public interface FileManager
    {
        Task<string> ReadAsync(string filePath);
        Task Write(string filePath, string data);
    }
}
