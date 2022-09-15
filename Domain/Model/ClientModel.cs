namespace Domain.Model
{
    public class ClientModel
    {
       public string Id{ get; set; } = Guid.NewGuid().ToString();
       public string Name{ get; set; } = ""; //Nome do Cliente
       public DateTime Birth{ get; set; } //Aniversário do Cliente
       public string CPF{ get; set; } = ""; //Cpf do Cliente
       public string Email{ get; set; } = "";//E-mail do Cliente
       public string Password{ get; set; } = "";//Senha do Cliente
       public string Phone{ get; set; } = ""; //Telefone do Cliente
    }
}