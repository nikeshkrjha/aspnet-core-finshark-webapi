using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos
{
    public class CreateCommentDTO
    {
        [Required]
        [MinLength(5, ErrorMessage = "Title must be 5 characters.")]
        [MaxLength(250, ErrorMessage = "Title cannot be over 250 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [MinLength(5, ErrorMessage = "Title must be 5 characters.")]
        [MaxLength(250, ErrorMessage = "Title cannot be over 250 characters.")]
        public string Description { get; set; } = string.Empty;
    }
}