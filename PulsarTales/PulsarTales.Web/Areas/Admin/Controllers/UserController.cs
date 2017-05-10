using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PulsarTales.Models.Entities;
using PulsarTales.Models.ViewModels.Areas.Admin;
using PulsarTales.Services.Areas.Admin;

namespace PulsarTales.Web.Areas.Admin.Controllers
{
    [RoutePrefix("user")]
    public class UserController : Controller
    {
        private UserService service;

        public UserController()
        {
            this.service = new UserService();
        }
        // GET: User

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        // GET: User/List

        public ActionResult List()
        {
            var users = this.service.GetAllUsers();
            var admins = this.service.GetAdminUserNames(users);
            ViewBag.Admins = admins;

            return View(users);
        }
        // GET: User/Edit
        public ActionResult Edit(string id)
        {
            // Validate Id
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            // Get user from database
            var user = this.service.GetUser(id);
            var userManager = HttpContext.GetOwinContext()
                                            .GetUserManager<ApplicationUserManager>();

            // Check if user exists
            if (user == null)
                {
                    return HttpNotFound();
                }
            var userRoles = new List<Role>();

            var roles = this.service.GetAllRoles();
            foreach (var roleName in roles)
            {
                var role = new Role() { Name = roleName };

                if (userManager.IsInRole(user.Id, roleName))
                {
                    role.IsSelected = true;
                }

                userRoles.Add(role);
            }

            // Create view model
            var viewModel = new EditUserViewModel();
                viewModel.User = user;
                viewModel.Roles = userRoles;

            // Pass the model to the view
            return View(viewModel);
        }

        // POST: User/Edit
        [System.Web.Mvc.HttpPost]
        public ActionResult Edit(string id, EditUserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Get user from database
                var user = this.service.GetUser(id);

                // Check if user exists
                if (user == null)
                {
                    return HttpNotFound();
                }

                // If password field is not empty, change password
                if (!string.IsNullOrEmpty(viewModel.Password))
                {
                    var hasher = new PasswordHasher();
                    var passwordHash = hasher.HashPassword(viewModel.Password);
                    user.PasswordHash = passwordHash;
                }
                // Set user properties
                user.Email = viewModel.User.Email;
                user.UserName = viewModel.User.UserName;
                var userManager = HttpContext.GetOwinContext()
                                        .GetUserManager<ApplicationUserManager>();

                foreach (var role in viewModel.Roles)
                {
                    if (role.IsSelected && !userManager.IsInRole(user.Id, role.Name))
                    {
                        userManager.AddToRole(user.Id, role.Name);
                    }
                    else if (!role.IsSelected && userManager.IsInRole(user.Id, role.Name))
                    {
                        userManager.RemoveFromRole(user.Id, role.Name);
                    }
                }
                // Save changes
                this.service.DbContext.Entry(user).State = System.Data.Entity.EntityState.Modified;
                this.service.DbContext.SaveChanges();

                return RedirectToAction("List");
                
            }

            return View(viewModel);
        }

        // GET: User/Delete
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
             // Get user from database
            var user = this.service.GetUser(id);

            // Check if user exists
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        // POST: User/Delete
        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.ActionName("Delete")]
        public ActionResult DeleteConfirmed(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            // Get user from database
            var user =  this.service.GetUser(id);
            if (user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                this.service.MarkUserAsDeleted(id);
            }
                

            return RedirectToAction("List");
            
        }
        
    }
}