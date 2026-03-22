using Client.Forms;
using Client.Session;
using Common.Communication;
using Common.Domain;
using Common.Domain.enums;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.GuiController
{
    public class SmestajnaJedinicaFrmController
    {
        private FrmSmestajnaJedinica Frm;
        public SmestajnaJedinicaFrmController(FrmSmestajnaJedinica Frm)
        {
            this.Frm = Frm; 
        }

        internal void OtvoriFormu()
        {
            UcitajTipSmestaja();
            UcitajVrstaUsluge();
            if (Koordinator.Instance.ModeKreirajSJ) //novu sa kreiranim id
            {
                Frm.BtnPromeniSJ.Visible = false;
                Frm.BtnObrisiSJ.Visible = false;
            }
            else                                   //izmena postojece, prikaz postojecih podataka
            {
                SmestajnaJedinica izabrana = Koordinator.Instance.IzabranaSJ;
                Frm.CmbTip.SelectedItem = izabrana.Tip;
                Frm.TxtNaziv.Text = izabrana.Naziv;
                Frm.CmbOsnovnaVrstaUsluge.SelectedItem = izabrana.OsnovnaVrstaUsluge;
                Frm.NumericCenaPoOsobi.Value = izabrana.CenaPoOsobi;
                Frm.NumericPovecanjePoUsluzi.Value = izabrana.PovecanjeCenePoUsluzi;
                
                Frm.BtnKreirajSJ.Visible = false;
            }
            Frm.Show();
        }

        private void UcitajVrstaUsluge()
        {
            Frm.CmbOsnovnaVrstaUsluge.DataSource = Enum.GetValues(typeof(VrstaUsluge));
        }

        private void UcitajTipSmestaja()
        {
            List<TipSmestaja> lista = Koordinator.Instance.ListaTipSmestaja;
            Frm.CmbTip.DataSource = lista;
            Frm.CmbTip.DisplayMember = "Naziv"; //sta se prikazuje korisniku
            //Frm.CmbTip.ValueMember = "Id";      //sta je vrednost
        }

        internal void PromeniSmestajnaJedinica()
        {
            if (!Validacija())
            {
                return;
            }
            SmestajnaJedinica nova;
            if (Koordinator.Instance.ModeKreirajSJ)              //nova sa kreiranim id
            {
                nova = Koordinator.Instance.KreiranaSJ;
                nova.Vlasnik = Koordinator.Instance.UlogovaniVlasnik.KorisnickoIme;
            }
            else                                                  //izmena postojece
            {
                nova = Koordinator.Instance.IzabranaSJ;
            }
            //pokupi unete podatke
            nova.Naziv = Frm.TxtNaziv.Text.Trim(); ;
            nova.OsnovnaVrstaUsluge = (VrstaUsluge)Frm.CmbOsnovnaVrstaUsluge.SelectedItem;
            nova.CenaPoOsobi = (decimal)Frm.NumericCenaPoOsobi.Value;
            nova.PovecanjeCenePoUsluzi = (decimal)Frm.NumericPovecanjePoUsluzi.Value;
            nova.Tip = (TipSmestaja)Frm.CmbTip.SelectedItem;
            
            Odgovor serverOdg = Communication.Instance.PromeniSmestajnaJedinica(nova);
            if (serverOdg.ExceptionMessage != null)
            {
                MessageBox.Show(Frm, "Sistem ne moze da zapamti smestajnu jedinicu.", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (Koordinator.Instance.ModeKreirajSJ) //ako je kreirana a nije uspesno zapamcena obrisi je
                {
                    ObrisiSmestajnaJedinica();
                }
            }
            else
            {
                Koordinator.Instance.SmestajnaJedinicaUCController.AzurirajTabelu();  //DODAJ JE U TABELU UC PRIKAZ
                MessageBox.Show(Frm, "Sistem je zapamtio smestajnu jedinicu.", "USPESNO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //osvezi podatke
            Koordinator.Instance.IzabranaSJ = null;
            Koordinator.Instance.KreiranaSJ = null;
            Koordinator.Instance.ModeKreirajSJ = false;
            Frm.Close();

        }

        private bool Validacija()
        {
            if(Frm.TxtNaziv.Text.Trim().IsNullOrEmpty() || (decimal)Frm.NumericCenaPoOsobi.Value == 0)
            {
                MessageBox.Show(Frm, "Morate popuniti sva polja.", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            //ako se dodaje nova ili azurira naziv postojece proveri da li obj sa unetim nazivom za tog vlasnika vec postoji
            if (Koordinator.Instance.ModeKreirajSJ || !Koordinator.Instance.IzabranaSJ.Naziv.Equals(Frm.TxtNaziv.Text.Trim()))
            {
                SmestajnaJedinica sj = new SmestajnaJedinica();
                sj.Naziv = Frm.TxtNaziv.Text.Trim();
                sj.Vlasnik = Koordinator.Instance.UlogovaniVlasnik.KorisnickoIme;
                sj.Tip = Koordinator.Instance.ListaTipSmestaja.FirstOrDefault();

                sj.ProveriNaziv = true;
                //pretrazi obj
                Odgovor serverOdg = Communication.Instance.PretraziSmestajnaJedinica(sj);

                sj.ProveriNaziv = false; //osvezi

                if (serverOdg.ExceptionMessage == null && serverOdg.Result != null)
                {
                    MessageBox.Show(Frm, "Vec postoji sacuvana smestajna jedinica sa tim nazivom. Pokusaj ponovo!", "USPESNO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

            }
            return true;
        }

        internal void ObrisiSmestajnaJedinica()
        {
            Odgovor serverOdg;
            if (Koordinator.Instance.ModeKreirajSJ)
            {
                serverOdg = Communication.Instance.ObrisiSmestajnaJedinica(Koordinator.Instance.KreiranaSJ);
                //osvezi
                Koordinator.Instance.KreiranaSJ = null;
                Koordinator.Instance.ModeKreirajSJ = false;
            }
            else
            {
                serverOdg = Communication.Instance.ObrisiSmestajnaJedinica(Koordinator.Instance.IzabranaSJ);

                if (serverOdg.ExceptionMessage != null)
                {
                    MessageBox.Show(Frm, "Sistem ne moze da obrise smestajnu jedinicu.", "GRESKA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Koordinator.Instance.SmestajnaJedinicaUCController.AzurirajTabelu();  //OBRISI JE IZ TABELE UC PRIKAZ
                    MessageBox.Show(Frm, "Sistem je obrisao smestajnu jedinicu.", "USPESNO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //osvezi
                Koordinator.Instance.IzabranaSJ = null;
                //if (!Koordinator.Instance.ModeKreirajSJ)

                Frm.Close(); //jer kada pozove iz formClosing taj event vec zatvara formu (u suprotnom beskonacna rekurzija) 
                
            }

           
        }
    }
}
