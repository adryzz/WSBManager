using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WSBManager.WSB;

namespace WSBManager
{
    public partial class Form1 : Form
    {
        List<Sandbox> Sandboxes = new List<Sandbox>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var dir = Directory.CreateDirectory("Sandboxes");
            Sandboxes = WSBMan.ListSandboxes(dir);
            listView1.Items.Clear();
            foreach(Sandbox s in Sandboxes)
            {
                ListViewItem item = new ListViewItem()
                {
                    Text = Path.GetFileNameWithoutExtension(s.WSBFile),
                    Tag = s,
                    ImageIndex = 0
                };
                listView1.Items.Add(item);
            }
            listView1.View = View.LargeIcon;
            listView1.LargeImageList = new ImageList();
            listView1.LargeImageList.Images.Add(SystemIcons.Shield);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                Sandbox box = ((Sandbox)listView1.SelectedItems[0].Tag);

                if (box.SandboxProcess == null || box.SandboxProcess.HasExited)
                {
                    var v = new Form2(box);
                    v.ShowDialog();
                    if (v.IsOK)
                    {
                        Form1_Load(null, null);
                    }
                    Form1_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Close the sandbox first!");
                }
            }
        }

        private void deleteSandboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                Sandbox box = ((Sandbox)listView1.SelectedItems[0].Tag);

                if (box.SandboxProcess == null || box.SandboxProcess.HasExited)
                {
                    File.Delete(box.WSBFile);
                    Form1_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Close the sandbox first!");
                }
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                Sandbox box = ((Sandbox)listView1.SelectedItems[0].Tag);
                box.Run();
            }
        }

        private void newSandboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var v = new Form2();
            v.ShowDialog();
            if (v.IsOK)
            {
                Form1_Load(null, null);
            }

        }
    }
}
