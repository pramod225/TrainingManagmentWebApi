using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Mvc;

using TrainingManagmentWebApi.Models;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace TrainingManagmentWebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsersController : ApiController
    {
        public  UserDbContext db = new UserDbContext();

        void InitilazieRoles()
        {

            Role role1 = new Role { roleID = 1, roleName = "User" };
            Role role2 = new Role { roleID = 2, roleName = "Manager" };
            Role role3 = new Role() { roleID = 3, roleName = "Admin" };
            db.roles.Add(role1); db.roles.Add(role2); db.roles.Add(role3);
            db.SaveChanges();

        }
        public UsersController()
        {
            if (db.roles.Count() == 0)
            {
                InitilazieRoles();
            }

        }
        [Route("api/Users/GetRole")]
        public IQueryable<Role> GetRole()
        {
            return db.roles;
        }


        // GET: api/Users
        public IQueryable<User> Getusers()
        {
            return db.users;
        }

        // GET: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = db.users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        List<SelectListItem> FillRoles()
        {
            List<SelectListItem> roleList = new List<SelectListItem>() {
            new SelectListItem
            {
                Text = "User",
                Value = "1"
            },
        new SelectListItem
        {
            Text = "Manager",
            Value = "2"
        },
        };
            return roleList;
        }
        List<SelectListItem> GetManagers()
        {

            var query = from p in db.users
                        where p.roleID == 2
                        select new { p.managerID, p.firstName, p.lastName };
            List<SelectListItem> managersList = new List<SelectListItem>();
            foreach (var element in query)
            {
                managersList.Add(new SelectListItem
                {
                    Value = element.managerID.ToString(),
                    Text = element.firstName.ToString() + " " + element.lastName.ToString()
                });
            }
            return managersList;
        }

        // PUT: api/Users/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.userId)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;
            
            try
            {
                User user1 = db.users.Where(x => x.userName == user.userName).FirstOrDefault();
                if (user1 != null)
                {
                    user.userName = user.firstName + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + user.userId;
                    db.users.Add(user1);
                    db.SaveChanges();
                    
                }
                else
                {
                    
                }
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Users
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.users.Add(user);
            db.SaveChanges();
           
            return CreatedAtRoute("DefaultApi", new { id = user.userId }, user);
        }

        // DELETE: api/Users/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.users.Count(e => e.userId == id) > 0;
        }
    }
}