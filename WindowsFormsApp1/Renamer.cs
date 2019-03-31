using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;



namespace WindowsFormsApp1
{
    public class Renamer
    {

        public Renamer(string fullname)
        {
            this.FullName = fullname;
        }

        public Renamer()
        {
        }

        public List<Renamer> FilesToRename;
        public string FullName { get; set; }

        public string ToCheck { get; set; }

        private string First { get; set; }

        public string FinaleName { get; set; }

        public FileInfo[] loadedFiles;

        public int renamedFiles { get; set; }

        public int renamedCounter { get; set; }

        public bool Renamed { get; set; }
        public void UpdateFiles(FileInfo[] loadedFiles)
        {
            this.loadedFiles = loadedFiles;
        }



        public void RenameItVoid(string contains, string renameTo, int count)
        {
            for(int i = 0; i < loadedFiles.Length; i ++)
            {
                string result;
                string nameWithoutExtension = Path.GetFileNameWithoutExtension(loadedFiles[i].FullName);
                string getExtension = Path.GetExtension(loadedFiles[i].FullName);
                string path = loadedFiles[i].DirectoryName;


                if(nameWithoutExtension.Length > count)
                {
                    this.ToCheck = nameWithoutExtension.Substring(nameWithoutExtension.Length - count);
                    this.First = nameWithoutExtension.Substring(0, (nameWithoutExtension.Length - 1) - (ToCheck.Length - 1));
                    nameWithoutExtension.Substring(0, nameWithoutExtension.Length - 1);


                    result = ToCheck.Replace(contains, renameTo);

                    this.FinaleName = this.First + result + getExtension;

                    string fullNewName = path + "\\" + FinaleName;

                    if(fullNewName != loadedFiles[i].FullName)
                    {
                        Renamed = true;
                        renamedFiles++;
                        renamedCounter++;
                        File.Move(loadedFiles[i].FullName, fullNewName);

                    }
                    

                }
            }
            
        }
    }
}
