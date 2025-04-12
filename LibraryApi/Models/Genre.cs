﻿using System.ComponentModel.DataAnnotations;

namespace LibraryApi.Models
{
    public class Genre : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
