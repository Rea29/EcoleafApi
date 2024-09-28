using Common.Model.Global.Brands;
using Common.Model.Global.Location;
using Common.Model.Global.Products.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Global.Products.Suppliers
{
    public class SupplierGraphQLResponse
    {
        public SupplierGVM GetSupplierById { get; set; }
        public SupplierGVM CreateSupplier { get; set; }
        public SupplierGVM UpdateSupplier { get; set; }
        public Provinces Provinces { get; set; }
        public Cities Cities { get; set; }
        public Barangays Barangays { get; set; }

        public GetAllSuppliers Suppliers { get; set; }
        public List<GraphQLError> Errors { get; set; }
    }

    public class Provinces
    {
        public List<ProvincesGVM> Items { get; set; }
    }
    public class Cities
    {
        public List<CityGVM> Items { get; set; }
    }
    public class Barangays
    {
        public List<BarangaysGVM> Items { get; set; }
    }
    //Get All Brands with Pagination
    public class GetAllSuppliers : PageInformation
    {
        public List<SupplierGVM> Items { get; set; }
    }
}
