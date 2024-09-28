using Common.Model.Global.Brands;
using Common.Model.Global.Subcategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model.Global.Categories
{
    public class CategoryGraphQLResponse
    {
        public CategoryGVM GetCategoryById { get; set; }
        public CategoryGVM CreateCategory { get; set; }
        public CategoryGVM UpdateCategory { get; set; }
        public GetAllCategories Categories { get; set; }
        public List<GraphQLError> Errors { get; set; }
    }

    public class GetAllCategories : PageInformation
    {
        public List<CategoryGVM> Items { get; set; }
    }

}
