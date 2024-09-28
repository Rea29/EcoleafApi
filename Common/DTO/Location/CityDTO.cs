using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTO.Location
{
    public class CityDTO
    {
        [Key]
        public Int64? LineId { get; set; }
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
