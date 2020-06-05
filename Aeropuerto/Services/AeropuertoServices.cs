using Aeropuerto.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aeropuerto.Services
{
    public class AeropuertoServices
    {
        public static List<ControlVuelos> GetControlVuelos()
        {
            var client = new RestClient("https://localhost:44325");
            var request = new RestRequest("Vuelos/IndexJson", Method.GET);

            IRestResponse<List<ControlVuelos>> response = client.Execute<List<ControlVuelos>>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Data; // raw content as string
            }
            else
            {
                return null;
            }
        }

    }
}
