using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Global.Location
{
    public class CityGVM
    {

        public int? LineId { get; set; }
        public string? CityCode { get; set; }
        public string? Name { get; set; }
        public string? OldName { get; set; }
        public string? ProvinceCode { get; set; }
        public string? RegionCode { get; set; }
        public string? CountryCode { get; set; }
        public string? PSGC10DigitCode { get; set; }
        public string? CorrespondenceCode { get; set; }
        public string? GeographicLevel { get; set; }
    }
}
