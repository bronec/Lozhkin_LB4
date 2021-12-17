using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Lozhkin_LB4.Models
{
    public class UserModel
    {
        [DisplayName("Идентификатор")]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [DisplayName("Имя")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [DisplayName("Доступ")]
        [JsonPropertyName("access")]
        public string Access { get; set; }
    }
}
