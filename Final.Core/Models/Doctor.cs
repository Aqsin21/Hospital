using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Final.Core.Models
{
    public  class Doctor  : BaseEntity 
    {
        [Required]
        [StringLength(50)]
        public int FullName { get; set; }

        [Required]
        public string Experience { get; set; }
        [Required]
        [StringLength (300)]
        public string Description { get; set; }
        [StringLength(50)]
        public string? ImageUrl { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
