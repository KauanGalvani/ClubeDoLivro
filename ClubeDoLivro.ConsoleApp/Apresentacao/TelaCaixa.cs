using System;
using ClubeDoLivro.ConsoleApp.Dominio;
using ClubeDoLivro.ConsoleApp.Infraestrutura;

namespace ClubeDoLivro.ConsoleApp.Apresentacao;

public class TelaCaixa
{
    private RepositorioCaixa repositorioCaixa;

    public TelaCaixa(RepositorioCaixa rC)
    {
        repositorioCaixa = rC;
    }
    public string? ObterOpcaoMenu()

    {
        Console.Clear();
        Console.WriteLine("================================");
        Console.WriteLine("        Gestão de caixas        ");
        Console.WriteLine("================================");
        Console.WriteLine("1 - Cadastrar caixas");
        Console.WriteLine("2 - Editar caixas");
        Console.WriteLine("3 - Excluir caixas");
        Console.WriteLine("4 - Visualizar caixas");
        Console.WriteLine("S - Voltar para o inicio");
        Console.WriteLine("================================");
        Console.Write("> ");
        string? opcaoMenu = Console.ReadLine()?.ToUpper();

        return opcaoMenu;
    }

    public void Cadastrar()
    {
        ExibirCabecalho("Cadastrar Caixa");

        Caixa novaCaixa = ObterDadosCadastrais();

        string[] erros = novaCaixa.Validar();

        if (erros.Length > 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < erros.Length; i++)
            {
                string erro = erros[i];

                Console.WriteLine(erro);
            }
            Console.ResetColor();
            Console.WriteLine("================================");
            Console.WriteLine("  Digite ENTER para continuar   ");
            Console.WriteLine("================================");
            Console.ReadLine();

            //recursão
            Cadastrar();
            return;
        }

        repositorioCaixa.Cadastrar(novaCaixa);
        Console.WriteLine("================================");
        Console.WriteLine($"O registro {novaCaixa.Id} foi cadastrada com sucesso!");
        Console.WriteLine("================================");
        Console.WriteLine("  Digite ENTER para continuar   ");
        Console.WriteLine("================================");
        Console.ReadLine();
    }

    public void Editar()
    {
        ExibirCabecalho("Edição da caixa");
        Caixa?[] caixas = repositorioCaixa.SelecionarTodos();

        for (int i = 0; i < caixas.Length; i++)
        {
            Caixa? c = caixas[i];

            if (c == null) continue;

            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -10} | {3, -20}",
                c.Id, c.Etiqueta, c.Cor, c.DiasDeEmprestimo
            );
        }

        string? idSelecionado;

        do
        {
            Console.WriteLine("Digite qual id deseja editar");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                break;

        } while (true);

        Caixa novaCaixa = ObterDadosCadastrais();

        bool conseguiuEditar = repositorioCaixa.Editar(idSelecionado, novaCaixa);

        if (!conseguiuEditar)
        {
            Console.WriteLine("================================");
            Console.WriteLine("Não foi possivel editar o registro!");
            Console.WriteLine("================================");
            Console.WriteLine("  Digite ENTER para continuar   ");
            Console.WriteLine("================================");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("================================");
            Console.WriteLine($"O registro {idSelecionado} foi editado com sucesso.");
            Console.WriteLine("================================");
            Console.WriteLine("  Digite ENTER para continuar   ");
            Console.WriteLine("================================");
            Console.ReadLine();
        }
    }

    public void Excluir()
    {
        Caixa?[] caixas = repositorioCaixa.SelecionarTodos();

        for (int i = 0; i < caixas.Length; i++)
        {
            Caixa? c = caixas[i];

            if (c == null) continue;

            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -10} | {3, -20}",
                c.Id, c.Etiqueta, c.Cor, c.DiasDeEmprestimo
            );
        }

        string? idSelecionado;

        do
        {
            Console.WriteLine("Digite qual id deseja excluir");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                break;

        } while (true);



        bool conseguiuExcluir = repositorioCaixa.Excluir(idSelecionado);

        if (!conseguiuExcluir)
        {
            Console.WriteLine("=================================");
            Console.WriteLine("Não foi possível encontrar o registro requisitado.");
            Console.WriteLine("=================================");
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("=================================");
        Console.WriteLine($"O registro \"{idSelecionado}\" foi excluído com sucesso.");
        Console.WriteLine("=================================");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
    }

    public void Visualizar(bool deveExibirCabecalho)
    {

        if (deveExibirCabecalho)
        ExibirCabecalho("Visualização de Caixas");

        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -10} | {3, -20}",
            "Id", "Etiqueta", "Cor", "Tempo de Empréstimo"
        );

        Caixa?[] caixas = repositorioCaixa.SelecionarTodos();

        for (int i = 0; i < caixas.Length; i++)
        {
            Caixa? c = caixas[i];

            if (c == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -10} | {3, -20}",
                c.Id, c.Etiqueta, c.Cor, c.DiasDeEmprestimo
            );
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("=================================");
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();
        }
    }

    public void ExibirCabecalho(string texto)
    {
        Console.WriteLine("================================");
        Console.WriteLine("        Gestão de caixas        ");
        Console.WriteLine("================================");
        Console.WriteLine($"{texto}             ");
        Console.WriteLine("================================");
    }

    private Caixa ObterDadosCadastrais()
    {
        Console.Write("Informe a etiqueta da caixa: ");
        string? etiqueta = Console.ReadLine();

        Console.WriteLine("================================");
        Console.WriteLine(" Selecione uma das cores validas");
        Console.WriteLine("================================");
        Console.WriteLine("1 - Vermelho");
        Console.WriteLine("2 - Verde");
        Console.WriteLine("3 - Azul");
        Console.WriteLine("4 - Braco (padrâo)");

        Console.Write("Informe a cor da caixa: ");
        string? codigoCor = Console.ReadLine();

        string cor;

        if (codigoCor == "1") cor = "Vermelho";
        else if (codigoCor == "2") cor = "Verde";
        else if (codigoCor == "3") cor = "Azul";
        else cor = "Branco";

        Console.Write("Informe o tempo de emprestimo das revistas da caixa: ");
        int diasDeEmprestimo = Convert.ToInt32(Console.ReadLine());

        Caixa novaCaixa = new Caixa(etiqueta, cor, diasDeEmprestimo);

        return novaCaixa;
    }
}
