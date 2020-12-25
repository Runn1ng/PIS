using MySql.Data.EntityFrameworkCore.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.Models
{
    [MySqlCharset("UTF-8")]
    public class PlanDistrict
    {
        public int Id { get; set; }
        [ForeignKey("Plan")]
        public int Plan_id { get; set; }
        [Column(TypeName = "nvarchar"), MySqlCharset("UTF-8")]
        public string Address { get; set; }
        public int Day { get; set; }

        public virtual Plan Plan { get; set; }
    }
}
