namespace UberEats.Contracts.Authentication
{
    public record AuthenticationResponse(
        Guid ID,
        string FirstName,
        string LastName,
        string Email,
        string Token
     );
}

