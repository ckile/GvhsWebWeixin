using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Gvhs.Web.DataContracts
{
    public class User : IEntity
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string UserCode { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}
