using Microsoft.AspNetCore.Identity;

namespace Model
{
    public class User : IdentityUser
    {
        public Film SavedFilms { get; set; }
    }
}
