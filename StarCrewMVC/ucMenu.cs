using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static StarCrewMVC.FormMain;

namespace StarCrewMVC
{
    public partial class ucMenu : UserControl
    {
        public ucMenu()
        {
            InitializeComponent();
            CustomUI.LoadDefaultStyle(this);
            AplicarHover(btnTripulantes);
            AplicarHover(btnMisiones);
            AplicarHover(btnHistorial);
            AplicarHover(btnSalir);
        }

        private void hoverButton(Button button, bool isHovering)
        {
            if (isHovering)
            {
                button.BackColor = Color.Black;
                button.ForeColor = Color.LimeGreen;
            }
            else
            {
                button.BackColor = Color.LimeGreen;
                button.ForeColor = Color.Black;
            }
        }

        private void AplicarHover(Button btn)
        {
            btn.MouseEnter += (s, e) => hoverButton(btn, true);
            btn.MouseLeave += (s, e) => hoverButton(btn, false);
        }


        private void btnTripulantes_Click(object sender, EventArgs e)
        {
            UserControl uc = new ucTripulantes();  
            ((FormMain)this.ParentForm).CargarUserControl(uc);
        }

        private void btnMisiones_Click(object sender, EventArgs e)
        {
            UserControl uc = new ucMisiones();
            ((FormMain)this.ParentForm).CargarUserControl(uc);
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            UserControl uc = new ucHistorial();
            ((FormMain)this.ParentForm).CargarUserControl(uc);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            var confirmar = AlienMessageBox.Show("¿Estás seguro de querer salir?", "Confirmar salida", MessageBoxButtons.YesNo);
            if (confirmar == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
