using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate.AspNet.Identity;
using SharpArch.NHibernate;

namespace NHibernate.AspNet.Web.Controllers
{
    public class RoleController : Controller
    {
        private ISession _session = NHibernateSession.Current;
        // GET: Role
        [Authorize]
        public ActionResult Index()
        {

            var roleStore = new RoleStore<IdentityRole>(_session);
            var list = roleStore.Roles;

            return View(list);
        }
    }
}