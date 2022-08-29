using System.ComponentModel.DataAnnotations;

namespace MuhasebeMaster.Core.Constant
{
    public class Enums
    {
        public enum AccountType
        {
            [Display(Name="Müşteri")]
            Musteri,
            [Display(Name = "Kiracı")]
            Kiraci,
            [Display(Name = "Esnaf")]
            Esnaf
        }

        public enum CostType
        {
            TL,
            DOLAR
        }

        public enum PaymentType
        {
            Kart,
            Nakit,
            Cek_Senet
        }

        public enum SalesType
        {
            Tahsilat,
            Alacak
        }

    }
}
