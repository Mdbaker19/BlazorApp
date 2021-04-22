using System;
using System.IO;
using System.Threading.Tasks;
using RestSharp;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.BaseComponenets {
    public class StockComponent : ComponentBase
    {
        public string key = "";
        public async Task<string> SearchedForStocksAsync()
        {
                
            try{
                string filePath = @"keys.txt";
                string[] lines = File.ReadAllLines(filePath);
                key = lines[0];
            } catch(Exception ex){
                System.Console.WriteLine("unable to read key file" + ex);
            }


            try
            {
                var client = new RestClient("https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY_EXTENDED&symbol=TSLA&interval=15min&slice=year1month1&apikey=" + key);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                IRestResponse response = await client.ExecuteAsync(request);
                System.Console.WriteLine(response.Content);
                return response.Content;
            } catch(Exception ex) 
            {
                return "Error fetching Stock Data " + ex;
            }
        }


    }

    
}