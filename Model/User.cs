namespace matheus_d3_avaliacao.Model;

public class User
{
    private Guid Id { get; set; } = Guid.NewGuid();
    private string Nome { get; set; } = string.Empty;
    private string Email { get; set; } = string.Empty;
    private string Senha { get; set; } = string.Empty;
    
    public Guid GetId()
    {
        return Id;
    }
    
    public string GetNome()
    {
        return Nome;
    }
    
    public string GetEmail()
    {
        return Email;
    }
    
    public string GetSenha()
    {
        return Senha;
    }
    
    public void SetNome(string nome)
    {
        Nome = nome;
    }
    
    public void SetEmail(string email)
    {
        Email = email;
    }
    
    
       public void SetSenha(string senha)
    {
        Senha = senha;
    } 
    
    
}