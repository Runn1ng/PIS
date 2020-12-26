using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIS.Models;
using PIS.UI.Components;

namespace PIS.Controllers
{
    public class PlanController
    {

        static DbContext db = new DbContext();
        public static List<Plan> GetPlans(bool published = false, Filter filter = null)
        {
            using(DbContext db = new DbContext())
            {
                if (filter == null)
                    return published ?
                        db.Plans.Where(x => x.Published == published).ToList() :
                        db.Plans.ToList();
                return published ?
                        db.Plans.Where(x => x.Published == published).ToList().Where(x => filter.CheckPlan(x)).ToList() :
                        db.Plans.ToList().Where(x => filter.CheckPlan(x)).ToList();
            }
        }


        public static Plan GetPlanByPK(int primaryKey)
        {
            using(DbContext db = new DbContext())
            {
                return db.Plans.First(x => x.Id == primaryKey);
            }
        }

        public static int SavePlan(dynamic values, Plan currentPlan = null, bool creation = true)
        {
            Plan plan = null;
            if (creation)
            {
                plan = new Plan();
                plan.Year = values.year;
                plan.Month = values.month;
                plan.Locality_id = values.locality;
                plan.Status = -1;
                plan.Date = DateTime.Now;
                plan.Note = values.note;
                plan.Published = values.published;
            }

            using (DbContext db = new DbContext())
            {
                if (creation)
                    db.Plans.Add(plan);
                else
                {
                    plan = db.Plans.First(x => x.Id == currentPlan.Id);
                    plan.Note = values.note;
                    plan.Published = values.published;
                    db.Entry(plan).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();

                if (creation)
                    PlanDistrictController.AddDistricts(plan.Id, values.districts);
            }

            return plan.Id;
        }

        public static void AttachFile(int plan_id, string path)
        {
            using (DbContext db = new DbContext())
            {
                var plan = db.Plans.First(x => x.Id == plan_id);
                plan.File_id = FileController.SaveFile(path);
                db.SaveChanges();
            }
        }

        public static void RemoveFile(int plan_id)
        {
            using(DbContext db = new DbContext())
            {
                var plan = db.Plans.First(x => x.Id == plan_id);
                int file_id = plan.File_id.GetValueOrDefault();
                plan.File_id = null;
                db.SaveChanges();
                FileController.DeleteFile(file_id);
            }
        }
    }
}
