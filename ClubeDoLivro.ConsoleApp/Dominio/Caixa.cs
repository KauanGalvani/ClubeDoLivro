using System;
using System.Security.Cryptography;

namespace ClubeDoLivro.ConsoleApp.Dominio;

//encapsulamento
public class Caixa
{
    public string Id { get; set; } = string.Empty;
    public string Etiqueta { get; set; } = string.Empty;
    public string Cor { get; set; } = string.Empty;
    public int DiasDeEmprestimo { get; set; } = 7;//propriedade

    public Caixa(string etiqueta, string cor, int diasDeEmprestimo) // construtor de clase, toda instancia precisa dessas informações
    {
        Id = Convert
                .ToHexString(RandomNumberGenerator.GetBytes(20))
                .ToLower()
                .Substring(0, 7);

        Etiqueta = etiqueta;
        Cor = cor;
        DiasDeEmprestimo = diasDeEmprestimo;
    }
}
