using Constract.Authentication;
using Core.Dtos.Authorization;
using Core.Models;
using Injection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstraction.IServices
{
    public interface IAuthenticationService: IInjection
    {
        public Task<ResultLogin> LoginAsync(LoginRequest request);
    }
}
