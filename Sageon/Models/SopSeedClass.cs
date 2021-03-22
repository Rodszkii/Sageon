using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sageon.Models
{
    public class SopSeedClass
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
            .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.alerts_Sop.Any())
            {
                context.alerts_Sop.AddRange(
                    new Sop { Client = "AUB", Title = "Bruteforce", Artifact = "account is rodolphe xyz ", Occurance = 5, IOC = "What to do ", SIEM = "AV", Comment = "check source", Reviewed_By = "tier2", Added_By = "rodolphe", Procedure = "Finnetune" },
                    new Sop { Client = "Alfa", Title = "Bruteforce", Artifact = "account is rodolphe xyz ", Occurance = 5, IOC = "What to do ", SIEM = "AV", Comment = "check source", Reviewed_By = "tier2", Added_By = "rodolphe", Procedure = "Finnetune" },
                    new Sop { Client = "Touch", Title = "Bruteforce", Artifact = "account is rodolphe xyz ", Occurance = 5, IOC = "What to do ", SIEM = "AV", Comment = "check source", Reviewed_By = "tier2", Added_By = "rodolphe", Procedure = "Finnetune" },
                    new Sop { Client = "Aoun", Title = "Bruteforce", Artifact = "account is rodolphe xyz ", Occurance = 5, IOC = "What to do ", SIEM = "AV", Comment = "check source", Reviewed_By = "tier2", Added_By = "rodolphe", Procedure = "Finnetune" },
                    new Sop { Client = "Moulin", Title = "Bruteforce", Artifact = "account is rodolphe xyz ", Occurance = 32, IOC = "What to do ", SIEM = "hive", Comment = "check source", Reviewed_By = "tier2", Added_By = "rodolphe", Procedure = "Finnetune" },
                    new Sop { Client = "oliver", Title = "Bruteforce", Artifact = "account is rodolphe xyz ", Occurance = 12, IOC = "What to do ", SIEM = "AV", Comment = "check source", Reviewed_By = "tier2", Added_By = "rodolphe", Procedure = "Finnetune" },
                    new Sop { Client = "All", Title = "Bruteforce", Artifact = "account is rodolphe xyz ", Occurance = 42, IOC = "What to do ", SIEM = "AV", Comment = "check source", Reviewed_By = "tier2", Added_By = "rodolphe", Procedure = "Finnetune" },
                    new Sop { Client = "forn", Title = "argq", Artifact = "account is rodolphe xyz ", Occurance = 32, IOC = "What to do ", SIEM = "hive", Comment = "check source", Reviewed_By = "tier2", Added_By = "rodolphe", Procedure = "Finnetune" },
                    new Sop { Client = "forn", Title = "argq", Artifact = "account is rodolphe xyz ", Occurance = 32, IOC = "What to do ", SIEM = "hive", Comment = "check source", Reviewed_By = "tier2", Added_By = "rodolphe", Procedure = "Finnetune" }

                    );
                context.SaveChanges();
            }
        }
    }
}
