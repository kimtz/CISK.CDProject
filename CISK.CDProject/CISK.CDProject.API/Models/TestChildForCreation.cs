﻿using System.ComponentModel.DataAnnotations;

namespace CISK.CDProject.API.Models
{
    public class TestChildForCreation
    {
        [Required(ErrorMessage = "You shoud provide a name")]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }
}
