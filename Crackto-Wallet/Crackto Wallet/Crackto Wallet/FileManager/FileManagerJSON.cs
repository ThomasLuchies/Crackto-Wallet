using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crackto_Wallet.FileManager
{
    internal class FileManagerJSON : FileManager
    {
        public async Task<string> ReadAsync(string filePath)
        {
            using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                var buffer = new byte[1024];
                var bytesRead = await fs.ReadAsync(buffer, 0, 1024);

                return Encoding.UTF8.GetString(buffer, 0, bytesRead);
            }

            return null;
        }

        public async Task Write(string filePath, string data)
        {
            using (FileStream stream = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.None, 4096, true))
            {
                using (StreamWriter sw = new StreamWriter(stream))
                {
                    await sw.WriteLineAsync(data);
                }
            }
        }

    }
}
