using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sageon.Models
{
    public interface  ISopRepository
    {
        IQueryable<Sop> alerts_Sop { get; }
    }
}
