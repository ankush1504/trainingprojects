using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using System.Web;
using System.Web.Mvc;
using LoginFrontPage.Models;
using MailKit;
using MailKit.Net.Smtp;
using MimeKit;

namespace LoginFrontPage.Controllers
{
    public class HomeController : Controller
    {
        UserDatabaseEntities ent = new UserDatabaseEntities();
        string data;

        public ActionResult FirstPage()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
    
        public ActionResult ForgetPassword()
        {

            return View();
        }
        [HttpPost]
        public ActionResult ForgetPassword(Corporate corp,[Bind (Include ="otp")]FormCollection form)
        {

           
            //SendEmail(form["email"].ToLower());
            SendEmail(corp.Email);

            //TempData["email"] = form["email"];
            TempData["email"] = corp.Email;
            if (TempData["email"] != null)
                data = TempData["email"] as string;

            TempData.Keep("email");

           // TempData.Peek("email");


            return View();
        }
        public ActionResult ResetPassword()
        {
         
            return View();
        }
        [HttpPost]
        public ActionResult ResetPassword(FormCollection form)
        {

            string email1 = TempData["email"].ToString();
            string pass1 = form["pass"];
            string pass2 = form["conpass"];
            Corporate user = ent.Corporates.Where(x => x.Email == email1).FirstOrDefault();
            if (ModelState.IsValid)
            {
                if (user.otp == form["otp"])
                {
                    if (pass1 == pass2)
                    {
                        user.Password = pass1;
                        ent.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Reset = "wrongPassword";
                    }
                 
                }
                else
                {
                    ViewBag.Reset = "wrong";
                    
                }

            }

            TempData.Keep("email");
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(Corporate user)
        {
        
                bool isvalidUser = ent.Corporates.Any(u => u.Email.ToLower() ==user.Email  && u.Password == user.Password);
                if (isvalidUser)
                {
                    System.Web.Security.FormsAuthentication.SetAuthCookie(user.FullName, false);
                    return RedirectToAction("Index", "Home");
                }
            else {
                ModelState.AddModelError("", "invalid username and password");
            }
            
            
            return View();
        }

        List<SelectListItem> DegreeList = new List<SelectListItem>()
        {
            new SelectListItem{Text="BE",Value="1"},
            new SelectListItem{Text="MS",Value="2"},
            new SelectListItem{Text="MTECH",Value="3"},
            new SelectListItem{Text="MCA",Value="4"},


        };
        public ActionResult Register()
        {
        

            ViewBag.Degree = DegreeList;

            return View();
        }

        [HttpPost]
        public ActionResult Register(FormCollection form, [Bind(Include = "Id,FullName,Gender,DOB,Email,Mobile,GradDegree,GradPerc,GradBranch,GradPassesYear,PrevCompany,ExpYears,YearSalary,TechStack1,TechStack2,TechStack3,Password,ConfirmPassword,otp")]Corporate corp)
        {
            bool chkjava = false;
            bool chkpython = false;
            bool  chkcsharp = false;
            string chkjavavalue = "";
            string chkpythonvalue = "";
            string chkcsharpvalue = "";
            if (!string.IsNullOrEmpty(form["tech1"])) { chkjava = true; }
            if (!string.IsNullOrEmpty(form["tech2"])) { chkpython = true; }
            if (!string.IsNullOrEmpty(form["tech3"])) { chkcsharp = true; }
            if (chkjava) { chkjavavalue = form["tech1"];
                corp.TechStack1 = chkjavavalue;
            }
            if (chkpython) { chkpythonvalue = form["tech2"];
                corp.TechStack2 = chkpythonvalue;
            }
            if (chkcsharp) { chkcsharpvalue = form["tech3"];
                corp.TechStack3 = chkcsharpvalue;
            }

            ViewBag.Degree = DegreeList;
            string degree = form["selecteddegree"];
            corp.GradDegree = degree;
         
                if (ModelState.IsValid)
                {
                    ent.Corporates.Add(corp);
                    ent.SaveChanges();
                    return RedirectToAction("Index");
                }
            
 

            return View();
        }
        public void SendEmail(string email)
        {
            string message = "This email address does not match our records.";
            Corporate user = ent.Corporates.Where(x => x.Email == email).FirstOrDefault();
            if (user != null)
            {

                string username = user.FullName;
                string password = user.Password;
                // to send the random password in email 
                string strNewPassword = GeneratePassword().ToString();
                user.otp = strNewPassword;
                ent.SaveChanges();
                if (!string.IsNullOrEmpty(password))
                {
                    MimeMessage mm = new MimeMessage();
                    MailboxAddress from = new MailboxAddress("ADMIN_FROM_C.L.E.A.R.{Test}","ankush1504r8@gmail.com");
                    mm.From.Add(from);

                    MailboxAddress to = new MailboxAddress(username, email);
                    mm.To.Add(to);

                    mm.Subject = "OTP";
                    var body = "<div style='background-color: white; display: block; font-family: sans-serif; text-align: center'> " +
                        "<div style='background-color: #000000; width: 80%; color: white; text-align: center; font-size: 1rem; padding: 3rem;'> Your OTP for Resetting Password: {0}</div> " +
                        "</div>";
                    BodyBuilder bodyBuilder = new BodyBuilder();
                    bodyBuilder.HtmlBody = string.Format(body, user.otp);
                    bodyBuilder.TextBody = string.Format(body, user.otp);
                    mm.Body = bodyBuilder.ToMessageBody();
                    

                    
                    using (var client = new SmtpClient())
                    {
                        
                        client.Connect("smtp.gmail.com",465, true);
                        client.Authenticate("ankush1504r8@gmail.com", "ankush@123");
                        client.Send(mm);
                        client.Disconnect(true);
                        client.Dispose();
                        ViewBag.Message = string.Format("success");
                        
                    }
                   
                }
            }
            else
            {
                ViewBag.Message = "fail";
            }

        }
        public string GeneratePassword()
        {
            string PasswordLength = "6";
            string NewPassword = "";

            string allowedChars = "";
            allowedChars = "1,2,3,4,5,6,7,8,9,0";
            //allowedChars += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,";
            //allowedChars += "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,";

            char[] sep = { ',' };
            string[] arr = allowedChars.Split(sep);
            string IDString = "";
            string temp = "";
            Random rand = new Random();
            for (int i = 0; i < Convert.ToInt32(PasswordLength); i++)
            {
                temp = arr[rand.Next(0, arr.Length)];
                IDString += temp;
                NewPassword = IDString;
            }
            return NewPassword;
        }



    }

}