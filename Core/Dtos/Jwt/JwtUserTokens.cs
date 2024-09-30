using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.Jwt
{
    public class JwtUserTokens
    {
        public decimal? Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public Guid GuidId { get; set; }
        public TimeSpan Validaty { get; set; }
        public DateTime ExpiredTime { get; set; }
    }
}
