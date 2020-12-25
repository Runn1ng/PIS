using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIS.Models;

namespace PIS.Controllers
{
    public class PlanController
    {

        static DbContext db = new DbContext();
        public static List<Plan> GetPlans(bool published = false)
        {
            return published ?
                    db.Plans.Where(x => x.Published == published).ToList() :
                    db.Plans.ToList();
        }

        public static Plan GetPlanByPK(int primaryKey)
        {
            return db.Plans.First(x => x.Id == primaryKey);
        }

        public static int SavePlan(dynamic values, bool creation = true)
        {
            Plan plan;
            if (creation)
                plan = new Plan();
            else
                plan = GetPlanByPK(values.id);
            plan.Year = values.year;
            plan.Month = values.month;
            plan.Locality_id = values.locality;
            plan.Note = values.note;
            plan.Published = values.published;
            plan.Status = -1;
            plan.Date = DateTime.Now;

            using (DbContext db = new DbContext())
            {
                if (creation)
                    db.Plans.Add(plan);
                else
                    db.Entry(plan).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                PlanDistrictController.AddDistricts(plan.Id, values.districts);
            }

            return plan.Id;
        }
    }
}
