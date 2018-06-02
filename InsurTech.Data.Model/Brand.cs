using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InsurTech.Data.Model
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }

        public string BrandName { get; set; }

        public bool IsActive { get; set; }
    }
}
