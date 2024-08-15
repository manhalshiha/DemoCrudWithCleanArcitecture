using Application.Contracts;
using Application.DTOs.Request.Vehicles;
using Application.DTOs.Response;
using Application.DTOs.Response.Vehicle;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController(IVehicle vehicle) : ControllerBase
    {
        //Post /Create
        [HttpPost("add-vehicle")]
        public async Task<ActionResult<GeneralResponse>> Create(CreateVehicleRequestDto model) => Ok(await vehicle.AddVehicle(model));
        [HttpPost("add-vehicle-owner")]
        public async Task<ActionResult<GeneralResponse>> Create(CreateVehicleOwnerRequestDto model) => Ok(await vehicle.AddVehicleOwner(model));
        [HttpPost("add-vehicle-brand")]
        public async Task<ActionResult<GeneralResponse>> Create(CreateVehicleBrandRequestDto model) => Ok(await vehicle.AddVehicleBrand(model));

        //Get / Single
        [HttpGet("get-vehicle/{id}")]
        public async Task<ActionResult<GetVehicleResponseDto>> Get(int id) => Ok(await vehicle.GetVehicle(id));
        [HttpGet("get-vehicle-brand/{id}")]
        public async Task<ActionResult<GetVehicleBrandResponseDto>> GetBrand(int id) => Ok(await vehicle.GetVehicleBrand(id));
        [HttpGet("get-vehicle-owner/{id}")]
        public async Task<ActionResult<GetVehicleOwnerResponseDto>> GetOwner(int id) => Ok(await vehicle.GetVehicleOwner(id));

        //Get / List
        [HttpGet("get-vehicles")]
        public async Task<ActionResult<IEnumerable<GetVehicleResponseDto>>> Gets() => Ok(await vehicle.GetVehicles());
        [HttpGet("get-vehicle-brands")]
        public async Task<ActionResult<IEnumerable<GetVehicleBrandResponseDto>>> GetBrands() => Ok(await vehicle.GetVehicleBrands());
        [HttpGet("get-vehicle-Owners")]
        public async Task<ActionResult<IEnumerable<GetVehicleOwnerResponseDto>>> GetOwners() => Ok(await vehicle.GetVehicleOwners());

        //Update
        [HttpPut("update-vehicle")]
        public async Task<ActionResult<GeneralResponse>> Update(UpdateVehicleRequestDto model) => Ok(await vehicle.UpdateVehicle(model));
        [HttpPut("update-vehicle-brand")]
        public async Task<ActionResult<GeneralResponse>> UpdateBrand(UpdateVehicleBrandRequestDto model) => Ok(await vehicle.UpdateVehicleBrand(model));
        [HttpPut("update-vehicle-owner")]
        public async Task<ActionResult<GeneralResponse>> UpdateOwner(UpdateVehicleOwnerRequestDto model) => Ok(await vehicle.UpdateVehicleOwner(model));
        //Delete
        [HttpDelete("delete-vehicle/{id}")]
        public async Task<ActionResult<GeneralResponse>> Delete(int id) => Ok(await vehicle.DeleteVehicle(id));
        [HttpDelete("delete-vehicle-brand/{id}")]
        public async Task<ActionResult<GeneralResponse>> DeleteBrand(int id) => Ok(await vehicle.DeleteVehicleBrand(id));
        [HttpDelete("delete-vehicle-owner/{id}")]
        public async Task<ActionResult<GeneralResponse>> DeleteOwner(int id) => Ok(await vehicle.DeleteVehicleOwner(id));
    }
}
