using Application.Contracts;
using Application.DTOs.Request.Vehicles;
using Application.DTOs.Response;
using Application.DTOs.Response.Vehicle;
using Domain.Entity.VehicleEntity;
using Infrastructure.Data;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repos
{
    public class VehicleRepo(AppDbContext Context):IVehicle
    {
        private async Task<Vehicle> FindVehicleByName(string name) => await Context.Vehicles.FirstOrDefaultAsync(v => v.Name.ToLower() == name.ToLower());
        private async Task<VehicleOwner> FindVehicleOwnerByName(string name) => await Context.VehicleOwners.FirstOrDefaultAsync(v => v.Name.ToLower() == name.ToLower());
        private async Task<VehicleBrand> FindVehicleBrandByName(string name) => await Context.VehicleBrands.FirstOrDefaultAsync(v => v.Name.ToLower() == name.ToLower());
        private async Task<Vehicle> FindVehicleById(int id) => await Context.Vehicles.FirstOrDefaultAsync(v => v.Id == id);
        private async Task<VehicleOwner> FindVehicleOwnerById(int id) => await Context.VehicleOwners.FirstOrDefaultAsync(v => v.Id == id);
        private async Task<VehicleBrand> FindVehicleBrandById(int id) => await Context.VehicleBrands.FirstOrDefaultAsync(v => v.Id == id);
        private async Task SaveChangesAsync()=>await Context.SaveChangesAsync();
        private static GeneralResponse NullResponse(string message) => new(false, message);
        private static GeneralResponse AlreadyExistResponse(string message) => new(false, message);
        private static GeneralResponse OperationSuccessResponse(string message) => new(true, message);

        public async Task<GeneralResponse> AddVehicle(CreateVehicleRequestDto model)
        {
            if (await FindVehicleByName(model.Name) is not null) return AlreadyExistResponse("Vehicle already exist");
            Context.Vehicles.Add(model.Adapt(new Vehicle()));
            await SaveChangesAsync();
            return OperationSuccessResponse("Vehicle data saved");
        }

        public async Task<IEnumerable<GetVehicleResponseDto>> GetVehicles()
        {
            var data = (await Context.Vehicles.Include(b => b.VehicleBrand).Include(o => o.VehicleOwner).ToListAsync());
            return data.Select(vehicle => new GetVehicleResponseDto
            {
                Id = vehicle.Id,
                Name = vehicle.Name,
                Description = vehicle.Description,
                VehicleOwnerId = vehicle.VehicleOwnerId,
                VehicleBrandId = vehicle.VehicleOwnerId,
                VehicleBrand = new GetVehicleBrandResponseDto()
                {
                    Id = vehicle.VehicleBrand.Id,
                    Name = vehicle.VehicleBrand.Name,
                    Location = vehicle.VehicleBrand.Location
                },
                VehicleOwner = new GetVehicleOwnerResponseDto()
                {
                    Id = vehicle.VehicleBrand.Id,
                    Name = vehicle.VehicleOwner.Name,
                    Address = vehicle.VehicleOwner.Address
                }
            }).ToList();
        }

        public async Task<GetVehicleResponseDto> GetVehicle(int id) => (await FindVehicleById(id)).Adapt(new GetVehicleResponseDto());


        public  async Task<GeneralResponse> DeleteVehicle(int id)
        {
            if (await FindVehicleById(id) is null) 
                return NullResponse("Vehicle not found ");
            Context.Vehicles.Remove((await FindVehicleById(id)));
            await SaveChangesAsync();
            return OperationSuccessResponse("Vehicle deleted");
        }

        public async Task<GeneralResponse> UpdateVehicle(UpdateVehicleRequestDto model)
        {
            if (await FindVehicleById(model.Id) is null) return NullResponse("Vehicle not exist");
            Context.Entry(FindVehicleById(model.Id)).State = EntityState.Detached;
            Context.Vehicles.Update(model.Adapt(new Vehicle()));
            await SaveChangesAsync();
            return OperationSuccessResponse("Vehicle data updated");
        }

        public async Task<GeneralResponse> AddVehicleBrand(CreateVehicleBrandRequestDto model)
        {
            if (await FindVehicleBrandByName(model.Name) is not null) return AlreadyExistResponse("Vehicle Brand already exist");
            Context.VehicleBrands.Add(model.Adapt(new VehicleBrand()));
            await SaveChangesAsync();
            return OperationSuccessResponse("Vehicle Brand data saved");
        }

        public async Task<IEnumerable<GetVehicleBrandResponseDto>> GetVehicleBrands() => (await Context.VehicleBrands.ToListAsync()).Adapt(new List<GetVehicleBrandResponseDto>());

        public async Task<GetVehicleBrandResponseDto> GetVehicleBrand(int id)=> (await FindVehicleBrandById(id)).Adapt(new GetVehicleBrandResponseDto());


        public async Task<GeneralResponse> DeleteVehicleBrand(int id)
        {
            if (await FindVehicleBrandById(id) is null)
                return NullResponse("Vehicle Brand not found");
            Context.VehicleBrands.Remove(await FindVehicleBrandById(id));
            await SaveChangesAsync();
            return OperationSuccessResponse("Vehicle Brand deleted");
        }

        public async Task<GeneralResponse> UpdateVehicleBrand(UpdateVehicleBrandRequestDto model)
        {
            if (await FindVehicleBrandById(model.Id) is null) return NullResponse("Vehicle brand not exist");
            Context.Entry(FindVehicleBrandById(model.Id)).State = EntityState.Detached;
            Context.Vehicles.Update(model.Adapt(new Vehicle()));
            await SaveChangesAsync();
            return OperationSuccessResponse("Vehicle brand data updated");
        }

        public async Task<GeneralResponse> AddVehicleOwner(CreateVehicleOwnerRequestDto model)
        {
            if (await FindVehicleOwnerByName(model.Name) is not null) return AlreadyExistResponse("Vehicle owner already exist");
            Context.VehicleOwners.Add(model.Adapt(new VehicleOwner()));
            await SaveChangesAsync();
            return OperationSuccessResponse("Vehicle owner data saved");
        }

        public async Task<IEnumerable<GetVehicleOwnerResponseDto>> GetVehicleOwners()=>(await Context.VehicleOwners.ToListAsync()).Adapt(new List<GetVehicleOwnerResponseDto>());

        public async Task<GetVehicleOwnerResponseDto> GetVehicleOwner(int id)=> (await FindVehicleOwnerById(id)).Adapt(new GetVehicleOwnerResponseDto());


        public async Task<GeneralResponse> DeleteVehicleOwner(int id)
        {
            if (await FindVehicleOwnerById(id) is null)
                return NullResponse("Vehicle Owner not found  ");
            Context.VehicleOwners.Remove(await FindVehicleOwnerById(id));
            await SaveChangesAsync();
            return OperationSuccessResponse("Vehicle deleted");
        }

        public async Task<GeneralResponse> UpdateVehicleOwner(UpdateVehicleOwnerRequestDto model)
        {
            if (await FindVehicleOwnerById(model.Id) is null) return NullResponse("Vehicle owner not exist");
            Context.Entry(FindVehicleOwnerById(model.Id)).State = EntityState.Detached;
            Context.Vehicles.Update(model.Adapt(new Vehicle()));
            await SaveChangesAsync();
            return OperationSuccessResponse("Vehicle owner data updated");
        }
    }
}
