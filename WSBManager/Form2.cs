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
using WSBManager.WSB;
using WSBManager.Extensions;

namespace WSBManager
{
    public partial class Form2 : Form
    {
        public bool IsOK;

        public Sandbox Sandbox;

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Sandbox existing)
        {
            InitializeComponent();
            Sandbox = existing;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.AddEnumItems(typeof(VGpu));
            comboBox2.AddEnumItems(typeof(Networking));
            comboBox3.AddEnumItems(typeof(AudioInput));
            comboBox4.AddEnumItems(typeof(VideoInput));
            comboBox5.AddEnumItems(typeof(ProtectedClient));
            comboBox6.AddEnumItems(typeof(PrinterRedirection));
            comboBox7.AddEnumItems(typeof(ClipboardRedirection));

            if (Sandbox != null)
            {
                textBox1.Text = Path.GetFileNameWithoutExtension(Sandbox.WSBFile);
                numericUpDown1.Value = Sandbox.WSBConfig.MemoryInMB;
                comboBox1.SelectedIndex = (int)Sandbox.WSBConfig.VGpu;
                comboBox2.SelectedIndex = (int)Sandbox.WSBConfig.Networking;
                comboBox3.SelectedIndex = (int)Sandbox.WSBConfig.AudioInput;
                comboBox4.SelectedIndex = (int)Sandbox.WSBConfig.VideoInput;
                comboBox5.SelectedIndex = (int)Sandbox.WSBConfig.ProtectedClient;
                comboBox6.SelectedIndex = (int)Sandbox.WSBConfig.PrinterRedirection;
                comboBox7.SelectedIndex = (int)Sandbox.WSBConfig.ClipboardRedirection;
                textBox2.Text = Sandbox.WSBConfig.LogonCommand.Command;
            }
            else
            {
                Sandbox = new Sandbox();
                Sandbox.WSBConfig = new Configuration()
                {
                    MappedFolders = new List<MappedFolder>()
                };
            }
            ReloadFolders();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button1.Enabled = !string.IsNullOrWhiteSpace(textBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sandbox = new Sandbox()
            {
                WSBFile = Path.GetFullPath(Path.Combine("Sandboxes", textBox1.Text + ".wsb"))
            };
            Configuration config = new Configuration();
            config.MemoryInMB = Convert.ToUInt64(numericUpDown1.Value);
            config.VGpu = (VGpu)comboBox1.SelectedIndex;
            config.Networking = (Networking)comboBox2.SelectedIndex;
            config.AudioInput = (AudioInput)comboBox3.SelectedIndex;
            config.VideoInput = (VideoInput)comboBox4.SelectedIndex;
            config.ProtectedClient = (ProtectedClient)comboBox5.SelectedIndex;
            config.PrinterRedirection = (PrinterRedirection)comboBox6.SelectedIndex;
            config.ClipboardRedirection = (ClipboardRedirection)comboBox7.SelectedIndex;

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                config.LogonCommand = new LogonCommand()
                {
                    Command = textBox2.Text
                };
            }

            Sandbox.WSBConfig = config;
            Sandbox.Save();
            IsOK = true;
            Close();
        }

        void ReloadFolders()
        {
            listView1.Items.Clear();
            foreach(MappedFolder folder in Sandbox.WSBConfig.MappedFolders)
            {
                ListViewItem i = new ListViewItem(new string[] { folder.HostFolder, folder.SandboxFolder, folder.ReadOnly.ToString() });
                i.Tag = folder;
                listView1.Items.Add(i);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.ShowDialog();
            if (f3.IsOK)
            {
                var folder = f3.SharedFolder;
                Sandbox.WSBConfig.MappedFolders.Add(folder);
            }
            ReloadFolders();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                var f = (MappedFolder)listView1.SelectedItems[0].Tag;
                Form3 f3 = new Form3(f);
                f3.ShowDialog();
                if (f3.IsOK)
                {
                    var folder = f3.SharedFolder;
                    Sandbox.WSBConfig.MappedFolders[listView1.SelectedIndices[0]] = folder;
                }
                ReloadFolders();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                var f = (MappedFolder)listView1.SelectedItems[0].Tag;
                Sandbox.WSBConfig.MappedFolders.Remove(f);
                ReloadFolders();
            }
        }
    }
}
