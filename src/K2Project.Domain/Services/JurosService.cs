﻿using K2Project.Domain.Entities;
using K2Project.Domain.Interfaces.Repositories;
using K2Project.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace K2Project.Domain.Services
{
    public class JurosService : IJurosService
    {
        private readonly ITaxaJurosRepository _taxaJurosRepository;
        public JurosService(ITaxaJurosRepository taxaJurosRepository)
        {
            _taxaJurosRepository = taxaJurosRepository;
        }       
        public async Task<Juros> ObterTaxaJuros(decimal valorInicial, int meses)
        {
            var juros = await _taxaJurosRepository.ObterTaxaJurosAsync(valorInicial, meses);
            return juros;
        }
        public Task<string> ObterValorFinal(decimal valorInicial, int meses)
        {
            var juros = ObterTaxaJuros(valorInicial, meses);

            return juros.Result.ObterValorFinal();
        }
    }
}
