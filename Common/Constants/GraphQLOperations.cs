using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Constants.GraphQLOperations
{
    public static class Operations_QUERY
    {
        public static class Location
        {
            public static string GET_PROVINCES(string countryId) =>
                $@"query{{
                    provinces(countryCode: ""{countryId}""){{
                        items{{ lineId, provinceCode, name, countryCode }}
                    }}
                }}";

            public static string GET_CITIES(string provinceId) =>
                $@"query {{
                    cities(provinceCode: ""{provinceId}"") {{
                        items{{cityCode name provinceCode}}
                    }}
                }}";

            public static string GET_BARANGAYS(string cityId) =>
                $@"query{{
                      barangays(cityCode: ""{cityId}""){{
                        items{{ barangayCode name cityCode }}
                      }}
                }}";
        }

        public static class Suppliers
        {
			public static string GET_SUPPLIER_BY_ID(string supplierId) =>
				$@"query{{
                    suppliers(
                    where:{{
                        supplierId: {{eq:""{supplierId}""}}
                        }}
                        ){{
                    items{{
                        supplierId
                        supplierName
                        website
                        supplierDescription
                        isActive
                        isDeleted
                        createdBy
                        createdAt
                        contactNumber
                        contactPerson
                        tinNumber
                        emailAddress
                        businessAddress
                        building
                        floor
                        stallNumber
                        street
                        provinceName
                        provinceId
                          cityName
                          cityId
                          barangayName
                          barangayId
                          countryName
                          countryId
                        zipCode
                    }}
                    }}
                }}";
		}
    }
    public static class Operations_MUTATION
    {
        public static class Suppliers
        {
            public static string CREATE_SUPPLIER = $@"mutation ($supplier: SupplierGVMInput!) {{
                                                  createSupplier(supplier: $supplier ) {{
                                                    supplierId
                                                      supplierName
                                                      website
                                                      supplierDescription
                                                      isActive
                                                      isDeleted
                                                      createdBy
                                                      createdAt
                                                      contactNumber
                                                      contactPerson
                                                      tinNumber
                                                      emailAddress
                                                      businessAddress
                                                      building
                                                      floor
                                                      stallNumber
                                                      street
                                                      provinceId
                                                      cityId
                                                      barangayId
                                                      zipCode
                                                      countryId
                                                  }}
                                                }}";

            public static string UPDATE_SUPPLIER = $@"mutation ($supplier: SupplierGVMInput!) {{
                                                  updateSupplier(supplier: $supplier ) {{
                                                    supplierId
                                                      supplierName
                                                      website
                                                      supplierDescription
                                                      isActive
                                                      isDeleted
                                                      createdBy
                                                      createdAt
                                                      contactNumber
                                                      contactPerson
                                                      tinNumber
                                                      emailAddress
                                                      businessAddress
                                                      building
                                                      floor
                                                      stallNumber
                                                      street
                                                      provinceId
                                                      cityId
                                                      barangayId
                                                      zipCode
                                                      countryId
                                                  }}
                                                }}";
        }
    }
}
