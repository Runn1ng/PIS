using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.Models
{
    public class Locality
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar")] public string Name { get; set; }
    }
}