using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLibrary.Models
{
    public class Friend
    {
        public virtual int Id { get; set; }



        [ForeignKey("RequestedBy")]
        public virtual string RequestedBy_Id { get; set; }
        public virtual ApplicationUser RequestedBy { get; set; }


        [ForeignKey("RequestedTo")]
        public virtual string RequestedTo_Id { get; set; }
        public virtual ApplicationUser RequestedTo { get; set; }

        public bool RequestStatuts { get; set; }
    }
}