using Microsoft.AspNetCore.Identity;

public class SampleAppUser : IdentityUser
{
    public string FullName { get; set; }
}