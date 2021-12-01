using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Lozhkin_LB4.Models
{
    public class UsersModel
    {
        [DisplayName("Идентификатор")]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [DisplayName("Название")]
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [DisplayName("Доступ")]
        [JsonPropertyName("accsess")]
        public string Price { get; set; }
    }
}
