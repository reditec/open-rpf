using RPF;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using rpf = RPF;

namespace Simple_RPF_Viewer
{
    public partial class MainForm : Form
    {
        Toc toc;
        String rpfPath = "";
        private int _upperDir = 0;

        public MainForm(String[] args)
        {
            InitializeComponent();
            if (args.Length > 0)
            {
                rpfPath = args[0];
            }
        }

        private void LoadDirectory(Toc toc, int index)
        {

            listView.Items.Clear();


            rpf::Directory myDir = toc.FileSystemEntriesList[index] as rpf::Directory;

            for (int i = myDir.FirstOffset; i < myDir.FirstOffset + myDir.Count; i++)
            {

                //try this one after the roll-out of the next gui preview



                listView.Items.Add(i.ToString(), toc.FileSystemEntriesList[i].Name, 0);

                if (toc.FileSystemEntriesList[i].GetType() == typeof(rpf::Directory))
                {
                    rpf::Directory crtDirectory = toc.FileSystemEntriesList[i] as rpf::Directory;
                    listView.Items[i.ToString()].SubItems.Add("Folder");
                    listView.Items[i.ToString()].SubItems.Add(crtDirectory.Count + " items");
                    listView.Items[i.ToString()].SubItems.Add("Folder");
                    listView.Items[i.ToString()].SubItems.Add("No");
                    listView.Items[i.ToString()].Group = listView.Groups["dir"];
                }
                else
                {
                    rpf::File crtFile = toc.FileSystemEntriesList[i] as rpf::File;
                    listView.Items[i.ToString()].SubItems.Add("File");
                    listView.Items[i.ToString()].SubItems.Add(rpf::Calculator.CalculateSize(crtFile.Size));
                    listView.Items[i.ToString()].SubItems.Add("No");
                    listView.Items[i.ToString()].SubItems.Add("No");
                }

            }

            //make back button work
            //index: current folder index
            _upperDir = GetUpperDirectory(toc, index);
            if (_upperDir != -1)
            {
                backButton.Enabled = true;
            }
            else
            {
                backButton.Enabled = false;
            }
        }

        private int GetUpperDirectory(Toc toc, int index)
        {
            int counter = 0;
            foreach (FileSystemEntry fse in toc.FileSystemEntriesList)
            {
                if (fse.GetType() == typeof(rpf::Directory))
                {
                    rpf::Directory currentDir = fse as rpf::Directory;
                    if (index >= currentDir.FirstOffset && index < currentDir.FirstOffset + currentDir.Count)
                    {
                        return counter;
                    }
                }
                counter++;
            }
            return -1;
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {

            if (listView.SelectedItems.Count == 1)
            {
                if (toc.FileSystemEntriesList[Convert.ToInt32(listView.SelectedItems[0].Name)].GetType() == typeof(rpf::Directory))
                {
                    LoadDirectory(toc, Convert.ToInt32(listView.SelectedItems[0].Name));
                }
                else
                {

                    rpf::File file = toc.FileSystemEntriesList[Convert.ToInt32(listView.SelectedItems[0].Name)] as rpf::File;
                    String temppath = Path.GetTempPath() + "open-rpf\\";
                    System.IO.Directory.CreateDirectory(temppath);
                    rpf::FileExtractor.ExtractFile(rpfPath, temppath + file.Name, file.Offset, file.Size, file.CompressedSize);
                    //System.Diagnostics.Process.Start(temppath + file.Name);

                    try
                    {
                        var p = new Process();
                        p.StartInfo = new ProcessStartInfo(temppath + file.Name)
                        {
                            UseShellExecute = true
                        };
                        p.Start();
                    }
                    catch (Exception ex)
                    {
                        var args = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "shell32.dll");
                        args += ",OpenAs_RunDLL " + temppath + file.Name;
                        Process.Start("rundll32.exe", args);
                    }




                    //to extract file next to exe:
                    //rpf::FileExtractor.ExtractFile(rpfPath, file.Name, file.Offset, file.Size, file.CompressedSize);
                }
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (rpfPath == "")
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.AddExtension = true;
                ofd.Filter = "RPF0 files (*.rpf)|*.rpf";
                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;
                ofd.DefaultExt = ".rpf";
                ofd.ShowDialog();
                rpfPath = ofd.FileName;
            }

            MainForm.ActiveForm.BringToFront();

            FileStream rpfStream = System.IO.File.Open(rpfPath, FileMode.Open);
            byte[] temp = new byte[20];
            rpfStream.Read(temp, 0, 20);
            rpfStream.Close();

            Header header = new Header(new MemoryStream(temp));



            rpfStream = System.IO.File.Open(rpfPath, FileMode.Open);

            temp = new byte[header.GetTocSize()];
            rpfStream.Seek(2048, SeekOrigin.Begin);
            rpfStream.Read(temp, 0, header.GetTocSize());
            rpfStream.Close();

            toc = new Toc(new MemoryStream(temp), header.GetCount());
            if (toc.FileSystemEntriesList[0].GetType() == typeof(rpf::Directory))
            {
                LoadDirectory(toc, 0);
            }
            else
            {
                MessageBox.Show("RPF must start with a root directory.");
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (toc.FileSystemEntriesList[_upperDir].GetType() == typeof(rpf::Directory))
            {
                LoadDirectory(toc, _upperDir);
            }

        }

        private void extractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                FolderBrowserDialog sfd = new FolderBrowserDialog();
                sfd.ShowDialog();
                String extractPath = sfd.SelectedPath;
                MainForm.ActiveForm.BringToFront();

                rpf::File file = toc.FileSystemEntriesList[Convert.ToInt32(listView.SelectedItems[0].Name)] as rpf::File;
                rpf::FileExtractor.ExtractFile(rpfPath, extractPath + "\\" + file.Name, file.Offset, file.Size, file.CompressedSize);

            }
        }

        private void listView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && (listView.SelectedItems.Count == 1))
            {
                if (toc.FileSystemEntriesList[Convert.ToInt32(listView.SelectedItems[0].Name)].GetType() == typeof(rpf::Directory))
                {
                    extractToolStripMenuItem.Enabled = false;
                    openWithToolStripMenuItem.Enabled = false;
                }
                else
                {
                    extractToolStripMenuItem.Enabled = true;
                    openWithToolStripMenuItem.Enabled = true;
                }
                contextMenu.Show(MousePosition.X, MousePosition.Y);
            }
        }

        private void openWithToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                rpf::File file = toc.FileSystemEntriesList[Convert.ToInt32(listView.SelectedItems[0].Name)] as rpf::File;
                String temppath = Path.GetTempPath() + "open-rpf\\";
                System.IO.Directory.CreateDirectory(temppath);
                rpf::FileExtractor.ExtractFile(rpfPath, temppath + file.Name, file.Offset, file.Size, file.CompressedSize);
                //System.Diagnostics.Process.Start(temppath + file.Name);

                var args = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "shell32.dll");
                args += ",OpenAs_RunDLL " + temppath + file.Name;
                Process.Start("rundll32.exe", args);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1_DoubleClick(null, null);
        }
    }
}
