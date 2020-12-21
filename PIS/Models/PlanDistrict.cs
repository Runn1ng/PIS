using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.Models
{
    public class PlanDistrict
    {
        public int Id { get; set; }
        [ForeignKey("Plan")]
        public int Plan_id { get; set; }
        public string Address { get; set; }
        public int Day { get; set; }

        public virtual Plan Plan { get; set; }
    }
}
