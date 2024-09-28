using Common.Model.Global.Categories;
using HotChocolate.Data.Filters;
using HotChocolate.Data;


namespace Common.Model.FilterTypes
{
    public class SubCategoryFilterType : FilterInputType<SubCategoryGVM>
    {
        protected override void Configure(IFilterInputTypeDescriptor<SubCategoryGVM> descriptor)
        {
            descriptor.Field(r => r.CategoryId);
            descriptor.Field(r => r.CategoryName);
        }
    }

    public class CategoryFilterType : ObjectType<CategoryGVM>
    {
        protected override void Configure(IObjectTypeDescriptor<CategoryGVM> descriptor)
        {   
            descriptor.Field(p => p.CategoryId);
        }
    }
}
