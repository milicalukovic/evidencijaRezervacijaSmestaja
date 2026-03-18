using Client.Session;
using System.Diagnostics;
using System.Net.Sockets;

namespace Client
{
    public partial class FrmPrijaviVlasnik : Form
    {
        public FrmPrijaviVlasnik()
        {
            InitializeComponent();
        }
        private void btnPrijavi_Click(object sender, EventArgs e)
        {
            Koordinator.Instance.PrijaviVlasnikGUIController.PrijaviVlasnik();
        }
        private void FrmPrijaviVlasnik_Load(object sender, EventArgs e)
        {
            try
            {
                Communication.Instance.Connect();
                Debug.WriteLine("Konektovani na server");
            }
            catch (SocketException ex)
            {

                Debug.WriteLine(ex.Message);
                return;
            }
        }

    }
}
