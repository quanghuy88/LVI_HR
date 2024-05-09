using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.Jwt
{
    public class JwtUserTokens
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public Guid GuidId { get; set; }
        public TimeSpan Validaty { get; set; }
        public DateTime ExpiredTime { get; set; }
        public decimal DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public decimal BranchId { get; set; }
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public object[][] Role { get; set; }
        public decimal AccountMonthId { get; set; }
        public string AccountMonthCode { get; set; }
        public List<string> LstPermission { get; set; }
        public JwtUserTokens()
        {
            LstPermission = new List<string>();
        }
    }
}
