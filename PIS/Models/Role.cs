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
    public class Role
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar"), MySqlCharset("UTF-8")]
        public string Name { get; set; }
    }
}
