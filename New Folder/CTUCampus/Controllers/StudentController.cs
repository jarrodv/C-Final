using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CTUCampus.Models;
using System.Web.Security;

namespace CTUCampus.Controllers
{
    public class StudentController : Controller
    {
        CampusEntities ce = new CampusEntities();
        // GET: Student
        [OutputCache(Duration = 120)]

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to the Home Page";
            return View("Index", ce.Students.ToList());
        }

        public ActionResult Details(int id)
        {
            Student student = ce.Students.Find(id);
            if(student != null)
            {
                return View("Details", student);
            }
            else
            {
                return HttpNotFound();
            }
        }
        //[RequireHttps]
        public ActionResult Create()
        {
            Student newStudent = new Student();
            return View("Create", newStudent);
        }

        [HttpPost]
        public ActionResult Create(Student newStudent)
        {
            if (ModelState.IsValid)
            {
                ce.Students.Add(newStudent);
                ce.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Create", newStudent);
            }
        }

        [HttpGet]
        [OutputCache(Duration = 60)]
        public PartialViewResult Message()
        {
            ViewBag.Message = "This display a list of students";
            return PartialView();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(CTUCampus.Models.Student sUser)
        {
            if (ModelState.IsValid)
            {
                if (IsValid(sUser.studentUserName, sUser.studentPassword))
                {
                    FormsAuthentication.SetAuthCookie(sUser.studentUserName, true);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Login details are wrong");
                }
            }
            return View(sUser);
        }

        public bool IsValid(string _username, string _password)
        {
            bool isValid = false;

            var User = ce.Students.FirstOrDefault(u => u.studentUserName == _username);
            
            if(User != null)
            {
                if (User.studentPassword == _password)
                {
                    Session["Name"] = User.studentName;
                    isValid = true;
                }
            }
            return isValid;
        }
    }
}