﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using GW2SDK.Infrastructure;

namespace GW2SDK.Features.Accounts.Infrastructure
{
    public sealed class JsonAccountsService : IJsonAccountsService
    {
        private readonly HttpClient _http;

        public JsonAccountsService([NotNull] HttpClient http)
        {
            _http = http ?? throw new ArgumentNullException(nameof(http));
        }

        public async Task<string> GetAccount() => await _http.GetStringAsync("/v2/account");
    }
}