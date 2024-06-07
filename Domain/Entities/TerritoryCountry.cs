using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Template
    {
        [StringLength(6)]
        public string templateId { get; set; }
        
    }
}
