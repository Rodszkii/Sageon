using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sageon.Models
{
    public class EFSopRepository : ISopRepository
    {
        private ApplicationDbContext context;
        public EFSopRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Sop> alerts_Sop => context.alerts_Sop;
    }
}
