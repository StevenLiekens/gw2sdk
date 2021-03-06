﻿using JetBrains.Annotations;
using GW2SDK.Json;

namespace GW2SDK.Accounts.Banks
{
    [PublicAPI]
    public interface IBankReader : IJsonReader<Bank>
    {
    }
}
