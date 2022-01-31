using System.Collections.Generic;

namespace SharedResources.DTOs
{
    internal sealed class Teacher : IPerson
    {
        public Teacher(string firstName, string lastName, IEnumerable<string> subjects)
            => (this.FirstName, this.LastName, this.Subjects) = (firstName, lastName, subjects);
        public string FirstName { get; internal set; }

        public string LastName { get; internal set; }

        public IEnumerable<string> Subjects { get; internal set; }
    }
}
