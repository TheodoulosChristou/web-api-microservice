using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface.DTOs
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreationDttm { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModifiedDttm { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
