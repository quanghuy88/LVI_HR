using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class BaseSearchModel
    {
        public decimal id { get; set; }
        public int page_size { get => _page_size; set => _page_size = value > 100 ? 100 : value; }
        public int page_no { get; set; } = 1;
        public string order_by { get; set; }
        public string filter { get; set; }
        public string static_filter { get; set; }
        public decimal? department_id { get; set; }
        public decimal? branch_id { get; set; }

        public string GetFilterOrDefault(string defaultFilter = "TRUE")
        {
            var filters = new string[] {
                filter?.Trim(),
                static_filter?.Trim()
            }.Where(x => !string.IsNullOrEmpty(x));
            if (!filters.Any()) return (string.IsNullOrEmpty(defaultFilter) || string.IsNullOrWhiteSpace(defaultFilter)) ? "TRUE" : defaultFilter;
            else if (filters.Count() == 1) return filters.FirstOrDefault();
            else return string.Join("&&", filters.Select(x => $"({x})"));
        }

        public string GetOrderOrDefault(string defaultOrder = "1")
        {
            if (string.IsNullOrEmpty(order_by) || string.IsNullOrWhiteSpace(order_by))
            {
                if (string.IsNullOrEmpty(defaultOrder) || string.IsNullOrWhiteSpace(defaultOrder)) return "1";
                return defaultOrder;
            }
            return order_by;
        }

        private int _page_size = 20;
    }

}
