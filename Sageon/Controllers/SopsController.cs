﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Sageon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sageon.Controllers
{
    [Route("")]
    public class SopsController : Controller
    {
        public ApplicationDbContext sp = new ApplicationDbContext();


        private ISopRepository repository;
        public SopsController(ISopRepository repo)
        {
            repository = repo;
        }
        //public ViewResult Sop() => View(repository.alerts_Sop);  //bsame my action mtl esm l view by default 
        // public ViewResult List() => View("Sop", repository.alerts_Sop); //esa bade aate l action esm 8eir l view use this one "" l b2alel hol esm l view  




        [HttpPost]
        [Route("Add")]
        public  RedirectToActionResult PostSopRow(Sop _sop)
        {
            sp.alerts_Sop.Add(_sop);
            sp.SaveChangesAsync();
            return  RedirectToAction("SOP","");
        }
        //comment
        [HttpGet("{id}")]
        public List<Sop> GetFiltered(String? _ClientName)
        {
            List<Sop> soplist = new List<Sop>();
            if (_ClientName != null)
                soplist = sp.alerts_Sop.Where(s => s.Client == _ClientName).ToList();
            else
                soplist = sp.alerts_Sop.ToList();
            return soplist;
        }
        [HttpGet("{id}")]
        [Route("api/deleteSop")]
        public ViewResult deleteSop(int rowNumber)
        {
            if (sp.alerts_Sop.Find(rowNumber) != null)
            {
                var delete = sp.alerts_Sop.Where(d => d.id == rowNumber).FirstOrDefault();
                sp.Entry(delete).State = EntityState.Deleted;
                sp.SaveChanges();
                return SopPage();
            }
            return SopPage();
        }
        //public List<Sop> Getelement(string name) 
        //{
        //    List<Sop> emptyList = new List<Sop>();
        //    List<Sop> resList = GetFiltered(name);
        //    if ( resList== null)
        //        return (emptyList);
        //    return resList;

        //}
        [Route("SOP")]
        public ViewResult GetRows(string _name) => View("Sop",GetFiltered(_name));
        private ViewResult SopPage() => View("Sop",repository.alerts_Sop);
        [Route("")]
        public ViewResult SinginPage() => View("Sign_in");
        [Route("Add")]
            public ViewResult AddPage() => View("Add", repository.alerts_Sop);
        // [HttpGet]
        //[Route("Signin")]
        //public ViewResult Login_Check(String _Email, String _Password)
        //{
        //    //User user = new User();
        //    //if (sp.users_User.Find(Email) != null)
        //    //{
        //    //    user = sp.users_User.Where(u => u.Email == Email).FirstOrDefault();
        //    //    if(user.Password==Password)
        //    //    return SopPage();
        //    //}
        //    //return SinginPage();

        //    //V.2
        //    User dbUser=sp.users_User.Where(u => u.Email == _Email).FirstOrDefault();
        //    if (dbUser != null && _Password == dbUser.Password) return SopPage();
        //    return SinginPage(new List<Sop>());
        //}

        //[HttpPost]
        //[Route("api/check")]
        //public ViewResult Check([FromQuery] String _Email, [FromQuery] string _Password )
        //{
        //    ////fullJson= "{\"username\":\"Rodolphe@gmail.com\",\"password\":\"123\"}";
        //    //var obj = JObject.Parse(fullJson);
        //    //var _Email = (string)obj["username"];
        //    //var _Password = (string)obj["password"];
        //    User dbUser = sp.users_User.Where(u => u.Email == _Email).FirstOrDefault();
        //    if (dbUser != null && _Password == dbUser.Password) return SopPage();
        //    return SinginPage();
        //}

        [HttpPost]
        [Route("api/check")]
        [Consumes("application/x-www-form-urlencoded")]
        public ViewResult Check([FromForm] User _user)
        {
            var _Email = _user.Email;
            var _Password = _user.Password;
            User dbUser = sp.users_User.Where(u => u.Email == _Email).FirstOrDefault();
            if (dbUser != null && _Password == dbUser.Password) return SopPage();
            return SinginPage();
        }
    }
}

