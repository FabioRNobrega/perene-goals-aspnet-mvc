using System;
using System.ComponentModel.DataAnnotations; 

namespace perene_goals_dotnet.Models;

public class Learning
{
        [Key]
        public int Id { get; set; } 

        [Required]
        public string Title { get; set; }  = string.Empty; 

        [Required]
        public string Description { get; set; }  = string.Empty; 

        [Required]
        public string Author { get; set; }  = string.Empty; 

        public string? ReferenceLink { get; set; }

        public string? ImageLink { get; set; }
}
