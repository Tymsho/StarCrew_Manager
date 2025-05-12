using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace StarCrewMVC
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            CustomUI.LoadDefaultStyle(this);
        }

        public void CargarUserControl(UserControl nuevoUC)
        {
            panelContenido.Controls.Clear();
            nuevoUC.Dock = DockStyle.Fill;
            panelContenido.Controls.Add(nuevoUC);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            ucMenu menu = new ucMenu();
            panelMenu.Controls.Add(menu);
        }
    }
}
