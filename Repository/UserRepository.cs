using System.Data.SqlClient;
using matheus_d3_avaliacao.Interface;
using matheus_d3_avaliacao.Model;

namespace matheus_d3_avaliacao.Repository;

public class UserRepository : IUser
{

    private readonly string databaseConnection =
        "Server=labsoft.pcs.usp.br;Database=db_19;User Id=usuario_19;Password=;";
        
    public List<User> GetUsers()
    {
        List<User> users = new();

        using (SqlConnection con = new SqlConnection(databaseConnection))
        {
            string querySelect = "SELECT * FROM users";
            con.Open();

            SqlDataReader rdr;
            using (SqlCommand command = new SqlCommand(querySelect, con))
            {
                rdr = command.ExecuteReader();

                while (rdr.Read())
                {
                    User user = new User()
                    {
                        Id = rdr["user_id"].ToString(), 
                        Nome = rdr["name"].ToString(),
                        Email = rdr["email"].ToString(),
                        Senha = rdr["password"].ToString(),
                    };

                    users.Add(user);
                }
            }
        }
        return users;
    }


    public User GetUser(string username, string password)
    {
        throw new NotImplementedException();
    }
}