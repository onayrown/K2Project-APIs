using System;
using Xunit;
using K2Project.Domain.Entities;

namespace K2Project.Tests
{
    public class JurosTests
    {
        //Validar Valor Final 
        //Valor Final  deve ser truncado (sem arredondamento) em duas casas decimais.

        [Theory(DisplayName = "Valor Final deve ser consistente")]
        [Trait("Categoria", "Juros")]
        [InlineData(100, 5, "105,10")]
        [InlineData(100, 6, "106,15")]
        [InlineData(100, 7, "107,21")]
        [InlineData(200, 5, "210,20")]
        [InlineData(237.52, 5, "249,63")]
        public void Juros_CalcularValorFinal_ValorFinalDeveSerConsistente(decimal valorInicial, int meses, string valorEsperado)
        {
            //Arrange
            decimal taxaJuros = 0.01m;
            var juros = new Juros(valorInicial, meses, taxaJuros);

            //Act
            var valorFinal = juros.ObterValorFinal().Result;

            //Assert
            Assert.Equal(valorEsperado, valorFinal);
        }        
    }
}
