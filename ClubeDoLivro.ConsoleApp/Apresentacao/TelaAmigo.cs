using System;
using ClubeDoLivro.ConsoleApp.Dominio;
using ClubeDoLivro.ConsoleApp.Infraestrutura;

namespace ClubeDoLivro.ConsoleApp.Apresentacao;

public class TelaAmigo : TelaBase
{

    private RepositorioAmigo repositorioAmigo;

    public TelaAmigo(RepositorioAmigo repositorioAmigo) : base("amigo", repositorioAmigo)
    {
        this.repositorioAmigo = repositorioAmigo;
    }

    public override void VisualizarTodos(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
            ExibirCabecalho("Visualização de Caixas");

        Console.WriteLine(
            "{0, -7} | {1, -15} | {2, -15} | {3, -13}",
            "Id", "Nome", "Responsavel", "Telefone"
        );

        EntidadeBase?[] amigo = repositorioAmigo.SelecionarTodos();

        for (int i = 0; i < amigo.Length; i++)
        {
            Amigo? a = (Amigo?)amigo[i];

            if (a == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -10} | {3, -20}",
                a.Id, a.Nome, a.NomeResponsavel, a.Telefone
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
        Console.Write("");
        string nome = Console.ReadLine() ?? string.Empty;

        Console.Write("");
        string nomeResponsavel = Console.ReadLine() ?? string.Empty;

        Console.Write("");
        string telefone = Console.ReadLine() ?? string.Empty;

        return new Amigo(nome, nomeResponsavel, telefone);
    }
}
