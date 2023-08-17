using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.EfClasses
{
    public class Review
    {
        public int ReviewId { get; set; }
        [MaxLength(50)]
        public string VoterName { get; set; }
        [MaxLength(200)]
        public string Comment { get; set; }
        public int NumStars { get; set; }
        public int ProductId { get; set; }
    }
}
