using K2Project.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace K2Project.Domain.Interfaces.Repositories
{
    public interface ITaxaJurosRepository
    {
        Task<Juros> ObterTaxaJurosAsync(decimal valorInicial, int meses);
    }
}
