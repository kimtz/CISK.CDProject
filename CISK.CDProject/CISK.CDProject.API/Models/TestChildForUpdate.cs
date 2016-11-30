﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CISK.CDProject.API.Models
{
    public class TestChildForUpdate
    {
        [Required(ErrorMessage = "You shoud provide a name")]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }
}
