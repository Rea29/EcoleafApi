using Common.Model.Global.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Global.Brands
{
    public class BrandGraphQLResponse
    {
        public BrandGVM GetBrandById { get; set; }
        public BrandGVM CreateBrand { get; set; }
        public BrandGVM UpdateBrand { get; set; }
        public GetAllBrands Brands { get; set; }
        public List<GraphQLError> Errors { get; set; }
    }

    //Get All Brands with Pagination
    public class GetAllBrands : PageInformation
    {
        public List<BrandGVM> Items { get; set; }
    }
}
