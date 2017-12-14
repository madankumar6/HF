using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthFactorsSurvey.DAL.Entities
{
    public class QuestionSet
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public ICollection<Diagnosis> DiagnosisList { get; set; }

        public QuestionSet()
        {
            DiagnosisList = new List<Diagnosis>();
        }
    }
}
