using System;
using ClubeDoLivro.ConsoleApp.Dominio;

namespace ClubeDoLivro.ConsoleApp.Infraestrutura;

public class RepositorioCaixa
{
    private Caixa?[] caixas = new Caixa[100];

    public void Cadastrar(Caixa novaCaixa)
    {
        for (int i = 0; i < caixas.Length; i++)
        {
            if (caixas[i] == null)
            {
                caixas[i] = novaCaixa;
                break;
            }
        }
    }

    public bool Editar(string idSelecionado, Caixa novaCaixa)
    {

        Caixa? caixaSelecioonada = null;
        for (int i = 0; i < caixas.Length; i++)
        {
            Caixa? c = caixas[i];

            if (c == null) continue;

            if (c.Id == idSelecionado)
            {
                caixaSelecioonada = c;
                break;
            }
        }

        if (caixaSelecioonada == null)
            return false;

        caixaSelecioonada.AtualizarRegistro(novaCaixa);

        return true;
    }

    public bool Excluir(string idSelecionado)
    {
        for (int i = 0; i < caixas.Length; i++)
        {
            Caixa? c = caixas[i];

            if (c == null)
                continue;

            if (c.Id == idSelecionado)
            {
                caixas[i] = null;
                return true;
            }
        }

        return false;

    }

    internal Caixa?[] SelecionarTodos()
    {
        return caixas;
    }
}
