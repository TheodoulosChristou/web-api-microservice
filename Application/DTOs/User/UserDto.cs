using Application.Interface.DTOs.UserDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.User
{
    public class UserDto : IUserDto
    {
        public int ID { get ; set ; }
        public string FIRSTNAME { get ; set ; }
        public string LASTNAME { get ; set ; }
        public DateTime DOB { get ; set ; }
    }
}
