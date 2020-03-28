using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CaseCaddingDDL.Models
{
    public class CountryMaster
    {
        [Key]
        public int CountryId { get; set; }
        public string CountryName { get; set; }

        [ForeignKey("CountryId")]
        public ICollection<StateMaster> States { get; set; }
    }
}
