using System;
using System.Security.Cryptography;

namespace ClubeDoLivro.ConsoleApp.Dominio;

//classe abistrata
public abstract class EntidadeBase
{
    public string Id { get; set; } = string.Empty;

    public EntidadeBase()
    {
        Id = Convert
        .ToHexString(RandomNumberGenerator.GetBytes(20))
        .ToLower()
        .Substring(0, 7);
    }

    public abstract void AtualizarRegistro(EntidadeBase entidadeAtualizada);
}
