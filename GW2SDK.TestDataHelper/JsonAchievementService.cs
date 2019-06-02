﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using GW2SDK.Infrastructure.Achievements;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GW2SDK.TestDataHelper
{
    public class JsonAchievementService
    {
        private readonly HttpClient _http;

        public JsonAchievementService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<string>> GetAllJsonAchievements(bool indented)
        {
            var ids = await GetAchievementIds();
            var list = new List<string>(ids.Count);
            foreach (var subset in ids.Buffer(200))
            {
                var achievements = await GetJsonAchievementsByIds(subset.ToList(), indented);
                foreach (var achievement in achievements)
                {
                    list.Add(achievement);
                }
            }

            return list;
        }

        private async Task<List<int>> GetAchievementIds()
        {
            using (var request = new GetAchievementIdsRequest())
            using (var response = await _http.SendAsync(request))
            {
                var json = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<List<int>>(json);
            }
        }

        private async Task<List<string>> GetJsonAchievementsByIds(IReadOnlyList<int> achievementIds, bool indented)
        {
            using (var request = new GetAchievementsByIdsRequest.Builder(achievementIds).GetRequest())
            using (var response = await _http.SendAsync(request))
            using (var responseReader = new StreamReader(await response.Content.ReadAsStreamAsync()))
            using (var jsonReader = new JsonTextReader(responseReader))
            {
                response.EnsureSuccessStatusCode();

                // API returns a JSON array but we want a List of JSON objects instead
                var array = await JToken.ReadFromAsync(jsonReader);
                return array.Children<JObject>().Select(achievement => achievement.ToString(indented ? Formatting.Indented : Formatting.None)).ToList();
            }
        }
    }
}