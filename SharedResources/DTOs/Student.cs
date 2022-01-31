using System;
using System.Collections.Generic;
using System.Text;

namespace SharedResources.DTOs
{
    internal sealed class Student : IPerson
    {
        public Student(string firstName, string lastName, int grade)
            => (this.FirstName, this.LastName, this.Grade) = (firstName, lastName, grade);
        public string FirstName { get; internal set; }

        public string LastName { get; internal set; }

        public int Grade { get; internal set; }
    }
}
