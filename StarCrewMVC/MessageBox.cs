using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StarCrewMVC
{
    // MessageBox Personalizado
    public static class AlienMessageBox
    {
        public static DialogResult Show(string message, string caption = "Mensaje",
                                       MessageBoxButtons buttons = MessageBoxButtons.OK,
                                       MessageBoxIcon icon = MessageBoxIcon.None)
        {
            // Crear un formulario rápido
            using (Form customBox = new Form())
            {
                // Estilo alienígena: Negro con verde
                Color backColor = Color.FromArgb(10, 10, 10);  // Negro casi puro
                Color greenAlien = Color.FromArgb(0, 255, 0);  // Verde brillante
                Color greenDark = Color.FromArgb(0, 180, 0);   // Verde más oscuro para botones

                // Configuración básica del form
                customBox.Text = caption;
                customBox.BackColor = backColor;
                customBox.ForeColor = greenAlien;
                customBox.FormBorderStyle = FormBorderStyle.FixedDialog;
                customBox.MaximizeBox = false;
                customBox.MinimizeBox = false;
                customBox.StartPosition = FormStartPosition.CenterScreen;
                customBox.ShowInTaskbar = false;
                customBox.Size = new Size(400, 200);
                customBox.Font = new Font("OCR A Extended", 9F, FontStyle.Bold); // Fuente tipo terminal

                // Label para el mensaje
                Label lblMessage = new Label();
                lblMessage.Text = message;
                lblMessage.BackColor = backColor;
                lblMessage.ForeColor = greenAlien;
                lblMessage.AutoSize = false;
                lblMessage.Size = new Size(360, 100);
                lblMessage.Location = new Point(20, 20);
                lblMessage.TextAlign = ContentAlignment.MiddleCenter;
                customBox.Controls.Add(lblMessage);

                // Configurar botones según el tipo
                switch (buttons)
                {
                    case MessageBoxButtons.OK:
                        Button btnOK = new Button();
                        btnOK.Text = "OK";
                        btnOK.DialogResult = DialogResult.OK;
                        btnOK.Location = new Point(150, 120);
                        btnOK.Size = new Size(100, 30);
                        btnOK.FlatStyle = FlatStyle.Flat;
                        btnOK.FlatAppearance.BorderColor = greenAlien;
                        btnOK.BackColor = backColor;
                        btnOK.ForeColor = greenAlien;
                        customBox.Controls.Add(btnOK);
                        break;

                    case MessageBoxButtons.OKCancel:
                        Button btnOk = new Button();
                        btnOk.Text = "OK";
                        btnOk.DialogResult = DialogResult.OK;
                        btnOk.Location = new Point(100, 120);
                        btnOk.Size = new Size(100, 30);
                        btnOk.FlatStyle = FlatStyle.Flat;
                        btnOk.FlatAppearance.BorderColor = greenAlien;
                        btnOk.BackColor = backColor;
                        btnOk.ForeColor = greenAlien;
                        customBox.Controls.Add(btnOk);

                        Button btnCancel = new Button();
                        btnCancel.Text = "Cancelar";
                        btnCancel.DialogResult = DialogResult.Cancel;
                        btnCancel.Location = new Point(220, 120);
                        btnCancel.Size = new Size(100, 30);
                        btnCancel.FlatStyle = FlatStyle.Flat;
                        btnCancel.FlatAppearance.BorderColor = greenAlien;
                        btnCancel.BackColor = backColor;
                        btnCancel.ForeColor = greenAlien;
                        customBox.Controls.Add(btnCancel);
                        break;

                    case MessageBoxButtons.YesNo:
                        Button btnYes = new Button();
                        btnYes.Text = "Sí";
                        btnYes.DialogResult = DialogResult.Yes;
                        btnYes.Location = new Point(100, 120);
                        btnYes.Size = new Size(100, 30);
                        btnYes.FlatStyle = FlatStyle.Flat;
                        btnYes.FlatAppearance.BorderColor = greenAlien;
                        btnYes.BackColor = backColor;
                        btnYes.ForeColor = greenAlien;
                        customBox.Controls.Add(btnYes);

                        Button btnNo = new Button();
                        btnNo.Text = "No";
                        btnNo.DialogResult = DialogResult.No;
                        btnNo.Location = new Point(220, 120);
                        btnNo.Size = new Size(100, 30);
                        btnNo.FlatStyle = FlatStyle.Flat;
                        btnNo.FlatAppearance.BorderColor = greenAlien;
                        btnNo.BackColor = backColor;
                        btnNo.ForeColor = greenAlien;
                        customBox.Controls.Add(btnNo);
                        break;

                    case MessageBoxButtons.YesNoCancel:
                        Button btnYesNC = new Button();
                        btnYesNC.Text = "Sí";
                        btnYesNC.DialogResult = DialogResult.Yes;
                        btnYesNC.Location = new Point(60, 120);
                        btnYesNC.Size = new Size(100, 30);
                        btnYesNC.FlatStyle = FlatStyle.Flat;
                        btnYesNC.FlatAppearance.BorderColor = greenAlien;
                        btnYesNC.BackColor = backColor;
                        btnYesNC.ForeColor = greenAlien;
                        customBox.Controls.Add(btnYesNC);

                        Button btnNoNC = new Button();
                        btnNoNC.Text = "No";
                        btnNoNC.DialogResult = DialogResult.No;
                        btnNoNC.Location = new Point(170, 120);
                        btnNoNC.Size = new Size(100, 30);
                        btnNoNC.FlatStyle = FlatStyle.Flat;
                        btnNoNC.FlatAppearance.BorderColor = greenAlien;
                        btnNoNC.BackColor = backColor;
                        btnNoNC.ForeColor = greenAlien;
                        customBox.Controls.Add(btnNoNC);

                        Button btnCancelNC = new Button();
                        btnCancelNC.Text = "Cancelar";
                        btnCancelNC.DialogResult = DialogResult.Cancel;
                        btnCancelNC.Location = new Point(280, 120);
                        btnCancelNC.Size = new Size(100, 30);
                        btnCancelNC.FlatStyle = FlatStyle.Flat;
                        btnCancelNC.FlatAppearance.BorderColor = greenAlien;
                        btnCancelNC.BackColor = backColor;
                        btnCancelNC.ForeColor = greenAlien;
                        customBox.Controls.Add(btnCancelNC);
                        break;

                    case MessageBoxButtons.RetryCancel:
                        Button btnRetry = new Button();
                        btnRetry.Text = "Reintentar";
                        btnRetry.DialogResult = DialogResult.Retry;
                        btnRetry.Location = new Point(100, 120);
                        btnRetry.Size = new Size(100, 30);
                        btnRetry.FlatStyle = FlatStyle.Flat;
                        btnRetry.FlatAppearance.BorderColor = greenAlien;
                        btnRetry.BackColor = backColor;
                        btnRetry.ForeColor = greenAlien;
                        customBox.Controls.Add(btnRetry);

                        Button btnCancelRC = new Button();
                        btnCancelRC.Text = "Cancelar";
                        btnCancelRC.DialogResult = DialogResult.Cancel;
                        btnCancelRC.Location = new Point(220, 120);
                        btnCancelRC.Size = new Size(100, 30);
                        btnCancelRC.FlatStyle = FlatStyle.Flat;
                        btnCancelRC.FlatAppearance.BorderColor = greenAlien;
                        btnCancelRC.BackColor = backColor;
                        btnCancelRC.ForeColor = greenAlien;
                        customBox.Controls.Add(btnCancelRC);
                        break;

                    case MessageBoxButtons.AbortRetryIgnore:
                        Button btnAbort = new Button();
                        btnAbort.Text = "Abortar";
                        btnAbort.DialogResult = DialogResult.Abort;
                        btnAbort.Location = new Point(60, 120);
                        btnAbort.Size = new Size(100, 30);
                        btnAbort.FlatStyle = FlatStyle.Flat;
                        btnAbort.FlatAppearance.BorderColor = greenAlien;
                        btnAbort.BackColor = backColor;
                        btnAbort.ForeColor = greenAlien;
                        customBox.Controls.Add(btnAbort);

                        Button btnRetryARI = new Button();
                        btnRetryARI.Text = "Reintentar";
                        btnRetryARI.DialogResult = DialogResult.Retry;
                        btnRetryARI.Location = new Point(170, 120);
                        btnRetryARI.Size = new Size(100, 30);
                        btnRetryARI.FlatStyle = FlatStyle.Flat;
                        btnRetryARI.FlatAppearance.BorderColor = greenAlien;
                        btnRetryARI.BackColor = backColor;
                        btnRetryARI.ForeColor = greenAlien;
                        customBox.Controls.Add(btnRetryARI);

                        Button btnIgnore = new Button();
                        btnIgnore.Text = "Ignorar";
                        btnIgnore.DialogResult = DialogResult.Ignore;
                        btnIgnore.Location = new Point(280, 120);
                        btnIgnore.Size = new Size(100, 30);
                        btnIgnore.FlatStyle = FlatStyle.Flat;
                        btnIgnore.FlatAppearance.BorderColor = greenAlien;
                        btnIgnore.BackColor = backColor;
                        btnIgnore.ForeColor = greenAlien;
                        customBox.Controls.Add(btnIgnore);
                        break;
                }

                // Efecto de hover para botones
                foreach (Button btn in customBox.Controls.OfType<Button>())
                {
                    btn.MouseEnter += (s, e) =>
                    {
                        btn.BackColor = greenDark;
                        btn.ForeColor = backColor;
                    };
                    btn.MouseLeave += (s, e) =>
                    {
                        btn.BackColor = backColor;
                        btn.ForeColor = greenDark;
                    };
                }
                // Mostrar y devolver resultado
                return customBox.ShowDialog();
            }
        }


        private static Button CreateButton(string text, DialogResult dialogResult, Point location, Color backColor, Color foreColor)
        {
            Button btn = new Button();
            btn.Text = text;
            btn.DialogResult = dialogResult;
            btn.Size = new Size(100, 30);
            btn.Location = location;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = foreColor;
            btn.BackColor = backColor;
            btn.ForeColor = foreColor;
            return btn;
        }
    }
}
