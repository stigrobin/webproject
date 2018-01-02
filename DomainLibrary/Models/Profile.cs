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
    public class Profile
    {
        public virtual string Id { get; set; }

        public string Presentation { get; set; }

        //public byte[] Image { get; set; }


    }
}
