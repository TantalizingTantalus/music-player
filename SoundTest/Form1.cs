using System.Diagnostics;
using System.Media;
using System.Numerics;
using WMPLib;

namespace SoundTest
{
    public partial class Form1 : Form
    {
        string currentSound = null;
        string soundPath = null;
        private WindowsMediaPlayer Player;

        public Form1()
        {
            InitializeComponent();
            Player = new WindowsMediaPlayer();
            trackBar1.Value = Player.settings.volume;
            
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (Player.playState == WMPPlayState.wmppsPlaying)
            {
                Player.controls.pause();
            }
            else
            {
                Player.URL = listBox2.SelectedItem.ToString();
                Player.controls.play();
            }
                
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            // Show the FolderBrowserDialog.  
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                textBox1.Text = folderDlg.SelectedPath;
                soundPath = folderDlg.SelectedPath;
                DirectoryInfo dinfo = new DirectoryInfo(soundPath);
                FileInfo[] Files = dinfo.GetFiles("*.wav");
                foreach (FileInfo file in Files)
                {
                    if (!listBox1.Items.Contains(file.FullName))
                    {
                        listBox2.Items.Add(file.FullName);
                        listBox1.Items.Add(file.Name);
                    }
                    
                }
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Player.controls.stop();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Player.settings.volume = trackBar1.Value; 
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PopulateListBox(ListBox lsb, string Folder, string FileType)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = listBox1.SelectedItem.ToString();
            currentSound = listBox1.SelectedItem.ToString();
            listBox2.SelectedIndex = listBox1.SelectedIndex;
        }


        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = listBox2.SelectedIndex;
        }
    }
}