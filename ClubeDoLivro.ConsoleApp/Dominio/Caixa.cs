using System;

namespace ClubeDoLivro.ConsoleApp.Dominio;

//encapsulamento
public class Caixa
{
    public string Etiqueta { get; set; } = string.Empty;
    public string Cor { get; set; } = string.Empty;
    public int DiasDeEmprestimo { get; set; } = 7;//propriedade

    public Caixa(string etiqueta, string cor, int diasDeEmprestimo) // construtor de clase, toda instancia precisa dessas informações
    {
        Etiqueta = etiqueta;
        Cor = cor;
        DiasDeEmprestimo = diasDeEmprestimo;
    }
}
