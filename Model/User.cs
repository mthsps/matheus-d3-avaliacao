namespace matheus_d3_avaliacao.Model;

public class User
{
    public string Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; } 
    public string Senha { get; set; }
    
    public User() { }

    public User(string id, string nome, string email, string senha)
    {
        Id = id;
        Nome = nome;
        Email = email;
        Senha = senha;
    }

}