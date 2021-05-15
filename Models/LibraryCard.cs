﻿using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Library.Models
{
    public class LibraryCard
    {
        [Key]
        public int LibraryCardId { get; set; }

        [Required]
        public BookDto TakenBook { get; set; }

        [Required]
        public PersonDto PersonTookBook { get; set; }

        [Required]
        public static DateTimeOffset BookTakenDate { get; set; }
    }   
}
