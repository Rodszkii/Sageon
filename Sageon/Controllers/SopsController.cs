using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public ApplicationDbContext sp=new ApplicationDbContext();

        private ISopRepository repository;
        public SopsController(ISopRepository repo)
        {
            repository = repo;
        }
        public ViewResult Sop() => View(repository.alerts_Sop);  //bsame my action mtl esm l view by default 
                                                                 // public ViewResult List() => View("Sop", repository.alerts_Sop); //esa bade aate l action esm 8eir l view use this one "" l b2alel hol esm l view  




        [HttpPost]
        public async Task<ActionResult> PostSopRow(Sop _sop)
        {
            sp.alerts_Sop.Add(_sop);
            sp.SaveChangesAsync();
            return Ok(_sop);
        }
        //comment
        [HttpGet("{id}")]
        public async Task<ActionResult> GetFiltered(String? _ClientName)
        {
            List<Sop> soplist=new List<Sop>();
            if (_ClientName != null)
                soplist = sp.alerts_Sop.Where(s => s.Client == _ClientName).ToList();
            else
                soplist = sp.alerts_Sop.ToList();
            if (soplist == null)
                return NotFound();
            return Ok(soplist);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sop>> deleteSop(int? _rowNumber)
        {
            if (sp.alerts_Sop.Find(_rowNumber) != null)
            {
                var delete = sp.alerts_Sop.Where(d => d.id == _rowNumber).FirstOrDefault();
                sp.Entry(delete).State = EntityState.Deleted;
                sp.SaveChanges();
                return Ok();
            }
            return NotFound();
        }
       
    }
}

