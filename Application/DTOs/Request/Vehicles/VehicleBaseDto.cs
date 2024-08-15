using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Request.Vehicles
{
    public class VehicleBaseDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [Range(1,100,ErrorMessage ="Select vehicle owner")]
        public int VehicleOwnerId { get; set;}
        [Range(1, 100, ErrorMessage = "Select vehicle brand")]
        public int VehicleBrandId { get; set; }
    }
}
