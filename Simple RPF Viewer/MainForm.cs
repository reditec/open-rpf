using System;
using System.IO;
using System.Windows.Forms;
using rpf = RPF;

namespace Simple_RPF_Viewer
{
    public partial class MainForm : Form
    {
        Toc toc;
        String rpfPath = "";

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
                    listView.Items[i.ToString()].SubItems.Add(rpf::Calculator.CalculateSize(2048));
                    listView.Items[i.ToString()].SubItems.Add("No");
                    listView.Items[i.ToString()].SubItems.Add("No");
                }

            }
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
                    rpf::FileExtractor.ExtractFile(rpfPath, file.Name, file.Offset, file.Size, file.CompressedSize);
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

            FileStream rpfStream = File.Open(rpfPath, FileMode.Open);
            byte[] temp = new byte[20];
            rpfStream.Read(temp, 0, 20);
            rpfStream.Close();

            Header header = new Header(new MemoryStream(temp));



            rpfStream = File.Open(rpfPath, FileMode.Open);

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
    }
}
