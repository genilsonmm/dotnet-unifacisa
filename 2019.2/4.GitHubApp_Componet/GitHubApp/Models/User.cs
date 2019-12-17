using System.ComponentModel.DataAnnotations;

namespace GitHubApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }

        [Display(Name = "Url")]
        public string Html_Url { get; set; }
        [Display(Name = "Avatar")]
        public string Avatar_Url { get; set; }
    }
}
