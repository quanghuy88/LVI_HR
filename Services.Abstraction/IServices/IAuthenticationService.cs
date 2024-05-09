using Constract.Authentication;
using Core.Dtos.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstraction.IServices
{
    public interface IAuthenticationService
    {
        Task<ResultLogin> Login(LoginRequest request);
    }
}
