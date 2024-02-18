using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class FileNameParser
    {
        public string ParseFileName(string filePath)
        {
            if (filePath == null || filePath.Length == 0)
                throw new ArgumentNullException("Не правильно задан путь к файлу");
            
            int indexOfLastBackslash = 0;
            for (int i = filePath.Length - 1; i >= 0; i--)
            {
                if (filePath[i] == '\\')
                {
                    indexOfLastBackslash = i;
                    break;
                }
            }
            
            return filePath.Substring(indexOfLastBackslash + 1); 
        }
    }
}
