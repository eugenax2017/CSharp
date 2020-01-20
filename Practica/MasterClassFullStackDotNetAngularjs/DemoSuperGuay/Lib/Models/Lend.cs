using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoSuperGuay.Lib.Models
{
    public class Lend : Entity
    {
        public bool IsReturned { get; set; }

        public DateTime RequestedOn { get; set; }

        public DateTime ReturnedOn { get; set; }

        public Guid MemberId { get; set; }
        public Member Member { get; set; }

        public Guid BookId { get; set; }
        public Book Book { get; set; }
    }
}
