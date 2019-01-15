using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuthApp.Entities
{
    public class Resource
    {
        public int ResourceId { get; set; }
        [Required]
        [StringLength(50)]
        public string Controller { get; set; }
        [Required]
        [StringLength(50)]
        public string Action { get; set; }
        [StringLength(50)]
        public string Area { get; set; }
    }
}