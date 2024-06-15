using Application.Interface.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.User
{
    public class SearchUserCriteriaDto : ISearchUserCriteriaDto
    {
        public string? FIRSTNAME { get ; set ; }
        public string? LASTNAME { get ; set ; }
        public DateTime? DOB { get ; set ; }
    }
}
