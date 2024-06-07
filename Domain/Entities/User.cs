using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string FIRSTNAME { get; set; }

        [StringLength(255)]
        public string LASTNAME { get; set; }

        public DateTime DOB { get; set; }
    }
}
