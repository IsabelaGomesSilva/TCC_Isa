using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Model
{
    public class ProductModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; } = "";
         public decimal Description { get; set; } 
         [Column (TypeName = "decimal(18,2)")] 
        public decimal Price { get; set; }
        public  int CategoryId      { get; set; } // Categoria do produto 
        public int  Amount          { get; set; } // Quantidade de Produtos 
        // public url UrlImage         { get; set; } //Imagem do Produto
    }
}