using ClubeDoLivro.ConsoleApp.Apresentacao;
using ClubeDoLivro.ConsoleApp.Dominio;

//Caixa caixaTeste = new Caixa();

TelaCaixa telaCaixa = new TelaCaixa();

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
                telaCaixa.Visualizar();
            }
        }

        else if (opcaoMenuPrincipal == "2")
        {

        }

        else if (opcaoMenuPrincipal == "3")
        {

        }

        else if (opcaoMenuPrincipal == "4")
        {

        }
    }
}