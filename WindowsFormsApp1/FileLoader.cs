using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowsFormsApp1
{
    public class FileLoader
    {
        public FileInfo[] loadedFiles;

        public FileLoader()
        {
            this.loadedFiles = new FileInfo[0];
        }
        public FileInfo[] LoadFiles (string selectedPath)
        {
            DirectoryInfo dir = new DirectoryInfo(selectedPath);
            loadedFiles = dir.GetFiles();
            return loadedFiles;        
        }

    }
}
