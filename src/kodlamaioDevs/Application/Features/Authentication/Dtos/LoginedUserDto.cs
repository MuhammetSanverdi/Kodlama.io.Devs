namespace Application.Features.Authentication.Dtos
{
    public class LoginedUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccessToken { get; set; }
    }
}
