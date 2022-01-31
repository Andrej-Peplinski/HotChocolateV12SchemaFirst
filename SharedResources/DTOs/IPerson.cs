namespace SharedResources.DTOs
{
#if ADJUST_DTOS_TO_HC12
    public
#else
    internal
#endif
    interface IPerson
    {
        string FirstName { get; }
        string LastName { get; }
    }
}
