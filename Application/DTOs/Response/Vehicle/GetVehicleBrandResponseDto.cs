using Application.DTOs.Request.Vehicles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Response.Vehicle
{
    public class GetVehicleBrandResponseDto:CreateVehicleBrandRequestDto
    {
        public int Id { get; set; }
        public virtual ICollection<GetVehicleResponseDto> GetVehicles { get; set; } = null;
    }
}
