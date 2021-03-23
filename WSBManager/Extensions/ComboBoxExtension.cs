using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSBManager.Extensions
{
    static class ComboBoxExtension
    {
        public static void AddEnumItems(this ComboBox box, Type t)
        {
            if (!t.IsEnum)
            {
                throw new ArgumentException("The provided type is not an enum.");
            }
            var v = Enum.GetNames(t);
            box.Items.AddRange(v);
            box.SelectedIndex = 0;
        }

    }
}
