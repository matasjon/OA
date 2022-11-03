using System.ComponentModel.DataAnnotations;
using OnAct.Auth.Model;

namespace OnAct.Data.Entities
{
    public class Activity : IUserOwnedResource
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreationTimeUt { get; set; }

        [Required]
        public string UserId { get; set; }

        public OnActUser User { get; set; }

    }
}
