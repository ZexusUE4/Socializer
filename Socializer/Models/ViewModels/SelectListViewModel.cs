using Socializer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Socializer.Models.ViewModels
{
    public class SelectListViewModel
    {

        public static IEnumerable<System.Web.Mvc.SelectListItem> GetAllTowns()
        {
            SocializerContext db = new SocializerContext();
            IEnumerable<System.Web.Mvc.SelectListItem> AllTowns = db.Towns.Select(c => new System.Web.Mvc.SelectListItem()
            {
                Value = c.ID.ToString(),
                Text = c.Name
            });

            return AllTowns;
        }
    }
}