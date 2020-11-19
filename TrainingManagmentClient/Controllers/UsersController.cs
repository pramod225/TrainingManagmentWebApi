using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using TrainingManagmentClient.Models;


namespace TrainingManagmentClient.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }
        // My Methods
        public static HttpClient client = new HttpClient();
        public UsersController()
        {
            if (client.BaseAddress == null)
            {
                client.BaseAddress = new Uri("https://localhost:44336/api/users/");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }

        }
        List<SelectListItem> GetRole()
        {
            IEnumerable<Role> roles;
            HttpResponseMessage res = client.GetAsync("GetRole").Result;
            roles = res.Content.ReadAsAsync<IEnumerable<Role>>().Result;

            var query = from p in roles
                        where p.roleID == 1 || p.roleID == 2
                        select new { p.roleID, p.roleName };
            List<SelectListItem> rolesList = new List<SelectListItem>();
            foreach (var element in query)
            {
                rolesList.Add(new SelectListItem
                {
                    Value = element.roleID.ToString(),
                    Text = element.roleName.ToString()
                });
            }
            return rolesList;
        }

        List<SelectListItem> GetManagers()
        {
            IEnumerable<User> Managers;
            HttpResponseMessage res = client.GetAsync("https://localhost:44336/api/users/").Result;
            Managers = res.Content.ReadAsAsync<IEnumerable<User>>().Result;

            var query = from p in Managers
                        where p.roleID == 2
                        select new { p.userId, p.firstName, p.lastName };
            List<SelectListItem> managersList = new List<SelectListItem>();

            foreach (var element in query)
            {
                managersList.Add(new SelectListItem
                {
                    Value = (element.userId).ToString(),
                    Text = element.firstName + " " + element.lastName
                });

            }
            return managersList;

        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.id = id;
            ViewBag.roleList = GetRole();
            ViewBag.managerList = GetManagers();
            return View();
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            User user = new User();
            ViewBag.roleList = GetRole();
            ViewBag.managerList = GetManagers();
            return View(user);
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {

            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.id = id;
            ViewBag.roleList = GetRole();
            ViewBag.managerList = GetManagers();
            return View();
        }

        // POST: Users/Edit/5
       
        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.id = id;
            ViewBag.roleList = GetRole();
            ViewBag.managerList = GetManagers();
            return View();
        }

       
    }
}
