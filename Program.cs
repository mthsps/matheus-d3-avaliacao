using System.Diagnostics;
using matheus_d3_avaliacao.Model;
using matheus_d3_avaliacao.Repository;
using matheus_d3_avaliacao.Security;

namespace matheus_d3_avaliacao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            LogRepository logRepository = new LogRepository();

            string option;
            do
            {
                Console.WriteLine("\nEscolha uma das opções abaixo:\n");
                Console.WriteLine("1 - Logar");
                Console.WriteLine("2 - Cadastrar");
                Console.WriteLine("3 - Sair do sistema");

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
                            UserRepository userRepository = new UserRepository();
                            
                            senha = Encryption.Encrypt(senha);
                            User userLogged = userRepository.GetUser(email, senha);

                            if (userLogged.Email == email)
                            {
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
                                        option = "3";
                                        break;
                                    default:
                                        Console.WriteLine("\nOpção inválida!");
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("\nE-mail ou senha inválidos ou inexistentes!");
                            }
                        } 

                        break;
                    
                    case "2":
                        User createUser = new();
                        Console.WriteLine("\nDigite seu nome: ");
                        createUser.Name = Console.ReadLine();
                        Console.WriteLine("\nDigite seu e-mail: ");
                        createUser.Email = Console.ReadLine();
                        Console.WriteLine("\nDigite sua senha: ");
                        createUser.Password = Console.ReadLine();
                        if (createUser.Name == null || createUser.Email == null || !(createUser.Email.Contains("@")) || createUser.Password == null || !(createUser.Password.Length >= 3))
                        {
                            Console.WriteLine("\nDados inválidos!");
                        }
                        else
                        {
                            createUser.Password =  Encryption.Encrypt(createUser.Password);
                            new UserRepository().CreateUser(createUser);
                            Console.WriteLine("\nUsuário cadastrado com sucesso!");
                        }
                        break;
                    
                }
            } while (option != "3");
            Console.WriteLine("\nSistema encerrado!");
            
        }
    }
}