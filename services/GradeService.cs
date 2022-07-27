using CVs.Model;

namespace CVs.services
{
    public class GradeService
    {
        private IConfiguration _config;

        public GradeService(IConfiguration config)
        {
            _config = config;
        }
        public int CalculateGrade(Programmer programmer, List<string> skills)
        {
            int grade = 0;
            grade += skills.Count * 10;
            if (programmer.Gender == "Female")
            {
                grade += 10;
            }
            else if (programmer.Gender == "Male")
            {
                grade += 5;
            }

            return grade;
        }

        public string GenerateSkills(List<string> skills)
        {
            return string.Join(",", skills);
        }


    }
}
