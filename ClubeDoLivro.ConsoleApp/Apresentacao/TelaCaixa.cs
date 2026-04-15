using System;
using ClubeDoLivro.ConsoleApp.Dominio;

namespace ClubeDoLivro.ConsoleApp.Apresentacao;

public class TelaCaixa
{
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
        novaCaixa.Etiqueta = etiqueta;
        novaCaixa.Cor = cor;
        novaCaixa.DiasDeEmprestimo = diasDeEmprestimo;
    }

    public void Editar()
    {
        throw new NotImplementedException();
    }

    public void Excluir()
    {
        throw new NotImplementedException();
    }

    public void Visualizar()
    {
        throw new NotImplementedException();
    }

    public void ExibirCabecalho(string texto)
    {
        Console.WriteLine("================================");
        Console.WriteLine("        Gestão de caixas        ");
        Console.WriteLine("================================");
        Console.WriteLine($"        {texto}        ");
        Console.WriteLine("================================");
    }
}
