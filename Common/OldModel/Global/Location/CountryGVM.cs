using Common.Constants;
using Common.Model.Global.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Global.Location
{
    public class CountryGVM
    {
        public string? CountryId { get; set; }
        public string? Name { get; set; }
        public string? Alpha2Code { get; set; }
        public string? Alpha3Code { get; set; }
        public string? NumericCode { get; set; }
        public string? IsEnabled { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? LastModifiedBy { get; set; }
        public string? DateLastModified { get; set; }



    }
}
