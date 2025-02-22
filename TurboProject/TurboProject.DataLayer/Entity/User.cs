using Microsoft.AspNetCore.Identity;

namespace TurboProject.DataLayer.Entity
{
    public class User : IdentityUser<string>
    {
        public string Surname { get; set; }
        public DateTime CreatedDate { get; set; }
        public ICollection<Favorite>? Favorites { get; set; }
    }
}
