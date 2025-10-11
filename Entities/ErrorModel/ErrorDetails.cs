using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Entities.ErrorModel
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }

        // Serialize etmek nedir ? 
        // Datayı platform bağımsız hale getirmektir yani json dosyasına dönüştürmek serialize etmek demektir. jsondan class yapısına
        // dönmesi de deserialize etmek denir.
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
