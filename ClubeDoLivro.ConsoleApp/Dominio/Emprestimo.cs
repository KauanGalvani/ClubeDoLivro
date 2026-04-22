using System;
using System.Security.Cryptography;
using ClubeDaLeitura.ConsoleApp.Dominio;

namespace ClubeDoLivro.ConsoleApp.Dominio;

public class Emprestimo
{

    public string Id { get; set; } = string.Empty;
    public Revista Revista { get; set; }
    public Amigo Amigo { get; set; }
    public DateTime Abertura { get; set; } // propriedade autoimplementada
    public DateTime Conclusao
    {
        get
        {
            //encapsular essa logica de conclusão prevista
            int diasDeEmprestimo = Revista.Caixa.DiasDeEmprestimo;

            // variavel a esquerda == Escrita - set
            DateTime conclusao = Abertura.AddDays(diasDeEmprestimo);
            return conclusao;
        }
    }
    public StatusEmprestimo Status { get; set; } = StatusEmprestimo.indefinido;

    public Emprestimo(Revista revista, Amigo amigo)
    {
        Id = Convert
        .ToHexString(RandomNumberGenerator.GetBytes(20))
        .ToLower()
        .Substring(0, 7);

        Revista = revista;
        Amigo = amigo;
    }

    public string[] Validar()
    {
        string erros = string.Empty;

        if (Revista == null)
            erros = "O campo Revista precisa ser preenchido";

        if (Amigo == null)
            erros = "O campo Amigo deve ser preenchido";

        return erros.Split(';', StringSplitOptions.RemoveEmptyEntries);
    }

    public void Abrir()
    {
        Abertura = DateTime.Now;

        Status = StatusEmprestimo.Aberto;
        Revista.Emprestar();

        Amigo.AdicionarEmprestimo(this);
    }
}
