using K2Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace K2Project.Domain.Interfaces.Services
{
    public interface IJurosService
    {
        Task<decimal> ObterValorFinal(decimal valorInicial, int meses);
        Task<Juros> ObterTaxaJuros(decimal valorInicial, int meses);
        string ObterCodigoFonte();
    }
}
