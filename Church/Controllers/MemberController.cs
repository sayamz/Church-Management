using Church.DAL;
using Church.Helpers;
using Church.Models;
using Church.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Church.Controllers
{
    public class MemberController : Controller
    {
        private DataContext context = new DataContext();
        public ActionResult Index()
        {

            IEnumerable<MemberViewModel> members = from m in context.Member
                                                   select new MemberViewModel()
                                                   {
                                                       Id = m.Id,
                                                       FirstName = m.FirstName,
                                                       MiddleName = m.MiddleName,
                                                       LastName = m.LastName,
                                                       CellPhone = m.CellPhone,
                                                       Address = m.Address,
                                                       City = m.City,
                                                       PostalCode = m.PostalCode,
                                                       Gender = m.Gender,
                                                       Department = m.Department,
                                                       Email = m.Email,
                                                       HomePhone = m.HomePhone,
                                                       Profession = m.Profession,
                                                       Transactions=m.Transactions,
                                                       Status = m.Status
                                                   };

            return View(members);
        }

        public ActionResult Add()
        {
            var model = new MemberViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(MemberViewModel model)
        {
            if (ModelState.IsValid)
            {
                var member = new Member()
                {
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    Address = model.Address,
                    City = model.City,
                    PostalCode = model.PostalCode,
                    Province = model.Province,
                    Profession = model.ProfessionId > 0 ? context.Profession.Find(model.ProfessionId) : null,
                    HomePhone = model.HomePhone,
                    CellPhone = model.CellPhone,

                    Department = model.DepartmentId > 0 ? context.Department.Find(model.DepartmentId) : null,
                    Email = model.Email,
                    Status=RecordStatus.Active
                };
                context.Member.Add(member);
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {
            var member = context.Member.Find(Id);
            var model = new MemberViewModel()
            {
                Id = member.Id,
                FirstName = member.FirstName,
                MiddleName = member.MiddleName,
                LastName = member.LastName,
                CellPhone = member.CellPhone,
                Address = member.Address,
                City = member.City,
                PostalCode = member.PostalCode,
                Province = member.Province,
                Gender = member.Gender,
                Department = member.Department,
                Email = member.Email,
                HomePhone = member.HomePhone,
                Profession = member.Profession,
                Status = member.Status
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MemberViewModel model)
        {
            var member = context.Member.Find(model.Id);
            if (member != null)
            {
                member.FirstName = model.FirstName;
                member.MiddleName = model.MiddleName;
                member.LastName = model.LastName;
                member.Email = model.Email;
                member.CellPhone = model.CellPhone;
                member.Address = model.Address;
                member.City = model.City;
                member.Province = model.Province;
                member.Department = model.Department;
                member.HomePhone = model.HomePhone;
                member.PostalCode = model.PostalCode;
                member.Profession = model.Profession;

                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public JsonResult Delete(int Id)
        {
            var member = context.Member.Find(Id);
            if (member != null)
            {
                member.Status = RecordStatus.Deleted;
                context.SaveChanges();
            }

            return Json(string.Empty, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProfessions(string term = "")
        {
            var lowerTerm = term.ToLowerInvariant();
            var server = from s in context.Profession
                         where s.Name.ToLower().Contains(lowerTerm) ||
                         s.Description.ToLower().Contains(lowerTerm)
                         select new
                         {
                             label = s.Name,
                             id = s.Id
                         };
            return Json(server, JsonRequestBehavior.AllowGet);
        }
    }
}
