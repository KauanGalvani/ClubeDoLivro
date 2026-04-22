using System;

namespace ClubeDoLivro.ConsoleApp.Dominio;

public class Amigo : EntidadeBase
{
    public string Nome { get; set; } = string.Empty;
    public string NomeResponsavel { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public Emprestimo[] Emprestimos { get; set; } = new Emprestimo[100];


    public Amigo(string nome, string nomeResponsavel, string telefone)
    {
        Nome = nome;
        NomeResponsavel = nomeResponsavel;
        Telefone = telefone;
    }

    public override void AtualizarRegistro(EntidadeBase entidadeAtualizada)
    {
        Amigo amigoatualizado = (Amigo)entidadeAtualizada;

        Nome = amigoatualizado.Nome;
        NomeResponsavel = amigoatualizado.NomeResponsavel;
        Telefone = amigoatualizado.Telefone;
    }

    public override string[] Validar()
    {
        string erros = string.Empty;

        if (string.IsNullOrWhiteSpace(Nome))
            erros += "O campo Nome deve ser preenchido";

        else if (Nome.Length < 2 || Nome.Length > 100)
            erros += "O campo Nome deve conter entre 2 e 100 caracteres";

        if (string.IsNullOrWhiteSpace(NomeResponsavel))
            erros += "O campo Nome deve ser preenchido";

        else if (NomeResponsavel.Length < 2 || NomeResponsavel.Length > 100)
            erros += "O campo Nome deve conter entre 2 e 100 caracteres";

        int contador = 0;
        string telefoneEncurtado = Telefone.Replace("", "");
        bool contemLetraOuSimbolo = false;

        for (int i = 0; i < telefoneEncurtado.Length; i++)
        {
            char caractereAtual = telefoneEncurtado[i];

            if (telefoneEncurtado.Any(char.IsDigit))
                contador++;
            else
            {
                contemLetraOuSimbolo = true;
                break;
            }
        }

        if (telefoneEncurtado.Length < 10 || telefoneEncurtado.Length > 11)
            erros += "O campo telefone deve ter 11 numeros";

        return erros.Split(';', StringSplitOptions.RemoveEmptyEntries);
    }

    public void AdicionarEmprestimo(Emprestimo emprestimo)
    {

        for (int i = 0; i < Emprestimos.Length; i++)
        {
            Emprestimo e = Emprestimos[i];

            if (e == null)
                Emprestimos[i] = emprestimo;
            break;
        }
    }
}


