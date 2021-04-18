using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CW_Backend.POCOs
{
    [Alias("Users")]
    public class UserPOCO
    {
        [AutoIncrement] public long UserId { get; set; }
        [Required] public string Login { get; set; }
        [Required] public string Email { get; set; }
        [Required, StringLength(64)] public string PasswordSha256 { get; set; }
    }
}
