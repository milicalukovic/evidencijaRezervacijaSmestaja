using Client.Forms;
using Client.Session;
using Client.UserControls;
using Common.Communication;
using Common.Domain;
using Common.Domain.enums;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.GuiController
{
    public class SmestajnaJedinicaUCController
    {
        private UCPrikazSmestajnaJedinica UCPrikaz;
        public SmestajnaJedinicaUCController(UCPrikazSmestajnaJedinica UCPrikaz) 
        {
            this.UCPrikaz = UCPrikaz;
        }

        internal void PopuniPodatke()
        {
            UcitajTipSmestaja();
            UCPrikaz.CmbTipSmestaja.Visible = false;
            UCPrikaz.CmbSmestajnaJedinica.Visible = false;
            PopuniTabelu(); //pravi kolone i postavlja DataSource
        }

        internal void PopuniTabelu()
        {

            UCPrikaz.DgvSmestajnaJedinica.AutoGenerateColumns = false;        //ne pravi sam kolone
            UCPrikaz.DgvSmestajnaJedinica.Columns.Clear();                     //reset
            UCPrikaz.DgvSmestajnaJedinica.DataSource = null;


            UCPrikaz.DgvSmestajnaJedinica.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Naziv",                                            //naslov
                DataPropertyName = "Naziv",                                      //vrednost uzima iz tog atributa objekta
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            UCPrikaz.DgvSmestajnaJedinica.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Osnovna vrsta usluge",
                DataPropertyName = "OsnovnaVrstaUsluge",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            UCPrikaz.DgvSmestajnaJedinica.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Cena po osobi",
                DataPropertyName = "CenaPoOsobi",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            UCPrikaz.DgvSmestajnaJedinica.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Povecanje cene po usluzi",
                DataPropertyName = "PovecanjeCenePoUsluzi",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            UCPrikaz.DgvSmestajnaJedinica.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "tipNaziv",
                HeaderText = "Tip smestaja",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            UCPrikaz.DgvSmestajnaJedinica.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "minKapacitet",
                HeaderText = "Min Kapacitet",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            UCPrikaz.DgvSmestajnaJedinica.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "maxKapacitet",
                HeaderText = "Max kapacitet",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            UCPrikaz.DgvSmestajnaJedinica.DataSource = AzurirajSmestajneJedinice();

            UCPrikaz.DgvSmestajnaJedinica.CellFormatting += FormatirajTabelu; //za vrednosti u tabeli koje nisu direktno iz klase SJ (iz obj TipSmestaja)


        }
        private void FormatirajTabelu(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (UCPrikaz.DgvSmestajnaJedinica.Rows[e.RowIndex].DataBoundItem is SmestajnaJedinica sj)
            {
                if (UCPrikaz.DgvSmestajnaJedinica.Columns[e.ColumnIndex].Name == "tipNaziv")
                {
                    e.Value = sj.Tip?.Naziv;
                }

                if (UCPrikaz.DgvSmestajnaJedinica.Columns[e.ColumnIndex].Name == "minKapacitet")
                {
                    e.Value = sj.Tip?.MinKapacitet;
                }
                if (UCPrikaz.DgvSmestajnaJedinica.Columns[e.ColumnIndex].Name == "maxKapacitet")
                {
                    e.Value = sj.Tip?.MaxKapacitet;
                }
            }
        }
        private List<SmestajnaJedinica> AzurirajSmestajneJedinice()
        {
            List<SmestajnaJedinica> lista = new List<SmestajnaJedinica>();
            SmestajnaJedinica sj = new SmestajnaJedinica();
            sj.Vlasnik = Koordinator.Instance.UlogovaniVlasnik.KorisnickoIme;
            sj.Tip = Koordinator.Instance.ListaTipSmestaja.FirstOrDefault();

            Odgovor serverOdg = Communication.Instance.VratiListuSviSmestajnaJedinica(sj);
            if (serverOdg.ExceptionMessage == null && serverOdg.Result != null)
            {
                lista = (List<SmestajnaJedinica>)serverOdg.Result;
                Koordinator.Instance.ListaSmestajnaJedinica = lista;
            }
            return lista;
        }

        private void UcitajTipSmestaja()
        {
            TipSmestaja tip = new TipSmestaja();

            Odgovor serverOdg = Communication.Instance.VratiListuSviTipSmestaja(tip);
            if (serverOdg.ExceptionMessage == null && serverOdg.Result != null)
            {
                List<TipSmestaja> lista = (List<TipSmestaja>)serverOdg.Result;
                Koordinator.Instance.ListaTipSmestaja = lista;
            }
        }
        internal void PrikaziCmbTip() //kada nije selekotvan check box visible false
        {
            if (UCPrikaz.CbTipSmestaja.Checked)
            {
                UCPrikaz.CmbTipSmestaja.DataSource = Koordinator.Instance.ListaTipSmestaja;
                UCPrikaz.CmbTipSmestaja.DisplayMember = "Naziv";
                UCPrikaz.CmbTipSmestaja.Visible = true;
            }
            else
            {
                UCPrikaz.CmbTipSmestaja.Visible = false;
            }
        }

        internal void PrikaziCmbSJ()
        {
            if (UCPrikaz.CbSmestajnaJedinica.Checked)
            {
                UCPrikaz.CmbSmestajnaJedinica.DataSource = Enum.GetValues(typeof(VrstaUsluge));
                UCPrikaz.CmbSmestajnaJedinica.Visible = true;
            }
            else
            {
                UCPrikaz.CmbSmestajnaJedinica.Visible = false;
            }
        }

        

        internal void KreirajSmestajnaJedinica()
        {
            SmestajnaJedinica sj = new SmestajnaJedinica();
            sj.Vlasnik = Koordinator.Instance.UlogovaniVlasnik.KorisnickoIme;
            sj.Tip = Koordinator.Instance.ListaTipSmestaja.FirstOrDefault();

            Odgovor serverOdg = Communication.Instance.KreirajSmestajnaJedinica(sj);
            if (serverOdg.ExceptionMessage == null && serverOdg.Result != null)
            {
                SmestajnaJedinica nova = serverOdg.Result as SmestajnaJedinica;
                Koordinator.Instance.KreiranaSJ = nova;
                MessageBox.Show(UCPrikaz, "Sistem je kreirao smestajnu jedinicu.", "USPESNO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Koordinator.Instance.ModeKreirajSJ = true;
                Koordinator.Instance.OtvoriFrmSmestajnaJedinica();
            }
            else
            {
                MessageBox.Show(UCPrikaz, "Sistem ne moze da kreira smestajnu jedinicu.", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal void PrikaziSmestajneJedinice()
        {
            if (!UCPrikaz.CbSmestajnaJedinica.Checked && !UCPrikaz.CbTipSmestaja.Checked)
            {
                return;
            }
            SmestajnaJedinica filtrirana = new SmestajnaJedinica();
            filtrirana.Vlasnik = Koordinator.Instance.UlogovaniVlasnik.KorisnickoIme;
            if (UCPrikaz.CbSmestajnaJedinica.Checked)
            {
                filtrirana.OsnovnaVrstaUsluge = (VrstaUsluge)UCPrikaz.CmbSmestajnaJedinica.SelectedItem;
                filtrirana.FilterPoUsluzi = true;
            }
            if (UCPrikaz.CbTipSmestaja.Checked)
            {
                filtrirana.Tip = (TipSmestaja)UCPrikaz.CmbTipSmestaja.SelectedItem;
                filtrirana.FilterPoTipu = true;
            }
            Debug.WriteLine("WHERE: " + filtrirana.WhereClause);

            if (!Koordinator.Instance.ListaSmestajnaJedinica.IsNullOrEmpty())
            {
                Odgovor serverOdg = Communication.Instance.VratiListuSmestajnaJedinica(filtrirana);
                if (serverOdg.ExceptionMessage == null && serverOdg.Result != null)
                {
                    List<SmestajnaJedinica> lista = (List<SmestajnaJedinica>)serverOdg.Result;
                    if (!lista.IsNullOrEmpty())
                    {
                        MessageBox.Show(UCPrikaz, "Sistem je nasao smestajne jedinice po zadatim kriterijumima.", "USPESNO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UCPrikaz.DgvSmestajnaJedinica.DataSource = null;
                        UCPrikaz.DgvSmestajnaJedinica.DataSource = lista;
                    }
                    else
                    {
                        MessageBox.Show(UCPrikaz, "Sistem ne moze da nadje smestajne jedinice po zadatim kriterijumima.", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //ako je vec bila filtrirana a nije restartovana pre ovog kriterijuma
                        UCPrikaz.DgvSmestajnaJedinica.DataSource = null;
                        UCPrikaz.DgvSmestajnaJedinica.DataSource = Koordinator.Instance.ListaSmestajnaJedinica;
                        UCPrikaz.CbSmestajnaJedinica.Checked = false;
                        UCPrikaz.CbTipSmestaja.Checked = false;
                    }
                }

            }
        }
        internal void IzabranaSJ(int rowIndex)
        {
            if (rowIndex < 0)
            {
                //kada izadje (na X) iz forme za izmenu ne osvezi se izabrana 
                Koordinator.Instance.IzabranaSJ = null;
            }
            else
            {
                Koordinator.Instance.IzabranaSJ = UCPrikaz.DgvSmestajnaJedinica.Rows[rowIndex].DataBoundItem as SmestajnaJedinica;
            }
        }
                
        internal void PretraziSmestajnaJedinica()
        {
            if(Koordinator.Instance.IzabranaSJ == null)
            {
                MessageBox.Show(UCPrikaz, "Morate izabrati smestajnu jedinicu.", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Koordinator.Instance.IzabranaSJ.PretraziSJ = true;
            Odgovor serverOdg = Communication.Instance.PretraziSmestajnaJedinica(Koordinator.Instance.IzabranaSJ);

            if (serverOdg.ExceptionMessage == null && serverOdg.Result != null)
            {
                MessageBox.Show(UCPrikaz, "Sistem je nasao smestajnu jedinicu.", "USPESNO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Koordinator.Instance.OtvoriFrmSmestajnaJedinica();
            }
            else
            {
                MessageBox.Show(UCPrikaz, "Sistem ne moze da nadje smestajnu jedinicu.", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Koordinator.Instance.IzabranaSJ.PretraziSJ = false;
        }

        internal void AzurirajTabelu()
        {
            UCPrikaz.DgvSmestajnaJedinica.DataSource = null;
            UCPrikaz.DgvSmestajnaJedinica.DataSource = AzurirajSmestajneJedinice();

            //ako je restart dugme
            UCPrikaz.CbSmestajnaJedinica.Checked = false;
            UCPrikaz.CbTipSmestaja.Checked = false;
        }
    }
}
