using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entity
{
    public class Order
    {
        public string Id           { get; set; } = Guid.NewGuid().ToString();

       public decimal ValueTotal  { get; set; } //Valor total do Pedido
       [Column(TypeName = "decimal(18,2)")]

       public DateTime Date       { get; set; } //Data e hora do Pedido

       public string IdPayment { get; set; } = ""; //Forma de Pagamento do Pedido

       public string IdClient { get; set; } = ""; // Id do Cliente  
    }
}