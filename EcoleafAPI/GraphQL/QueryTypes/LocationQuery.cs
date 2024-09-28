using Common.Constants;
using Common.DTO.Location;
using Common.DTO.MaterialsInventory;
using Common.Model.Global.Brands;
using Common.Model.Global.Categories;
using DTO.HumanResourceManagement;
using DTO.MaterialRequesitionSlip;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


namespace EcoleafAPI.GraphQL.QueryTypes
{
    [ExtendObjectType("Query")]

    public class LocationQuery
    {
        //private readonly AppDbContext _context;

        public LocationQuery(AppDbContext context)
        {
            //_context = context;
        }

        //[GraphQLName("getMaterialRequisitionSlip")]
        //public IQueryable<MaterialRequisitionSlipDTO> GetMaterialRequisitionSlip([Service] AppDbContext context) =>
        //context.MaterialRequisitionSlip;
        [GraphQLName("getCountries")]
        [UseOffsetPaging]
        [UseFiltering]
        [UseSorting]
        //public async Task<IQueryable<MaterialRequisitionSlipDTO>> GetMaterialRequisitionSlip(HttpContext context, ClaimsPrincipal claimsPrincipal, [Service] AppDbContext context)
        public async Task<List<CountryDTO>> GetCountriesAsync(HttpContext context, ClaimsPrincipal claimsPrincipal, [Service] AppDbContext _context)
        {
            List<CountryDTO> resDataList = new List<CountryDTO>();
            try
            {
                resDataList = await _context.Countries.ToListAsync();
            }
            catch (DbUpdateException ex)
            {
                var error = new Error(ex.Message, "500");
                throw new GraphQLException(error);
            }
            catch (Exception ex)
            {
                var error = new Error(ex.Message, "500");
                throw new GraphQLException(error);
            }
            return resDataList;

            //materialRequisitionSlipLis
        }
        [GraphQLName("getProvinces")]
        [UseOffsetPaging]
        [UseFiltering]
        [UseSorting]
        //public async Task<IQueryable<MaterialRequisitionSlipDTO>> GetMaterialRequisitionSlip(HttpContext context, ClaimsPrincipal claimsPrincipal, [Service] AppDbContext context)
        public async Task<IEnumerable<ProvincesDTO>> GetProvincesAsync(HttpContext context, ClaimsPrincipal claimsPrincipal, [Service] AppDbContext _context, string CountryCode)
        {
            List<ProvincesDTO> resDataList = new List<ProvincesDTO>();
            try
            {
                resDataList = await _context.Provinces.Where(x=> x.CountryCode == CountryCode).ToListAsync();
            }
            catch (DbUpdateException ex)
            {
                var error = new Error(ex.Message, "500");
                throw new GraphQLException(error);
            }
            catch (Exception ex)
            {
                var error = new Error(ex.Message, "500");
                throw new GraphQLException(error);
            }
            return resDataList;

            //materialRequisitionSlipLis
        }
        [GraphQLName("getCities")]
        [UseOffsetPaging]
        [UseFiltering]
        [UseSorting]
        //public async Task<IQueryable<MaterialRequisitionSlipDTO>> GetMaterialRequisitionSlip(HttpContext context, ClaimsPrincipal claimsPrincipal, [Service] AppDbContext context)
        public async Task<List<CityDTO>> GetCitiesAsync(HttpContext context, ClaimsPrincipal claimsPrincipal, [Service] AppDbContext _context, string ProvinceCode)
        {
            List<CityDTO> resDataList = new List<CityDTO>();
            try
            {
                resDataList = await _context.Cities.Where(x => x.ProvinceCode == ProvinceCode).ToListAsync();
            }
            catch (DbUpdateException ex)
            {
                var error = new Error(ex.Message, "500");
                throw new GraphQLException(error);
            }
            catch (Exception ex)
            {
                var error = new Error(ex.Message, "500");
                throw new GraphQLException(error);
            }
            return resDataList;

            //materialRequisitionSlipLis
        }
        [GraphQLName("getBarangays")]
        [UseOffsetPaging]
        [UseFiltering]
        [UseSorting]
        //public async Task<IQueryable<MaterialRequisitionSlipDTO>> GetMaterialRequisitionSlip(HttpContext context, ClaimsPrincipal claimsPrincipal, [Service] AppDbContext context)
        public async Task<List<BarangaysDTO>> GetBarangaysAsync(HttpContext context, ClaimsPrincipal claimsPrincipal, [Service] AppDbContext _context, string CityCode)
        {
            List<BarangaysDTO> resDataList = new List<BarangaysDTO>();
            try
            {
                resDataList = await _context.Barangays.Where(x => x.CityCode == CityCode).ToListAsync();
            }
            catch (DbUpdateException ex)
            {
                var error = new Error(ex.Message, "500");
                throw new GraphQLException(error);
            }
            catch (Exception ex)
            {
                var error = new Error(ex.Message, "500");
                throw new GraphQLException(error);
            }
            return resDataList;

            //materialRequisitionSlipLis
        }

    }
}
