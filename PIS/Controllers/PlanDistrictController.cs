using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIS.Models;

namespace PIS.Controllers
{
    public class PlanDistrictController
    {
        public static void AddDistricts(int planId, Dictionary<string, List<int>> districts)
        {
            using(DbContext db = new DbContext())
            {
                foreach(var address in districts.Keys)
                {
                    foreach(var day in districts[address])
                    {
                        var pd = new PlanDistrict();
                        pd.Plan_id = planId;
                        pd.Address = address;
                        pd.Day = day;
                        db.PlanDistricts.Add(pd);
                    } 
                }
                db.SaveChanges();
            }
        }
    }
}
