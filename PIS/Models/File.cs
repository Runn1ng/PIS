using MySql.Data.EntityFrameworkCore.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIS.Models
{
    public class File
    {
        public int Id { get; set; }

        public string Path { get; set; }
    }
}
