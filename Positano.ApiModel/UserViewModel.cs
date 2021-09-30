
using Newtonsoft.Json;
using Positano.Domain.Entities;

namespace Positano.ApiModel
{
    public class UserViewModel
    {
        [JsonProperty("id")]
        public int UserId { get; set; }
        [JsonProperty("nombre")]
        public string LastName { get; set; }

        [JsonProperty("telefono")]
        public int Phone { get; set; }
        [JsonProperty("direccion")]
        public string Direction { get; set; }
     
      
        public UserViewModel(User user)
        {
            UserId = user.UserId;
            LastName = user.LastName;
            Phone = user.Phone;
            Direction = user.Direction;
         
        }

        public UserViewModel() { }

        public static UserViewModel Complete(User user)
        {
            return new UserViewModel()
            {
                UserId = user.UserId,
                LastName = user.LastName,
                Phone = user.Phone,
                Direction = user.Direction,
        };
        }
    }
}
