using System;
using ClubeDaLeitura.ConsoleApp.Dominio;
using ClubeDaLeitura.ConsoleApp.Infraestrutura;
using ClubeDoLivro.ConsoleApp.Dominio;
using ClubeDoLivro.ConsoleApp.Infraestrutura;

namespace ClubeDoLivro.ConsoleApp.Apresentacao;

public class TelaEmprestimo
{

    RepositorioEmprestimo repositorioEmprestimo = new RepositorioEmprestimo();
    private RepositorioRevista? repositorioRevista;
    private RepositorioAmigo? repositorioAmigo;
    public TelaEmprestimo(
        RepositorioEmprestimo repositorioEmprestimo,
        RepositorioRevista repositorioRevista,
        RepositorioAmigo repositorioAmigo
    )
    {
        this.repositorioEmprestimo = repositorioEmprestimo;
        this.repositorioRevista = repositorioRevista;
        this.repositorioAmigo = repositorioAmigo;
    }

    public void Abrir()
    {
        Emprestimo emprestimo = ObeterDadosCadastrais();

        string[] erros = emprestimo.Validar();

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
            emprestimo.Abrir();
            return;
        }
        repositorioEmprestimo.Cadastrar(emprestimo);
    }
    public Emprestimo ObeterDadosCadastrais()
    {
        VisualizarRevistas();

        string? idSelecionado;

        Revista? revista = null;
        Amigo? amigo = null;
        do
        {
            Console.Write("Digite o ID da caixa em que deseja guardar a revista: ");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                revista = (Revista?)repositorioRevista.SelecionarPorId(idSelecionado);
        } while (revista == null);
        return new Emprestimo(revista, amigo);
    }

    public void VisualizarRevistas()
    {
        Console.WriteLine(
            "{0, -7} | {1, -25} | {2, -6} | {3, -4} | {4, -15}",
            "Id", "Título", "Edição", "Ano", "Caixa"
        );

        EntidadeBase?[] revistas = repositorioRevista.SelecionarTodos();

        for (int i = 0; i < revistas.Length; i++)
        {
            Revista? r = (Revista?)revistas[i];

            if (r == null)
                continue;

            Console.Write("{0, -7} | ", r.Id);
            Console.Write("{0, -25} | ", r.Titulo);
            Console.Write("{0, -6} | ", r.NumeroEdicao);
            Console.Write("{0, -4} | ", r.AnoPublicacao);

            string corSelecionada = r.Caixa.Cor;

            if (corSelecionada == "Vermelho")
                Console.ForegroundColor = ConsoleColor.Red;

            else if (corSelecionada == "Verde")
                Console.ForegroundColor = ConsoleColor.Green;

            else if (corSelecionada == "Azul")
                Console.ForegroundColor = ConsoleColor.Blue;

            Console.Write("{0, -15}", r.Caixa.Etiqueta);

            Console.ResetColor();
            Console.WriteLine();
        }

        Console.WriteLine("=======================================");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();

    }

    public void VisualizarTodos()
    {
        Console.WriteLine(
            "{0, -7} | {1, -15} | {2, -10} | {3, -10} | {4, -15} | {5, -10}",
            "Id", "Revista", "Amigo", "Abertura", "Conclusão Prev.", "Status"
        );

        Emprestimo?[] emprestimo = repositorioEmprestimo.SelecionarTodos();

        for (int i = 0; i < emprestimo.Length; i++)
        {
            Emprestimo? a = (Emprestimo?)emprestimo[i];

            if (a == null)
                continue;

            Console.WriteLine(
                "{0, -7} | {1, -20} | {2, -10} | {3, -20}",
                a.Id, a.Revista, a.Amigo, a.Abertura, a.Conclusao
            );
        }

        Console.WriteLine("=================================");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();

    }

    public string? ObterOpcaoMenu()
    {
        Console.Clear();
        Console.WriteLine("================================");
        Console.WriteLine($"Gestão de emprestimo");
        Console.WriteLine("================================");
        Console.WriteLine($"1 - Abrir empréstimo");
        Console.WriteLine($"2 - Concluir empréstimo");
        Console.WriteLine($"3 - Visualizar empréstimo");
        Console.WriteLine($"S - Voltar para o inicio");
        Console.WriteLine("================================");
        Console.Write("> ");
        string? opcaoMenu = Console.ReadLine()?.ToUpper();

        return opcaoMenu;
    }

}
