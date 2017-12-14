using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthFactorsSurvey.DAL.Entities
{
    public class QuestionCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Question> Questions { get; set; }

        public QuestionCategory()
        {
            Questions = new List<Question>();
        }
    }
}
