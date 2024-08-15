using Application.DTOs.Request.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Response.Vehicle
{
    public class GetVehicleResponseDto:VehicleBaseDto
    {
        public int Id { get; set; }
        public virtual GetVehicleBrandResponseDto VehicleBrand { get; set; } = null;
        public virtual GetVehicleOwnerResponseDto VehicleOwner { get; set; } = null;
    }
}
