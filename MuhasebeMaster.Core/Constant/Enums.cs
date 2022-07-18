using System.ComponentModel.DataAnnotations;

namespace MuhasebeMaster.Core.Constant
{
    public class Enums
    {
        public enum AccountType
        {
            [Display(Name="Müşteri")]
            Customer,
            [Display(Name = "Kiracı")]
            Tenant,
            [Display(Name = "Esnaf")]
            Trademen
        }

        public enum CostType
        {
            TL,
            DOLAR
        }
    }
}
