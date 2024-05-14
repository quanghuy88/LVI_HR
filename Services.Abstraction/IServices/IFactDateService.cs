﻿using Core.Entities;
using Injection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstraction.IServices
{
    public interface IFactDateService: IInjection
    {
        public Task<List<fact_date>> GetFactDateAll();
        public Task<List<fact_date>> GetFactDateDetailMonth();
    }
}
