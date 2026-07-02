using Client.Model;
using Client.Session;
using Client.UserControls;
using Common.Domain;
using Common.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.GuiController
{
    public class MesecniKalendarController
    {
        private UCMesecniKalendar UC;
        private ToolTip tooltip = new ToolTip();
        public MesecniKalendarController(UCMesecniKalendar ucKalendar)
        {
            this.UC = ucKalendar;
            UC.Width = 220;
            UC.Height = 270;
            UC.Margin = new Padding(15);
        }
        public void InicijalizujKalendar(int mesec, int godina, Dictionary<DateOnly, InfoRaspolozivosti> raspolozivostPoDatumu)
        {
            UC.TblKalendar.Controls.Clear();

            string[] naziviDana =
            {
                "pon", "uto", "sre",
                "čet", "pet", "sub", "ned"
            };

            for (int i = 0; i < 7; i++)
            {
                Label lblDan = new Label();

                lblDan.Text = naziviDana[i];
                lblDan.Dock = DockStyle.Fill;
                lblDan.TextAlign =
                    ContentAlignment.MiddleCenter;

                lblDan.Font =
                    new Font("Segoe UI", 6);

                lblDan.ForeColor =
                    Color.SaddleBrown;

                UC.TblKalendar.Controls.Add(lblDan, i, 0);
            }

            DateTime prviDan = new DateTime(godina, mesec, 1);
            int indeksPrvogDanaMeseca = ((int)prviDan.DayOfWeek + 6) % 7; //jer je 0 nedelja, 1 ponedeljak; pretvorice 0 = pon
            int daniUMesecu = DateTime.DaysInMonth(godina, mesec);

            UC.LblMesec.Text = $"{(NazivMeseca)mesec} {godina}. ";

            int brojDana = 1;


            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    int indeksCelije = i * 7 + j;

                    Label lblDan = new Label();
                    lblDan.AutoSize = false;
                    lblDan.Dock = DockStyle.Fill;

                    lblDan.TextAlign =
                        ContentAlignment.MiddleCenter;

                    lblDan.Font =
                        new Font(
                            "Segoe UI",
                            10,
                            FontStyle.Regular);

                    lblDan.Margin = new Padding(0);


                    // prazne ćelije pre početka meseca i posle kraja
                    if (indeksCelije < indeksPrvogDanaMeseca || brojDana > daniUMesecu)
                    {
                        lblDan.Text = "";
                        lblDan.BackColor = Color.White;
                    }
                    else
                    {
                        DateOnly trenutniDatum = new DateOnly(godina, mesec, brojDana);
                        lblDan.Text = brojDana.ToString();

                        // PROVERA ZAUZETOSTI
                        if (raspolozivostPoDatumu.ContainsKey(trenutniDatum))
                        {
                            InfoRaspolozivosti info =
                                raspolozivostPoDatumu[trenutniDatum];

                            switch (info.Status) 
                            { 
                                case StatusRaspolozivosti.PotpunoZauzeto:
                                    lblDan.BackColor = Color.LightCoral;
                                    tooltip.SetToolTip(lblDan, "Sve odgovarajuće smeštajne jedinice su zauzete.");
                                    break;

                                case StatusRaspolozivosti.DelimicnoZauzeto:
                                    lblDan.BackColor = Color.Khaki;
                                    tooltip.SetToolTip(lblDan, KreirajKomentar(info));
                                    break;

                                case StatusRaspolozivosti.Slobodno:

                                    lblDan.BackColor = Color.White;
                                    tooltip.SetToolTip(lblDan,KreirajKomentar(info));
                                    break;
                            }
                        }
                        else
                        {
                            lblDan.BackColor = Color.White;
                        }

                        brojDana++;
                    }

                    UC.TblKalendar.Controls.Add(lblDan, j, i+1);
                }
            }
        }

        private string KreirajKomentar(InfoRaspolozivosti info)
        {
            String komentar = "Raspoložive smeštajne jedinice:";

            foreach (var infoJedinica in info.SlobodneJedinice)
            {
                VrstaUsluge usluga;
                if ((int)info.IzabranaUsluga != 1)
                {
                    usluga = info.IzabranaUsluga;
                }
                else
                {
                    usluga = infoJedinica.SmestajnaJedinica.OsnovnaVrstaUsluge;
                }
                komentar +=
                    $"\n{infoJedinica.SmestajnaJedinica} ({usluga})" +
                    $" - {infoJedinica.IznosUsluge:N2} €";
            }

            return komentar;
        }
    }
}
