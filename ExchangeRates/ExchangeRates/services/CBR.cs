using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ExchangeRates.Interfaces;
using ExchangeRates.Models;

namespace ExchangeRates.services
{
    public class CBR:ICBR
    {
        

        public async Task<List<Valute>> GetCourse(DateTime date)
        {
            var client = new HttpClient();
  
            var uri = new Uri("http://www.cbr.ru/scripts/XML_daily.asp");
            using  (var stream = await client.GetStreamAsync(uri))
            {
                var serializer = new XmlSerializer(typeof(ValCurs));
                var vc = (ValCurs)serializer.Deserialize(stream);
           
                return vc.Valutes;
              
            }

        }
       
    }
}