using System;
using System.Collections.Generic;
using System.Text;

namespace SharedResources.DTOs
{
#if ADJUST_DTOS_TO_HC12
    public sealed record PersonPayload(IEnumerable<IPerson> EncounteredPersons);
#else
    internal sealed record PersonPayload(IEnumerable<IPerson> EncounteredPersons);
#endif
}
