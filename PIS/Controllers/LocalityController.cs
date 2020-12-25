using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIS.Models;

namespace PIS.Controllers
{
    public class LocalityController
    {
        public static List<Locality> GetLocalities()
        {
            using(DbContext db = new DbContext())
            {
                return db.Localities.ToList();
            }
        }
    }
}
