using System;
using System.Collections.Generic;
using System.Linq;

namespace SharedResources.DTOs
{
#if ADJUST_DTOS_TO_HC12
    public
#else
    internal
#endif
    class PersonRepository
    {
        private static readonly List<IPerson> _people = new() { 
            new Student("Max", "Trasto", 10),
            new Student("Moritz", "Bicho", 11),
            new Teacher("Herr", "Lämpel", new[] { "Language", "Math", "Social"}),
        };

        public IEnumerable<IPerson> GetPersons() => _people;
        public IEnumerable<IPerson> GetPersons(Func<IPerson, bool> predicate) => _people.Where(predicate);
    }
}
