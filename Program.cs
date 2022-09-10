using System.Diagnostics;
using matheus_d3_avaliacao.Model;
using matheus_d3_avaliacao.Repository;

namespace matheus_d3_avaliacao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            LogRepository logRepository = new LogRepository();
            
            User user = new();

            string option;
            do
            {
                Console.WriteLine("\nEscolha uma das opções abaixo:\n");
                Console.WriteLine("1 - Logar");
                Console.WriteLine("2 - Cancelar");

                option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("\nDigite seu e-mail: ");
                        var email = Console.ReadLine();
                        Console.WriteLine("\nDigite sua senha: ");
                        var senha = Console.ReadLine();
                        if (email == null || !(email.Contains("@")) || senha == null || !(senha.Length >= 3))
                        {
                            Console.WriteLine("\nE-mail ou senha inválidos!");
                        }
                        else
                        {
                            List<User> users = new UserRepository().GetUsers();

                            if (users.Exists(x => x.Email == email && x.Senha == senha))
                            {
                                User userLogged = users.Find(x => x.Email == email && x.Senha == senha);
                                
                                logRepository.RegisterAccess(userLogged, "in");
                                Console.WriteLine("\nLogin realizado com sucesso. Escolha uma opção abaixo:\n");
                                Console.WriteLine("1 - Deslogar");
                                Console.WriteLine("2 - Encerrar");

                                string optionLogin;
                                optionLogin = Console.ReadLine();

                                switch (optionLogin)
                                {
                                    case "1":
                                        logRepository.RegisterAccess(userLogged, "out");
                                        Console.WriteLine("\nDeslogado com sucesso!");
                                        option = "1";
                                        break;
                                    case "2":
                                        option = "2";
                                        break;
                                    default:
                                        Console.WriteLine("\nOpção inválida!");
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nE-mail ou senha inválidos!");
                            }
                        } 

                        break;
                    
                }
            } while (option != "2");
            Console.WriteLine("\nSistema encerrado!");
            
        }
    }
}