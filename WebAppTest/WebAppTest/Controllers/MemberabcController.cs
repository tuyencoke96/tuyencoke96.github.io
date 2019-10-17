using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppTest.Models;

namespace WebAppTest.Controllers
{
    public class MemberabcController : Controller
    {
        // GET: Memberabc
        public ActionResult Index()
        {
            MemberList strMB = new MemberList();
            List<ManageMember> obj = strMB.getMember(string.Empty);
            return View(obj);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(ManageMember strMB)
        {
            if (ModelState.IsValid)
            {
                MemberList MB = new MemberList();
                MB.AddMembers(strMB);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}