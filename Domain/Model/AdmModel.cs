namespace Infra.Data.Model
{
    public class AdmModel
    {
        
         public string Id { get; set; } = Guid.NewGuid().ToString();
         public string Name { get; set; } = ""; //Nome do Adm
         public string Email { get; set; }  = "";//E-mail do Adm
         public string Password  { get; set; } = ""; //Senha do Adm
    }
}