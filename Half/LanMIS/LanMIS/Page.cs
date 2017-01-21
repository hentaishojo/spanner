using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using System.Windows.Forms;

namespace LanMIS
{
    abstract class Page
    {
        public string query = "";
        public string name;
        public Panel panelThis;
        public List<Control> controlList = new List<Control>();
        
        public Page(string name, Panel panelParent)
        {
            this.name = name;

            panelThis = new Panel();
            panelThis.Dock = DockStyle.Fill;
            panelParent.Controls.Add(panelThis);

            initialize();
        }

        public abstract void initialize();

        public void Show()
        {
            panelThis.BringToFront();;
        }

        public void Hide()
        {
            panelThis.Hide();
        }
        //controlList.ForEach(delegate(Control ctrl)
        //    {
        //        ctrl.Hide();
        //    });
    }
}
