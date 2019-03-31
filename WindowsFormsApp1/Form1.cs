using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

//CHECK IF LOADED FILES ARE THE SAME BEFORE CLICKING THE BUTTON FOR THE SECOND TIME.

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {

        public FileLoader fLoad;
        private Renamer Renamer;
        private string SelectedPath;
        public List<string> filesToRename;
        public List<Renamer> Renamer3;
        public ListViewItem listFile;

        public Form5()
        {
            fLoad = new FileLoader();
            Renamer = new Renamer();
            Renamer3 = new List<Renamer>();
            
            InitializeComponent();

            renameBtn.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {


            folderBrowserDialog1.ShowDialog();
            if(folderBrowserDialog1.SelectedPath.Length <= 0)
            { return; }

            SelectedPath = folderBrowserDialog1.SelectedPath;
            
            LoadInfoFromLoadedFilesToListBoxes();

            //if(button1.DialogResult == DialogResult.OK) 
            renameBtn.Enabled = true;
        }

    private void LoadInfoFromLoadedFilesToListBoxes()
        {
            fLoad.LoadFiles(SelectedPath);
            listView1.Items.Clear();
            //Filling loaded files list with loaded files
            for (int i = 0; i < fLoad.loadedFiles.Length; i++)
            {

                String[] lFile = new String[2];
                lFile[0] = fLoad.loadedFiles[i].Name;
                lFile[1] = fLoad.loadedFiles[i].CreationTime.ToString();
                listFile = new ListViewItem(lFile);

                listView1.Items.Add(listFile);
            }
        }

        //private void renameBtn_Click(object sender, EventArgs e)
        //{
        //    //FIGURE THE BELOW CHECK        


        //    if (Renamer.Renamed == false & RenameChecker == true && Renamer.renamedFiles == 0)
        //    {
        //        MessageBox.Show("Load new files");
        //        return;

        //    }
        //    Renamer.UpdateFiles(fLoad.loadedFiles.ToArray());

        //    Renamer.RenameItVoid(textBox2.Text, textBox3.Text, int.Parse(textBox1.Text));

        //    if (Renamer.renamedFiles == 0)
        //    {
        //        MessageBox.Show("No files to rename");
        //    }
        //    else
        //    {
        //        MessageBox.Show($"You have successfuly renamed {Renamer.renamedFiles.ToString()} files");
        //    }
        //    RenameChecker = true;

        //}

        private void renameBtn_Click(object sender, EventArgs e)
        {
            //FIGURE THE BELOW CHECK        
            if(Renamer.Renamed == true && Renamer.renamedFiles == 0)
            {
                MessageBox.Show("Load new files");
                return;
            }

            Renamer.UpdateFiles(fLoad.loadedFiles.ToArray());

            Renamer.RenameItVoid(textBox2.Text, textBox3.Text, int.Parse(textBox1.Text));

            if(Renamer.Renamed == true && Renamer.renamedFiles > 0)
            {
                MessageBox.Show($"You have successfuly renamed {Renamer.renamedCounter.ToString()} files");
            }
            else if(Renamer.Renamed == false)
            {
                MessageBox.Show("No files to rename");
            }

            LoadInfoFromLoadedFilesToListBoxes();
            Renamer.renamedCounter = 0;
        }



        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void howToUseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HowToUse hwu = new HowToUse();
            hwu.Show();
        }
    }
}
