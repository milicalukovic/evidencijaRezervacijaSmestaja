using Client.Model;
using Client.Session;
using Client.UserControls;
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

        public MesecniKalendarController(UCMesecniKalendar ucKalendar)
        {
            this.UC = ucKalendar;
            UC.Width = 220;
            UC.Height = 270;
            UC.Margin = new Padding(15);
        }
        public void InicijalizujKalendar(int month, int year, List<DateOnly> busyDates)
        {
            UC.TblKalendar.Controls.Clear();

            string[] naziviDana =
            {
                "pon", "uto", "sre",
                "cet", "pet", "sub", "ned"
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


            if (busyDates == null)
            {
                busyDates = new List<DateOnly>();
            }

            DateTime firstDay = new DateTime(year, month, 1);
            int startDayIndex = ((int)firstDay.DayOfWeek + 6) % 7; //jer je 0 nedelja, 1 ponedeljak; pretvorice 0 = pon
            int daysInMonth = DateTime.DaysInMonth(year, month);

            UC.LblMesec.Text = $"{(NazivMeseca)month} {year}. ";

            int dayCounter = 1;

            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    int cellIndex = i * 7 + j;

                    Label lblDay = new Label();
                    lblDay.AutoSize = false;
                    lblDay.Dock = DockStyle.Fill;

                    lblDay.TextAlign =
                        ContentAlignment.MiddleCenter;

                    lblDay.Font =
                        new Font(
                            "Segoe UI",
                            10,
                            FontStyle.Regular);

                    lblDay.Margin = new Padding(0);


                    // prazne ćelije pre početka meseca
                    if (cellIndex < startDayIndex || dayCounter > daysInMonth)
                    {
                        lblDay.Text = "";
                        lblDay.BackColor = Color.White;
                    }
                    else
                    {
                        DateOnly currentDate = new DateOnly(year, month, dayCounter);
                        lblDay.Text = dayCounter.ToString();

                        // PROVERA ZAUZETOSTI
                        if (busyDates.Contains(currentDate))
                        {
                            lblDay.BackColor = Color.LightCoral; // zauzeto
                        }
                        else
                        {
                            lblDay.BackColor = Color.White; // slobodno
                        }

                        dayCounter++;
                    }

                    UC.TblKalendar.Controls.Add(lblDay, j, i+1);
                }
            }
        }
    }
}
