namespace Server
{
    public partial class FrmServer : Form
    {
        Server server;
        public FrmServer()
        {
            InitializeComponent();
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            server = new Server();
            btnStart.Enabled = false;
            btnStop.Enabled = true;
            lblServer.Text = "Server je pokrenut!";
            server.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnStop.Enabled = false;
            lblServer.Text = "Server je zaustavljen";
            server.Stop();
        }
        private void FrmServer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
