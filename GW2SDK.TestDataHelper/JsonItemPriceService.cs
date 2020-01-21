﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GW2SDK.Commerce.Prices.Impl;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GW2SDK.TestDataHelper
{
    public class JsonItemPriceService
    {
        private readonly HttpClient _http;

        public JsonItemPriceService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<string>> GetAllJsonItemPrices(bool indented)
        {
            var ids = await GetItemPriceIds();
            var list = new List<string>(ids.Count);
            var tasks = ids.Buffer(200).Select(subset => GetJsonItemPricesById(subset.ToList(), indented));
            foreach (var result in await Task.WhenAll(tasks))
            {
                list.AddRange(result);
            }

            return list;
        }

        private async Task<List<int>> GetItemPriceIds()
        {
            using (var request = new GetItemPricesIndexRequest())
            using (var response = await _http.SendAsync(request))
            {
                var json = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<List<int>>(json);
            }
        }

        private async Task<List<string>> GetJsonItemPricesById(IReadOnlyList<int> itemIds, bool indented)
        {
            using (var request = new GetItemPricesByIdsRequest.Builder(itemIds).GetRequest())
            using (var response = await _http.SendAsync(request))
            using (var responseReader = new StreamReader(await response.Content.ReadAsStreamAsync()))
            using (var jsonReader = new JsonTextReader(responseReader))
            {
                response.EnsureSuccessStatusCode();

                // API returns a JSON array but we want a List of JSON objects instead
                var array = await JToken.ReadFromAsync(jsonReader);
                return array.Children<JObject>().Select(item => item.ToString(indented ? Formatting.Indented : Formatting.None)).ToList();
            }
        }
    }
}