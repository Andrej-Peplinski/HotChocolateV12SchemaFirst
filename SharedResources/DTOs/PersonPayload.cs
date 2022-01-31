using System;
using System.Collections.Generic;
using System.Text;

namespace SharedResources.DTOs
{
    internal sealed record PersonPayload(IEnumerable<IPerson> EncounteredPersons);
}
