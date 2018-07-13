using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVCv13.Models.DB;
using System.Data.SqlClient;
using System.Data;
using System.Web.Services.Protocols;

namespace WebMVCv13.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autherize(Account ac)
        {
            using (ModelDBContext mvc = new ModelDBContext())
            {
                var Data = mvc.Accounts.Where(x => x.UserName == ac.UserName && x.PassWord == ac.PassWord).FirstOrDefault();
                //var result = "Fail";
                //var Data = mvc.Accounts.Where(x => x.UserName == model.UserName && x.PassWord == model.PassWord).SingleOrDefault();
                if (Data != null)
                {
                    Session["ID"] = Data.ID;
                    Session["UserName"] = Data.UserName;
                    //result = "Success";
                    return RedirectToAction("Index", "Accounts");
                }
                    //ac.MessErr = "Username or Password Invalid!";
                return View("Index", ac);
            }
        }

        [HttpPost]
        public ActionResult CreateAccount( Account Ac)
        {
            try
            {
                using (ModelDBContext mvc = new ModelDBContext())
                {
                    if (Ac.UserName == null || Ac.PassWord == null)
                    {
                    }
                    else if (mvc.Accounts.Where(x => x.UserName.Equals(Ac.UserName)).ToList().Count == 0)
                    {
                        if (ModelState.IsValid )
                        {
                            mvc.Accounts.Add(Ac);
                            mvc.SaveChanges();

                        }

                    }

                    else
                    {

                    }
                }
            }
            catch
            {
                return View("Index", Ac);
            }
            return View("Index", Ac);
        }
    }

}
