using Common.Model.Global.Location;
using Common.Model.Global.Merchants;
using Common.Model.Global.Roles;
using Common.Model.Global.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Global.Merchants
{
    public class MerchantGraphQLResponse
    {
        public MerchantGVM GetMerchantById { get; set; }
        public MerchantGVM CreateMerchant { get; set; }
        public MerchantGVM UpdateMerchant { get; set; }
        public GetAllMerchants Merchants { get; set; }
        public GetAllNatureofBusiness NatureofBusiness { get; set; }
        public GetAllCountries Countries { get; set; }
        public GetAllProvinces Provinces { get; set; }
        public GetAllCities Cities { get; set; }    
        public GetAllBarangays Barangays { get; set; }
        public GetAllUsers Users { get; set; }
    }

    public class GetAllMerchants : PageInformation
    {
        public List<MerchantGVM> Items { get; set; }
    }

    public class GetAllUsers
    {
        public List<UserGVM> Items { get; set; }
    }

    public class GetAllNatureofBusiness
    {
        public List<NatureOfBusinessGVM> Items { get; set; }
    }
    public class GetAllBarangays
    {
        public List<BarangaysGVM> Items { get; set; }
    }

    public class GetAllCountries
    {
        public List<CountryGVM> Items { get; set; }
    }
    public class GetAllProvinces
    {
        public List<ProvincesGVM> Items { get; set; }
    }

    public class GetAllCities
    {
        public List<CityGVM> Items { get; set; }
    }
}
