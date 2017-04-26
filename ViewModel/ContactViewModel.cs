using System.ComponentModel.DataAnnotations;

namespace vega.ViewModel
{
    public class ContactViewModel
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Phone { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Email { get; set; }
    }
}