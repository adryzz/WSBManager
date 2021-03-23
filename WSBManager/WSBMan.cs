using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSBManager.WSB;

namespace WSBManager
{
    static class WSBMan
    {
        public static List<Sandbox> ListSandboxes(DirectoryInfo dir)
        {
            List<Sandbox> boxes = new List<Sandbox>();
            foreach(FileInfo f in dir.EnumerateFiles("*.wsb", SearchOption.AllDirectories))
            {
                Sandbox box = new Sandbox()
                {
                    WSBFile = f.FullName,
                    WSBConfig = Sandbox.FromFile(f.FullName)
                };
                boxes.Add(box);
            }
            return boxes;
        }
    }
}
