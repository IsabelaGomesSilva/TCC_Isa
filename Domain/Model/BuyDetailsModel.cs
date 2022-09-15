using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Model
{
    public class BuyDetailsModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string IdBuy { get; set; } = "";//Id da compra
        public string IdProduct { get; set; } = "";//Id do produto
        public int  AmountBuy { get; set; }// Quantidade comprada
        public decimal ValueUni { get; set; } 
         [Column (TypeName = "decimal(18,2)")]
        public decimal SubTotal { get; set; }
    }
}