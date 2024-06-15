using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.DTOs.UserDto
{
    public interface IUserDto
    {
        public int ID { get; set; }

        public string FIRSTNAME { get; set; }

        public string LASTNAME { get; set; }

        public DateTime DOB { get; set; }
    }
}
