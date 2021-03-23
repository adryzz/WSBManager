using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WSBManager.WSB;

namespace WSBManager
{
    public partial class Form3 : Form
    {
        public bool IsOK;

        public MappedFolder SharedFolder = new MappedFolder();

        public Form3()
        {
            InitializeComponent();
        }

        public Form3(MappedFolder existing)
        {
            InitializeComponent();
            textBox1.Text = existing.HostFolder;
            textBox2.Text = existing.SandboxFolder;
            checkBox1.Checked = existing.ReadOnly;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using(FolderBrowserDialog f = new FolderBrowserDialog())
            {
                var res = f.ShowDialog();
                if (res == DialogResult.OK)
                {
                    textBox1.Text = f.SelectedPath;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SharedFolder = new MappedFolder
            {
                HostFolder = textBox1.Text,
                SandboxFolder = textBox2.Text,
                ReadOnly = checkBox1.Checked
            };
            IsOK = true;
            Close();
        }
    }
}
