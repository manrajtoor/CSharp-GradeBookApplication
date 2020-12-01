using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class StandardGradeBook : BaseGradeBook
    {
        public StandardGradeBook(string name, bool weight) : base(name, weight)
        {
            Type = Enums.GradeBookType.Standard;
        }
    }
}
