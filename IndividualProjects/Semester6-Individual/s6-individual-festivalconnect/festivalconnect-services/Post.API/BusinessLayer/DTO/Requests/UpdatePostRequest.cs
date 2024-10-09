using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO.Requests
{
    public class UpdatePostRequest
    {
        [Required(ErrorMessage = "PostId is required")]
        [Range(0, int.MaxValue, ErrorMessage = "PostId must be a positive integer")]
        public int PostId { get; set; }

        [Required(ErrorMessage = "Content is required")]
        [StringLength(255, ErrorMessage = "Content length cannot exceed 255 characters")]
        public string Content { get; set; } = string.Empty;
    }
}
