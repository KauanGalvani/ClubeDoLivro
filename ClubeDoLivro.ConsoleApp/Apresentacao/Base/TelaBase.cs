using System;
using ClubeDoLivro.ConsoleApp.Dominio;
using ClubeDoLivro.ConsoleApp.Infraestrutura;

namespace ClubeDoLivro.ConsoleApp.Apresentacao;

public abstract class TelaBase
{

    private RepositorioBase repositorio;
    public string nomeEntidade = string.Empty;

    protected TelaBase(string nomeEntidade, RepositorioBase repositorio)
    {
        this.nomeEntidade = nomeEntidade;
        this.repositorio = repositorio;
    }
    protected void ExibirCabecalho(string titulo)
    {
        Console.Clear();
        Console.WriteLine("==================================");
        Console.WriteLine("Gestão de Caixas");
        Console.WriteLine("==================================");
        Console.WriteLine(titulo);
        Console.WriteLine("==================================");
    }

    protected void ExibirMensagem(string mensagem)
    {
        Console.WriteLine("==================================");
        Console.WriteLine(mensagem);
        Console.WriteLine("==================================");
        Console.Write("Digite ENTER para continuar...");
        Console.ReadLine();
    }

    public abstract void VisualizarTodos(bool deveExibirCabecalho);

    public string? ObterOpcaoMenu()
    {
        string nomeMinusculo = nomeEntidade.ToLower();
        Console.Clear();
        Console.WriteLine("================================");
        Console.WriteLine($"Gestão de {nomeMinusculo}");
        Console.WriteLine("================================");
        Console.WriteLine($"1 - Cadastrar {nomeMinusculo}");
        Console.WriteLine($"2 - Editar {nomeMinusculo}");
        Console.WriteLine($"3 - Excluir {nomeMinusculo}");
        Console.WriteLine($"4 - Visualizar {nomeMinusculo}");
        Console.WriteLine($"S - Voltar para o inicio");
        Console.WriteLine("================================");
        Console.Write("> ");
        string? opcaoMenu = Console.ReadLine()?.ToUpper();

        return opcaoMenu;
    }

    public void Cadastrar()
    {
        ExibirCabecalho($"Cadastrar de {nomeEntidade}");

        EntidadeBase novaEntidade = ObterDadosCadastrais();

        string[] erros = novaEntidade.Validar();

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

        repositorio.Cadastrar(novaEntidade);
        Console.WriteLine("================================");
        Console.WriteLine($"O registro {novaEntidade.Id} foi cadastrada com sucesso!");
        Console.WriteLine("================================");
        Console.WriteLine("  Digite ENTER para continuar   ");
        Console.WriteLine("================================");
        Console.ReadLine();
    }

    public void Editar()
    {
        ExibirCabecalho($"Edição da {nomeEntidade}");
        EntidadeBase?[] caixas = repositorio.SelecionarTodos();

        for (int i = 0; i < caixas.Length; i++)
        {
            Caixa? c = (Caixa?)caixas[i];

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

        EntidadeBase novaCaixa = ObterDadosCadastrais();

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
            Editar();
            return;
        }

        bool conseguiuEditar = repositorio.Editar(idSelecionado, novaCaixa);

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
        EntidadeBase?[] caixas = repositorio.SelecionarTodos();

        for (int i = 0; i < caixas.Length; i++)
        {
            Caixa? c = (Caixa?)caixas[i];

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



        bool conseguiuExcluir = repositorio.Excluir(idSelecionado);

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

    protected abstract EntidadeBase ObterDadosCadastrais();

}
