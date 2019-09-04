﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GW2SDK.Continents.Impl;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GW2SDK.TestDataHelper
{
    public class JsonContinentService
    {
        private readonly HttpClient _http;

        public JsonContinentService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<string>> GetAllJsonContinents(bool indented)
        {
            using (var request = new GetContinentsRequest())
            using (var response = await _http.SendAsync(request))
            using (var responseReader = new StreamReader(await response.Content.ReadAsStreamAsync()))
            using (var jsonReader = new JsonTextReader(responseReader))
            {
                response.EnsureSuccessStatusCode();

                // API returns a JSON array but we want a List of JSON objects instead
                var array = await JToken.ReadFromAsync(jsonReader);
                return array.Children<JObject>().Select(obj => obj.ToString(indented ? Formatting.Indented : Formatting.None)).ToList();
            }
        }
    }
}