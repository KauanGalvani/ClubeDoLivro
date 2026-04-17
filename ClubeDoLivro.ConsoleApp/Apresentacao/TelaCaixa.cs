using System;
using ClubeDaLeitura.ConsoleApp.Infraestrutura;
using ClubeDoLivro.ConsoleApp.Dominio;


namespace ClubeDoLivro.ConsoleApp.Apresentacao;

public class TelaCaixa : TelaBase
{
    private RepositorioCaixa repositorioCaixa;

    public TelaCaixa(RepositorioCaixa rC) : base("Caixa", rC)
    {
        repositorioCaixa = rC;
    }




    public override void VisualizarTodos(bool deveExibirCabecalho)
    {

        if (deveExibirCabecalho)
            ExibirCabecalho("Visualização de Caixas");

        Console.WriteLine(
            "{0, -7} | {1, -20} | {2, -10} | {3, -20}",
            "Id", "Etiqueta", "Cor", "Tempo de Empréstimo"
        );

        EntidadeBase?[] caixas = repositorioCaixa.SelecionarTodos();

        for (int i = 0; i < caixas.Length; i++)
        {
            Caixa? c = (Caixa?)caixas[i];

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

    protected override EntidadeBase ObterDadosCadastrais()
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
