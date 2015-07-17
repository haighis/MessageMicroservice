using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class MessageViewModel
    {
        [Required(
            AllowEmptyStrings = false,
            ErrorMessage = "Please enter a message"
            )]
        [MaxLength(256)]
        [Display(Name = "Message")]
        public string Message { get; set; }
    }
}