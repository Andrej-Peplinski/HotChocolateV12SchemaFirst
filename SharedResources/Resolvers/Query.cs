using HotChocolate;
using SharedResources.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedResources.Resolvers
{
#if ADJUST_DTOS_TO_HC12
    public
#else
    internal
#endif
    sealed class Query
    {
        public Task<PersonPayload> GetPeopleAsync(
            PersonInput? input,
            [Service] PersonRepository repository)
        {
            IEnumerable<IPerson> matchingPersons;

            if (input?.OnlyIncludeFirstNames is string[] firstNameFilter)//If specified by the graphql input only return people with the specified first name
            {
                matchingPersons = repository.GetPersons(p =>
                    firstNameFilter.Any(filter =>
                        filter.Equals(p.FirstName, StringComparison.OrdinalIgnoreCase)));
            }
            else
            {
                matchingPersons = repository.GetPersons();
            }

            return Task.FromResult(new PersonPayload(matchingPersons));
        }
    }
}
