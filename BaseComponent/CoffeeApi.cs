using System;
using System.IO;
using System.Threading.Tasks;
using RestSharp;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.BaseComponenets {
    public class CoffeeComponent : ComponentBase
    {
        public async Task<string> SearchedForCoffeeAsync()
        {
            try
            {
                var client = new RestClient("https://coffee-project-api.herokuapp.com/coffees");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                IRestResponse response = await client.ExecuteAsync(request);
                System.Console.WriteLine(response.Content);
                return response.Content;
            } catch(Exception ex) 
            {
                return "Error fetching Coffee Data " + ex;
            }
        }
    }
}