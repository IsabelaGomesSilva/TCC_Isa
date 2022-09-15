namespace Domain.Model
{
    public class BuyModel
    {
          public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime Date { get; set; } //Data da compra 
        public decimal ValueTotal { get; set; } // Valor total da compra
     //   [Column (TypeName = "decimal(18,2)")]
        public string  IdProduct { get; set; } = "";
        public string  IdProvider { get; set;} = ""; // Id do Fornecedor 
   
    }
}