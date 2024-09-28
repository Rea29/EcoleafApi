using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Global.Merchants
{
    public class BusinessType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public static class BusinessTypeData
    {
        public static List<BusinessType> GetBusinessType()
        {
            return new List<BusinessType>
        {
            new BusinessType { Id = 1, Name ="Sole Proprietor" },
            new BusinessType { Id = 2, Name = "Partnership" },
            new BusinessType { Id = 3, Name = "Corporation" },
            new BusinessType { Id = 4, Name = "Enterprise" }
        };
        }

    }
}