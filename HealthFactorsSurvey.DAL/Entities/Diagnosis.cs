using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthFactorsSurvey.DAL.Entities
{
    public class Diagnosis
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

        public int QuestionSetId { get; set; }
        public QuestionSet QuestionSet { get; set; }
    }
}
