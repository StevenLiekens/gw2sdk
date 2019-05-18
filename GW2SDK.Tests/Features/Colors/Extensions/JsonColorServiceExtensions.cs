﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GW2SDK.Features.Colors.Infrastructure;
using Newtonsoft.Json.Linq;

namespace GW2SDK.Tests.Features.Colors.Extensions
{
    public static class JsonColorServiceExtensions
    {
        public static async Task<ISet<string>> GetAllColorCategories(this JsonColorService service)
        {
            var json = await service.GetAllColors();
            var root = JToken.Parse(json);
            var query = from value in root.SelectTokens("$[*].categories[*]", true).Cast<JValue>()
                orderby value.Value
                select (string) value.Value;

            return new HashSet<string>(query);
        }
    }
}