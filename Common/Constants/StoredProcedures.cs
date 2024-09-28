using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Constants
{
	public class StoredProcedures
	{
		public static class SampleSP
		{
			public const string GET_ALL_SAMPLE = "GET_ALL_SAMPLE";

			public const string CREATE_SAMPLE = "CREATE_SAMPLE";
			public const string UPDATE_SAMPLE = "UPDATE_SAMPLE";
			public const string DELETE_SAMPLE = "DELETE_SAMPLE";
		}
		public static class RoleSP
		{
			public const string GET_ALL_ROLES = "GET_ALL_ROLES";
			public const string GET_ROLE_BY_ID = "GET_ROLE_BY_ID";

			public const string CREATE_ROLE = "CREATE_ROLE";
			public const string UPDATE_ROLE = "UPDATE_ROLE";
			public const string DELETE_ROLE = "DELETE_ROLE";
		}
		public static class ModuleSP
		{
			public const string GET_ALL_MODULES = "GET_ALL_MODULES";
			public const string GET_ROLE_BY_ID = "GET_ROLE_BY_ID";

			public const string CREATE_ROLE = "CREATE_ROLE";
			public const string UPDATE_ROLE = "UPDATE_ROLE";
			public const string DELETE_ROLE = "DELETE_ROLE";
		}
        public static class CategorySP
        {
            public const string CREATE_CATEGORY = "CREATE_CATEGORY";
            public const string VALIDATE_CATEGORY = "VALIDATE_CATEGORY";
            public const string GET_CATEGORY_BY_ID = "GET_CATEGORY_BY_ID";
            public const string GET_ALL_CATEGORIES = "GET_ALL_CATEGORIES";
            public const string UPDATE_CATEGORY = "UPDATE_CATEGORY";

        }
        public static class MerchantsSP
		{
			public const string GET_ALL_MERCHANTS = "GET_ALL_MERCHANTS";
			public const string GET_ALL_NATURE_OF_BUSINESS = "GET_ALL_NATURE_OF_BUSINESS";
			public const string VALIDATE_MERCHANT = "VALIDATE_MERCHANT";
			public const string CREATE_MERCHANT = "CREATE_MERCHANT";
			public const string GET_MERCHANT_BY_ID = "GET_MERCHANT_BY_ID";
			public const string UPDATE_MERCHANT = "UPDATE_MERCHANT";
            public static class BranchesSP
            {
                public const string VALIDATE_MERCHANT_BRANCH = "VALIDATE_MERCHANT_BRANCH";
                public const string CREATE_MERCHANT_BRANCH = "CREATE_MERCHANT_BRANCH";
                public const string GET_MERCHANT_BRANCH_BY_ID = "GET_MERCHANT_BRANCH_BY_ID";
                public const string GET_MERCHANT_BRANCHES = "GET_MERCHANT_BRANCHES";

            }


        }

        public static class LocationsSP
		{
			public const string GET_ALL_PROVINCES = "GET_ALL_PROVINCES";
			public const string GET_ALL_CITIES = "GET_ALL_CITIES";
			public const string GET_ALL_BARANGAYS = "GET_ALL_BARANGAYS";
			public const string VALIDATE_LOCATION = "VALIDATE_LOCATION";
        }
		public static class UserSP
		{
			public const string GET_ALL_USERS = "GET_ALL_USERS";
			public const string GET_USER_BY_ID = "GET_USER_BY_ID";
			public const string GET_USER_BY_EMAIL = "GET_USER_BY_EMAIL";

			public const string CREATE_USER = "CREATE_USER";
			public const string UPDATE_USER = "UPDATE_USER";
			public const string DELETE_USER = "DELETE_USER";

			public const string CREATE_USER_TOKEN = "CREATE_USER_TOKEN";
			public const string ADD_LOGIN_ATTEMPT = "ADD_LOGIN_ATTEMPT";

			public const string VALIDATE_USER = "VALIDATE_USER";
			public const string VALIDATE_ACCOUNT = "VALIDATE_ACCOUNT";
		}

		public static class ConfigurationSP
		{
			public const string GET_CONFIG = "GET_CONFIG";
		}
		public static class NotificationSP
		{
			public const string GET_EMAIL_TEMPLATE_BY_ID = "GET_EMAIL_TEMPLATE_BY_ID";
		}

		public static class AccountSP
		{
			public const string VALIDATE_ACCOUNT = "VALIDATE_ACCOUNT";
			public const string LOGOUT_ACCOUNT = "LOGOUT_ACCOUNT";

		}

		public static class BrandSP
		{
			public const string GET_ALL_BRANDS = "GET_ALL_BRANDS";
			public const string GET_BRAND_BY_ID = "GET_BRAND_BY_ID";

			public const string CREATE_BRAND = "CREATE_BRAND";
			public const string UPDATE_BRAND = "UPDATE_BRAND";
			public const string DELETE_BRAND = "DELETE_BRAND";


			public const string VALIDATE_BRAND = "VALIDATE_BRAND";
		}

		public static class MaintenanceSP
		{
			public const string GET_MAINTENANCE_VALUES = "GET_MAINTENANCE_VALUES";
		}
	
        public static class ProductSP
        {

            public static class SupplierSP
            {
                public const string VALIDATE_SUPPLIER = "VALIDATE_SUPPLIER";
                public const string CREATE_SUPPLIER = "CREATE_SUPPLIER";
                public const string GET_SUPPLIER_BY_ID = "GET_SUPPLIER_BY_ID";
                public const string GET_ALL_SUPPLIERS = "GET_ALL_SUPPLIERS";
                public const string UPDATE_SUPPLIER = "UPDATE_SUPPLIER";

            }
            public static class UoMSP
            {
                public const string GET_ALL_UOM = "GET_ALL_UOM";

            }
        }

		public static class AuditTrailSP
		{
			public const string GET_ALL_AUDIT_TRAIL = "GET_ALL_AUDIT_TRAIL";
		}
	}
}
