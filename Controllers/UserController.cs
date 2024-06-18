using CRUD_application_2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        // Example: Static list for demonstration purposes
        public static List<User> userlist = new List<User>
        {
            new User { Id = 1, Name = "John Doe", Email = "john.doe@example.com" },
            new User { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com" }
            // Add more users as needed
        };

        // GET: User/Index
        public ActionResult Index()
        {
            return View(userlist); // Pass the list of users to the view
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            User user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound(); // Return HttpNotFoundResult if user with given id is not found
            }
            return View(user); // Return view with user data
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                // Example: Adding user to the static list (simulate saving)
                user.Id = userlist.Count + 1;
                userlist.Add(user);

                return RedirectToAction("Index"); // Redirect to index after successful creation
            }
            return View(user); // If ModelState is not valid, return the Create view with errors
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            User user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound(); // Return HttpNotFoundResult if user with given id is not found
            }
            return View(user); // Return view with user data
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            if (ModelState.IsValid)
            {
                User existingUser = userlist.FirstOrDefault(u => u.Id == id);
                if (existingUser != null)
                {
                    // Update user data (simulate updating in the static list)
                    existingUser.Name = user.Name;
                    existingUser.Email = user.Email;

                    return RedirectToAction("Index"); // Redirect to index after successful update
                }
                else
                {
                    return HttpNotFound(); // Return HttpNotFoundResult if user with given id is not found
                }
            }
            return View(user); // If ModelState is not valid, return the Edit view with errors
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            User user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound(); // Return HttpNotFoundResult if user with given id is not found
            }
            return View(user); // Return view with user data
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            User user = userlist.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                // Remove user from the static list (simulate deletion)
                userlist.Remove(user);

                return RedirectToAction("Index"); // Redirect to index after successful deletion
            }
            return HttpNotFound(); // Return HttpNotFoundResult if user with given id is not found
        }
    }
}
