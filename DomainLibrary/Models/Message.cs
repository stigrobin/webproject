using DatingApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLibrary.Models
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Content { get; set; }

        [ForeignKey("ApplicationUser")]
        public string Author { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        [ForeignKey("Profile")]
        public int Receiver { get; set; }
        public Profile Profile { get; set; }
    }
}
