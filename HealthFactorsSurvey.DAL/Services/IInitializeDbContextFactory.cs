using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthFactorsSurvey.DAL.Services
{
    public interface IInitializeDbContextFactory
    {
        string Database { get; set; }
        string ConnectionString { get; set; }
    }
}
