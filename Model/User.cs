using Microsoft.AspNetCore.Identity;

namespace Model
{
    public class User : IdentityUser
    {
        public List<Film> SavedFilms { get; set; } = new List<Film>();
    }
}
