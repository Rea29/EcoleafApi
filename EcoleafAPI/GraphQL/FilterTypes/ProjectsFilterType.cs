using Common.DTO.ProjectMonitoringManagement;
using Common.Model.Global.Categories;
using DTO.MaterialRequesitionSlip;
using HotChocolate.Data.Filters;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace EcoleafAPI.GraphQL.FilterTypes
{
    public class SubMaterialRequisitionSlipFilterType : FilterInputType<SubMaterialRequisitionSlipDTO>
    {
        protected override void Configure(IFilterInputTypeDescriptor<SubMaterialRequisitionSlipDTO> descriptor)
        {
            descriptor.Field(r => r.MaterialRequestUID);
            descriptor.Field(r => r.ProjectUID);
        }
    }
    public class MRSApproversFilterType : FilterInputType<MRSApproversDTO>
    {
        protected override void Configure(IFilterInputTypeDescriptor<MRSApproversDTO> descriptor)
        {
            descriptor.Field(r => r.MaterialRequestUID);
            //descriptor.Field(r => r.);
        }
    }
    public class MaterialRequisitionSlipFilterType : ObjectType<MaterialRequisitionSlipDTO>
    {
        protected override void Configure(IObjectTypeDescriptor<MaterialRequisitionSlipDTO> descriptor)
        {
            descriptor.Field(p => p.MaterialRequestUID);
            descriptor.Field(p => p.Approvers).UseFiltering<MaterialRequisitionSlipFilterType>();
        }
    }
    public class ProjectsFilterType : ObjectType<ProjectsDTO>
    {
        protected override void Configure(IObjectTypeDescriptor<ProjectsDTO> descriptor)
        {
            descriptor.Field(p => p.ProjectUID);
            descriptor.Field(p => p.MaterialRequisitionSlip).UseFiltering<SubMaterialRequisitionSlipFilterType>();
        }
    }
}
