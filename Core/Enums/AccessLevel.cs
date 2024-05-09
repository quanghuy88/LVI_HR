using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Enums
{
    public enum AccessLevel
    {
        [Description("Không truy cập")]
        None = 0,

        [Description("Truy cập dữ liệu")]
        User = 1,

        [Description("admin")]
        Admin = 2,
    }
}
