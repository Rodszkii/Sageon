using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sageon.Models
{
    public class FakeRepo : ISopRepository
    {
        public IQueryable<Sop> alerts_Sop => new List<Sop>
        {
            new Sop { Client="AUB",Title="Bruteforce",Artifact="account is rodolphe xyz ",Occurance=5,IOC="What to do ",SIEM="AV",Comment="check source",Reviewed_By="tier2",Added_By="rodolphe",Procedure="Finnetune"},
            new Sop{ Client="Alfa",Title="Bruteforce",Artifact="account is rodolphe xyz ",Occurance=5,IOC="What to do ",SIEM="AV",Comment="check source",Reviewed_By="tier2",Added_By="rodolphe",Procedure="Finnetune"}
        }.AsQueryable<Sop>();
    }
}
