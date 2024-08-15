using Application.DTOs.Request.Vehicles;
using Application.DTOs.Response;
using Application.DTOs.Response.Vehicle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IVehicle
    {
        Task<GeneralResponse> AddVehicle(CreateVehicleRequestDto model);
        Task<IEnumerable<GetVehicleResponseDto>> GetVehicles();
        Task<GetVehicleResponseDto> GetVehicle(int id);
        Task<GeneralResponse> DeleteVehicle(int id);
        Task<GeneralResponse> UpdateVehicle(UpdateVehicleRequestDto model);


        Task<GeneralResponse> AddVehicleBrand(CreateVehicleBrandRequestDto model);
        Task<IEnumerable<GetVehicleBrandResponseDto>> GetVehicleBrands();
        Task<GetVehicleBrandResponseDto> GetVehicleBrand(int id);
        Task<GeneralResponse> DeleteVehicleBrand(int id);
        Task<GeneralResponse> UpdateVehicleBrand(UpdateVehicleBrandRequestDto model);


        Task<GeneralResponse> AddVehicleOwner(CreateVehicleOwnerRequestDto model);
        Task<IEnumerable<GetVehicleOwnerResponseDto>> GetVehicleOwners();
        Task<GetVehicleOwnerResponseDto> GetVehicleOwner(int id);
        Task<GeneralResponse> DeleteVehicleOwner(int id);
        Task<GeneralResponse> UpdateVehicleOwner(UpdateVehicleOwnerRequestDto model);
    }
}
