using System;
using ClubeDoLivro.ConsoleApp.Dominio;

namespace ClubeDoLivro.ConsoleApp.Infraestrutura;

public class RepositorioBase
{
    protected EntidadeBase?[] registros = new EntidadeBase[100];

    public void Cadastrar(EntidadeBase novaEntidadeBase)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            if (registros[i] == null)
            {
                registros[i] = novaEntidadeBase;
                break;
            }
        }
    }

    public EntidadeBase?[] SelecionarTodos()
    {
        return registros;
    }

    public bool Editar(string idSelecionado, EntidadeBase novaEntidadeBase)
    {
        EntidadeBase? EntidadeBaseSelecionada = SelecionarPorId(idSelecionado);

        if (EntidadeBaseSelecionada == null)
            return false;

        EntidadeBaseSelecionada.AtualizarRegistro(novaEntidadeBase);

        return true;
    }

    public bool Excluir(string idSelecionado)
    {
        for (int i = 0; i < registros.Length; i++)
        {
            EntidadeBase? c = registros[i];

            if (c == null)
                continue;

            if (c.Id == idSelecionado)
            {
                registros[i] = null;
                return true;
            }
        }

        return false;
    }

    public EntidadeBase? SelecionarPorId(string idSelecionado)
    {
        EntidadeBase? EntidadeBaseSelecionada = null;

        for (int i = 0; i < registros.Length; i++)
        {
            EntidadeBase? c = registros[i];

            if (c == null)
                continue;

            if (c.Id == idSelecionado)
            {
                EntidadeBaseSelecionada = c;
                break;
            }
        }

        return EntidadeBaseSelecionada;
    }
}
