using System;

namespace ClubeDoLivro.ConsoleApp.Dominio;

//encapsulamento
public class Caixa : EntidadeBase //herança
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

    public void AtualizarRegistro(Caixa caixaAtualizada)
    {
        Etiqueta = caixaAtualizada.Etiqueta;
        Cor = caixaAtualizada.Cor;
        DiasDeEmprestimo = caixaAtualizada.DiasDeEmprestimo;
    }

    public override string[] Validar()
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

    //substituição = implementação do metodo abstração
    public override void AtualizarRegistro(EntidadeBase entidadeAtualizada)
    {
        Caixa caixaAtualizada = (Caixa)entidadeAtualizada; // cast  / conversao de tipo
        
        Etiqueta = caixaAtualizada.Etiqueta;
        Cor = caixaAtualizada.Cor;
        DiasDeEmprestimo = caixaAtualizada.DiasDeEmprestimo;
    }

}
