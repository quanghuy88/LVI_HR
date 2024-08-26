using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class PaginationDto<T> where T : class
    {
        public int count { get; set; }
        public IEnumerable<T> grid { get; set; } = new List<T>();
    }

}
