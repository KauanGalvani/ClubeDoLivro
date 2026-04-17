using ClubeDaLeitura.ConsoleApp.Apresentacao;
using ClubeDoLivro.ConsoleApp.Apresentacao;
using ClubeDoLivro.ConsoleApp.Dominio;
using ClubeDaLeitura.ConsoleApp.Infraestrutura;
using ClubeDaLeitura.ConsoleApp.Dominio;

namespace ClubeDoLivro.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //'Caixa caixaTeste = new Caixa();
            RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
            RepositorioRevista repositorioRevista = new RepositorioRevista();

            TelaCaixa telaCaixa = new TelaCaixa(repositorioCaixa);
            telaCaixa.nomeEntidade = "Caixa";
            TelaRevista telaRevista = new TelaRevista(repositorioRevista, repositorioCaixa);
            telaRevista.nomeEntidade = "Revista";

            Caixa caixa = new Caixa("Lançameto", "Vermelho", 3);

            Revista revista = new Revista("Comics Animation", 324, 1999, caixa);

            EntidadeBase entidade = caixa;

            entidade.AtualizarRegistro(revista);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("================================");
                Console.WriteLine("        Clube da Leitura        ");
                Console.WriteLine("================================");
                Console.WriteLine("1 - Gerenciar caixas de revistas");
                Console.WriteLine("2 - Gerenciar revistas");
                Console.WriteLine("3 - Gerenciar amigos");
                Console.WriteLine("4 - Gerenciar empréstimos");
                Console.WriteLine("S - Sair");
                Console.WriteLine("================================");
                Console.Write("> ");
                string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();

                if (opcaoMenuPrincipal == "S")
                {
                    Console.Clear();
                    break;
                }

                while (true)
                {
                    string? opcaoMenuInterno = string.Empty;

                    if (opcaoMenuPrincipal == "1")
                    {
                        opcaoMenuInterno = telaCaixa.ObterOpcaoMenu();

                        if (opcaoMenuInterno == "S")
                        {
                            Console.Clear();
                            break;
                        }

                        if (opcaoMenuInterno == "1")
                        {
                            telaCaixa.Cadastrar();
                        }
                        else if (opcaoMenuInterno == "2")
                        {
                            telaCaixa.Editar();
                        }
                        else if (opcaoMenuInterno == "3")
                        {
                            telaCaixa.Excluir();
                        }
                        else if (opcaoMenuInterno == "4")
                        {
                            telaCaixa.VisualizarTodos(deveExibirCabecalho: true);
                        }
                    }

                    else if (opcaoMenuPrincipal == "2")
                    {
                        telaRevista.Cadastrar();
                    }
                    else if (opcaoMenuInterno == "2")
                    {
                        telaRevista.Editar();
                    }
                    else if (opcaoMenuInterno == "3")
                    {
                        telaRevista.Excluir();
                    }
                    else if (opcaoMenuInterno == "4")
                    {
                        telaRevista.VisualizarTodos(deveExibirCabecalho: true);
                    }


                    else if (opcaoMenuPrincipal == "3")
                    {

                    }

                    else if (opcaoMenuPrincipal == "4")
                    {

                    }
                }
            }
        }
    }
}