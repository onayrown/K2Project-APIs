using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace K2Project.Domain.Entities
{
    public class Juros
    {
        public Juros(decimal valorInicial, int meses, decimal taxa)
        {
            ValorInicial = valorInicial;
            Meses = meses;
            TaxaJuros = taxa;
        }

        public decimal ValorInicial { get; set; }
        public int Meses { get; set; }
        public decimal TaxaJuros { get; set; }       

        public async Task<decimal> ObterValorFinal() => await CalcularValorFinal();
  
        private async Task<decimal> CalcularValorFinal()
        {
            var resultadoParenteses = 1 + TaxaJuros;
            var resultadoPotencia = Math.Pow((double)resultadoParenteses, Meses);
            var resultadoMultiplicacao = ValorInicial * (decimal)resultadoPotencia;
            var resultado = Math.Truncate(ValorInicial * resultadoMultiplicacao) / ValorInicial;
            return await Task.FromResult(ValidarCasasDecimais(resultado, 2));
        }
        private decimal ValidarCasasDecimais(decimal numero, int digitos)
        {
            decimal resultado1 = (decimal)(Math.Pow(10.0, (double)digitos));
            int resultado2 = (int)(resultado1 * numero);
            return (decimal)resultado2 / resultado1;
        }
    }
}
