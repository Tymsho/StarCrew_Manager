using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StarCrewMVC
{
    public static class CustomUI
    {
        public static void LoadDefaultStyle(Form actualForm)
        {
            ApplyStyle(actualForm);
        }

        public static void LoadDefaultStyle(UserControl userControl)
        {
            ApplyStyle(userControl);
        }

        private static void ApplyStyle(Control parent)
        {
            Color primary = Color.Black;
            Color secondary = Color.LimeGreen;

            parent.BackColor = primary;

            foreach (Control control in parent.Controls)
            {
                if (control is Button)
                {
                    ((Button)control).BackColor = secondary;
                    ((Button)control).ForeColor = primary;
                    ((Button)control).FlatStyle = FlatStyle.Flat;
                    ((Button)control).Font = new Font("OCR A Extended", 9F, FontStyle.Bold);
                    ((Button)control).TextAlign = ContentAlignment.MiddleCenter;
                }
                else if (control is CheckBox)
                {
                    ((CheckBox)control).ForeColor = primary;
                    ((CheckBox)control).Font = new Font("OCR A Extended", 9F, FontStyle.Bold);
                }
                else if (control is RadioButton)
                {
                    ((RadioButton)control).ForeColor = secondary;
                    ((RadioButton)control).Font = new Font("OCR A Extended", 9F, FontStyle.Bold);
                }
                else if (control is TextBox)
                {
                    ((TextBox)control).BackColor = Color.LimeGreen;
                    ((TextBox)control).ForeColor = Color.Black;
                    ((TextBox)control).BorderStyle = BorderStyle.None;
                    ((TextBox)control).Font = new Font("OCR A Extended", 9F, FontStyle.Bold);
                }
                else if (control is Label)
                {
                    ((Label)control).ForeColor = secondary;
                    ((Label)control).Font = new Font("OCR A Extended", 9F, FontStyle.Bold);
                }
                else if (control is DataGridView)
                {
                    ApplyDataGridViewStyle((DataGridView)control);
                }
                else if (control is UserControl)
                {
                    ApplyStyle(control); // Aplicar la misma lógica a los controles dentro del UserControl
                }
            }
        }
        private static void ApplyDataGridViewStyle(DataGridView dgv)
        {
            Color primary = Color.Black;
            Color secondary = Color.LimeGreen;

            dgv.BackgroundColor = primary;
            dgv.BorderStyle = BorderStyle.None;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.DefaultCellStyle.BackColor = primary;
            dgv.DefaultCellStyle.ForeColor = secondary;
            dgv.DefaultCellStyle.Font = new Font("OCR A Extended", 9F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.BackColor = secondary;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = primary;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("OCR A Extended", 9F, FontStyle.Bold);
            dgv.EnableHeadersVisualStyles = false;
            dgv.DefaultCellStyle.SelectionBackColor = secondary;
            dgv.DefaultCellStyle.SelectionForeColor = primary;
            dgv.GridColor = secondary;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(0); // quita efecto hundido
            // Eliminar selección visual automáticamente
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.SelectionChanged += (s, e) => dgv.ClearSelection();
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.LimeGreen;
        }


    }
}
