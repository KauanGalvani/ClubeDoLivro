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

    public void AtualizarRegistro(Caixa caixaAtualizada)
    {
        Etiqueta = caixaAtualizada.Etiqueta;
        Cor = caixaAtualizada.Cor;
        DiasDeEmprestimo = caixaAtualizada.DiasDeEmprestimo;
    }

    public string[] Validar()
    {
        string erros = string.Empty;


        if (string.IsNullOrWhiteSpace(Etiqueta))
        {
            erros += "O campo Etiqueta é obrigatorio;";

        }
        else if (Etiqueta.Length > 50)
        {
           erros += "O campo Etiqueta deve ter no maximo 50 caracteres;";

        }

        if (DiasDeEmprestimo < 1)
        {
            erros += "o campo Dias de imprestimo esta invalido;";
        }

        return erros.Split(';', StringSplitOptions.RemoveEmptyEntries);
    }
}
