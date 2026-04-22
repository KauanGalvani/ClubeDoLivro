using System;
using System.Security.Cryptography;
using ClubeDaLeitura.ConsoleApp.Dominio;

namespace ClubeDoLivro.ConsoleApp.Dominio;

public class Emprestimo
{

    public string Id { get; set; } = string.Empty;
    public Revista Revista { get; set; }
    public Amigo Amigo { get; set; }
    public DateTime Inicio { get; set; } // 01/01/0001 00:00:00
    public DateTime Devolucao { get; set; }
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
}
