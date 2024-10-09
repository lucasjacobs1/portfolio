using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO.Requests
{
    public class CreatePostRequest
    {
        [Required(ErrorMessage = "CommunityId is required")]
        [Range(0, int.MaxValue, ErrorMessage = "CommunityId must be a positive integer")]
        public int CommunityId { get; set; }
        [Required(ErrorMessage = "UserId is required")]
        [Range(0, int.MaxValue, ErrorMessage = "UserId must be a positive integer")]
        public int UserId { get; set; }
        [Required(ErrorMessage = "Content is required")]
        [StringLength(255, ErrorMessage = "Content length cannot exceed 255 characters")]
        public string Content { get; set; } = string.Empty;
    }
}
