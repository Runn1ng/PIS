using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PIS.Models;

namespace PIS.UI.Components
{
    public class Filter
    {
        public int year_from = -1;
        public int year_to = -1;
        public int month_from = -1;
        public int month_to = -1;
        public int locality_id = -1;

        public bool CheckPlan(PIS.Models.Plan plan)
        {
            bool check = true;

            if (year_from > -1)
                check &= plan.Year > year_from;
            if (year_to > -1)
                check &= plan.Year < year_to;

            if (month_from > -1)
                check &= plan.Month >= month_from;
            if (month_to > -1)
                check &= plan.Month <= month_to;

            if (locality_id > -1)
                check &= plan.Locality_id == locality_id;

            return check;
        }

    }
}
