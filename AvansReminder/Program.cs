using Common.Domain;
using Server.Services;
using Server.SystemOperation.EvidencijaRezSO;

try
{
    VratiListuSviEvidencijaRezSO so = new VratiListuSviEvidencijaRezSO();

    so.ExecuteTemplate();

    List<EvidencijaRez> evidencije = so.ResultList;

    Console.WriteLine("Pokretanje...");
    Console.WriteLine($"Ucitan broj evidencija: {evidencije.Count}");

    NotifikacijaService servis = new NotifikacijaService();

    foreach (var evidencija in evidencije)
    {
        EmailService emailService = new EmailService();
        servis.PosaljiPodsetnikeZaAvans(evidencija, emailService);
    }

    Console.WriteLine("Podsetnici poslati.");
    Console.WriteLine("Kraj obrade.");
  //  Console.ReadKey();
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
   // Console.ReadKey();
}
