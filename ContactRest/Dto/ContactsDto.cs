using System.Collections.Generic;
using Newtonsoft.Json;

namespace ContactRest.Dto
{
    public class ContactsDto
    {
        [JsonProperty(PropertyName = "contacts")]
        public IList<ContactDto> Contacts { get; set; }
    }
}