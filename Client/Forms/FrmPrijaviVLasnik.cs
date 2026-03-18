using Client.Session;

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
        private void btnRegistruj_Click(object sender, EventArgs e)
        {
            Koordinator.Instance.OtvoriFrmRegistujVlasnik();
        }
        private void FrmPrijaviVlasnik_Load(object sender, EventArgs e)
        {

        }

    }
}
