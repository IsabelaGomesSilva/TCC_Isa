using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class OrderDetails
    {
        
        public string Id  { get; set; } = Guid.NewGuid().ToString();
        public string IdOrder { get; set; } = "";
        public string  IdProduct { get; set; } = "";
        public int AmountOrder { get; set; }
        public int MyProperty { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal ValueUni { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal SubTotal { get; set; }
    }
}