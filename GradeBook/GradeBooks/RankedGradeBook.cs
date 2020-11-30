using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }
    
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Need at least 5 students");
            }

            // Organize student grades
            List<double> grades = new List<double>();

            foreach (var student in Students)
            {
                grades.Add(student.AverageGrade);
            }
            grades.Sort();
            // Find which percentile score is in
            List<char> grade = new List<char>() { 'A', 'B', 'C', 'D' };
            double percentile = .8 * Students.Count;
            double unitDrop = .2 * Students.Count;
            int numDrops = 0;
            while(true)
            {
                if (percentile <= 0)
                {
                    return 'F';
                }
                // Check initial index
                if (averageGrade >= grades[(int)percentile])
                {
                    // If grade is within range, assign grade and break
                    return grade[numDrops];
                }
                // Update index and 
                numDrops += 1;
                percentile = percentile - unitDrop;
            }
                    
        }
    }
}
