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
    public class Plan
    {

        public Plan ()
        {
            this.PlanDistrict = new HashSet<PlanDistrict>();
        }


        public int Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }

        [Column(TypeName = "nvarchar"), MySqlCharset("UTF-8")]
        public string Note { get; set; }
        
        [ForeignKey("Locality")]
        public int Locality_id { get; set; }

        [ForeignKey("File")]
        public Nullable<int> File_id { get; set; }
        
        public int Status { get; set; }
        public DateTime Date { get; set; }
        public bool Published { get; set; }


        public virtual Locality Locality { get; set; }
        public virtual File File { get; set; }

        public virtual ICollection<PlanDistrict> PlanDistrict { get; set; }
    }
}
