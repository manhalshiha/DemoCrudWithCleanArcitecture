﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Request.Vehicles
{
    public class CreateVehicleBrandRequestDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
    }
}
