using Microsoft.VisualStudio.TestTools.UnitTesting;
using Buscador.Interfaces;
using Buscador.Services;
using System.Linq;

namespace Buscador.Test.Test;

[TestClass]
public class BuscadorService_PalavraNaoEncontrada
{
    private readonly IBuscadorService _buscadorService;

    public BuscadorService_PalavraNaoEncontrada()
    {
        _buscadorService = new BuscadorService();
    }

    [TestMethod]
    [DataRow("", "", "")]
    [DataRow("tes**", "aie", "")]
    [DataRow("tes**", "aie", "e")]
    [DataRow("tes**", "", "x")]
    public void BuscadorService_PalavraNaoEncontrada_ReturnFalse(string mascara, string letrasIgnoradas, string letrasObrigatorias)
    {
        var resultadoDaBusca = _buscadorService.Buscar(mascara, letrasIgnoradas, letrasObrigatorias);
        
        Assert.IsFalse(resultadoDaBusca.Count() > 0, "Nenhuma palavra deve ser encontrada");
    }
}