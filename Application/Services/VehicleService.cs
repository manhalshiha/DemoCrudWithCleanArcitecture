using Application.DTOs.Request.Vehicles;
using Application.DTOs.Response;
using Application.DTOs.Response.Vehicle;
using Application.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class VehicleService(HttpClientService httpClientService) : IVehicleService
    {
        private async Task<HttpClient> PrivateClient() => await httpClientService.GetPrivateClient();
        private static string CheckResponseStatus(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
                return $"Sorry unknown error occurred .{Environment.NewLine}Error Description:{Environment.NewLine}Status code:";
            else
                return null;
        }
        private static GeneralResponse ErrorOperation(string message) => new(false, message);
        public async Task<GeneralResponse> AddVehicle(CreateVehicleRequestDto model)
        {
            var result=await (await PrivateClient()).PostAsJsonAsync(Constant.AddVehicleRoute,model);
            if(!string.IsNullOrEmpty(CheckResponseStatus(result)))return ErrorOperation(CheckResponseStatus(result));
            return await result.Content.ReadFromJsonAsync<GeneralResponse>();
        }

        public async Task<GeneralResponse> AddVehicleBrand(CreateVehicleBrandRequestDto model)
        {
            var result = await(await PrivateClient()).PostAsJsonAsync(Constant.AddVehicleBrandRoute, model);
            if (!string.IsNullOrEmpty(CheckResponseStatus(result))) return ErrorOperation(CheckResponseStatus(result));
            return await result.Content.ReadFromJsonAsync<GeneralResponse>();
        }

        public async Task<GeneralResponse> AddVehicleOwner(CreateVehicleOwnerRequestDto model)
        {
            var result = await(await PrivateClient()).PostAsJsonAsync(Constant.AddVehicleOwnerRoute, model);
            if (!string.IsNullOrEmpty(CheckResponseStatus(result))) return ErrorOperation(CheckResponseStatus(result));
            return await result.Content.ReadFromJsonAsync<GeneralResponse>();
        }

        public async Task<GeneralResponse> DeleteVehicle(int id)
        {
            var result = await(await PrivateClient()).DeleteAsync($"{Constant.deleteVehicleRout}/{id}");
            if (!string.IsNullOrEmpty(CheckResponseStatus(result))) return ErrorOperation(CheckResponseStatus(result));
            return await result.Content.ReadFromJsonAsync<GeneralResponse>();
        }

        public async Task<GeneralResponse> DeleteVehicleBrand(int id)
        {
            var result = await(await PrivateClient()).DeleteAsync($"{Constant.deleteVehicleBrandRout}/{id}");
            if (!string.IsNullOrEmpty(CheckResponseStatus(result))) return ErrorOperation(CheckResponseStatus(result));
            return await result.Content.ReadFromJsonAsync<GeneralResponse>();
        }

        public async Task<GeneralResponse> DeleteVehicleOwner(int id)
        {
            var result = await(await PrivateClient()).DeleteAsync($"{Constant.deleteVehicleOwnerRout}/{id}");
            if (!string.IsNullOrEmpty(CheckResponseStatus(result))) return ErrorOperation(CheckResponseStatus(result));
            return await result.Content.ReadFromJsonAsync<GeneralResponse>();
        }

        public async Task<GetVehicleResponseDto> GetVehicle(int id)
        => await (await PrivateClient()).GetFromJsonAsync<GetVehicleResponseDto>($"{Constant.GetVehicleRout}/{id}");

        public async Task<GetVehicleBrandResponseDto> GetVehicleBrand(int id)
        => await(await PrivateClient()).GetFromJsonAsync<GetVehicleBrandResponseDto>($"{Constant.GetVehicleBrandRout}/{id}");

        public async Task<GetVehicleOwnerResponseDto> GetVehicleOwner(int id)
        => await(await PrivateClient()).GetFromJsonAsync<GetVehicleOwnerResponseDto>($"{Constant.GetVehicleOwnerRout}/{id}");


        public async Task<IEnumerable<GetVehicleResponseDto>> GetVehicles()
        => await (await PrivateClient()).GetFromJsonAsync<IEnumerable<GetVehicleResponseDto>>(Constant.GetVehiclesRout);

        public async Task<IEnumerable<GetVehicleBrandResponseDto>> GetVehicleBrands()
        => await (await PrivateClient()).GetFromJsonAsync<IEnumerable<GetVehicleBrandResponseDto>>(Constant.GetVehicleBrandsRout);
        
        public async Task<IEnumerable<GetVehicleOwnerResponseDto>> GetVehicleOwners()
        => await (await PrivateClient()).GetFromJsonAsync<IEnumerable<GetVehicleOwnerResponseDto>>(Constant.GetVehicleOwnersRout);


        public async Task<GeneralResponse> UpdateVehicle(UpdateVehicleRequestDto model)
        {
            var result = await(await PrivateClient()).PutAsJsonAsync(Constant.UpdateVehicleRout, model);
            if (!string.IsNullOrEmpty(CheckResponseStatus(result))) return ErrorOperation(CheckResponseStatus(result));
            return await result.Content.ReadFromJsonAsync<GeneralResponse>();

        }

        public async Task<GeneralResponse> UpdateVehicleBrand(UpdateVehicleBrandRequestDto model)
        {
            var result = await(await PrivateClient()).PostAsJsonAsync(Constant.UpdateVehicleBrandRout, model);
            if (!string.IsNullOrEmpty(CheckResponseStatus(result))) return ErrorOperation(CheckResponseStatus(result));
            return await result.Content.ReadFromJsonAsync<GeneralResponse>();

        }

        public async Task<GeneralResponse> UpdateVehicleOwner(UpdateVehicleOwnerRequestDto model)
        {
            var result = await(await PrivateClient()).PostAsJsonAsync(Constant.UpdateVehicleOwnerRout, model);
            if (!string.IsNullOrEmpty(CheckResponseStatus(result))) return ErrorOperation(CheckResponseStatus(result));
            return await result.Content.ReadFromJsonAsync<GeneralResponse>();

        }

       
    }
}
