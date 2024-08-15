using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static  class Constant
    {
        public const string BrowserStorageKey = "x-key";
        public const string HttpClientName = "WebUIClient";
        public const string HttpClientHeaderScheme = "Bearer";
        public const string AuthenticationType = "JwtAuth";
        public const string RegisterRoute = "api/account/identity/create";
        public const string LoginRoute = "api/account/identity/login";
        public const string RefreshTokenRoute = "api/account/identity/refresh-token";
        public const string GetRolesRoute = "api/account/identity/role/list";
        public const string CreateRoleRoute = "api/account/identity/role/create";
        public const string CreateAdminRoute = "setting";
        public const string GetUserWithRoleRoute = "api/account/identity/users-with-roles";
        public const string ChangeUserRoleRoute = "api/account/identity/change-role";

        public static class Role
        {
            public const string Admin = "Admin";
            public const string User = "User";

        }
        public const string AddVehicleRoute = "api/vehicle/add-vehicle";
        public const string AddVehicleBrandRoute = "api/vehicle/add-vehicle-brand";
        public const string AddVehicleOwnerRoute = "api/vehicle/add-vehicle-Owner";
        
        public const string GetVehiclesRout = "api/vehicle/get-vehicles";
        public const string GetVehicleBrandsRout = "api/vehicle/get-vehicle-brands";
        public const string GetVehicleOwnersRout = "api/vehicle/get-vehicle-owners";
        
        public const string GetVehicleRout = "api/vehicle/get-vehicle";
        public const string GetVehicleBrandRout = "api/vehicle/get-vehicle-brand";
        public const string GetVehicleOwnerRout = "api/vehicle/get-vehicle-owner";

        public const string UpdateVehicleRout = "api/vehicle/Update-vehicle";
        public const string UpdateVehicleBrandRout = "api/vehicle/Update-vehicle-brand";
        public const string UpdateVehicleOwnerRout = "api/vehicle/Update-vehicle-owner";

        public const string deleteVehicleRout = "api/vehicle/delete-vehicle";
        public const string deleteVehicleBrandRout = "api/vehicle/delete-vehicle-brand";
        public const string deleteVehicleOwnerRout = "api/vehicle/delete-vehicle-owner";



    }
}
