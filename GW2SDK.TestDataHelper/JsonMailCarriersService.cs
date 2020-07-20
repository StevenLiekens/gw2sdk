﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GW2SDK.MailCarriers.Impl;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GW2SDK.TestDataHelper
{
    public class JsonMailCarriersService
    {
        private readonly HttpClient _http;

        public JsonMailCarriersService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<string>> GetAllJsonMailCarriers(bool indented)
        {
            var request = new MailCarriersRequest();
            using var response = await _http.SendAsync(request);
            using var responseReader = new StreamReader(await response.Content.ReadAsStreamAsync());
            using var jsonReader = new JsonTextReader(responseReader);
            response.EnsureSuccessStatusCode();

            // API returns a JSON array but we want a List of JSON objects instead
            var array = await JToken.ReadFromAsync(jsonReader);
            return array.Children<JObject>().Select(obj => obj.ToString(indented ? Formatting.Indented : Formatting.None)).ToList();
        }
    }
}