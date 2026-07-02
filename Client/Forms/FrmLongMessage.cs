using System;
using System.Windows.Forms;

namespace Client.Forms
{
    public class FrmLongMessage : Form
    {
        private TextBox txtMessage;
        private Button btnOk;

        public FrmLongMessage(string title, string message)
        {
            this.Text = title ?? "Message";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Width = 600;
            this.Height = 400;

            txtMessage = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                Dock = DockStyle.Fill,
                WordWrap = true,
                BackColor = System.Drawing.SystemColors.Window,
                BorderStyle = BorderStyle.None,
                Margin = new Padding(10),
                Text = message ?? string.Empty
            };

            btnOk = new Button
            {
                Text = "OK",
                Dock = DockStyle.Bottom,
                Height = 36
            };
            btnOk.Click += (s, e) => this.Close();

            // layout
            this.Controls.Add(txtMessage);
            this.Controls.Add(btnOk);
        }
    }
}
