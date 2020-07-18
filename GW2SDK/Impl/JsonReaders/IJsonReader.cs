﻿using System.Text.Json;

namespace GW2SDK.Impl.JsonReaders
{
    public interface IJsonReader<out T>
    {
        T Read(in string json) => Read(JsonDocument.Parse(json));

        T Read(in JsonDocument json) => Read(json.RootElement);

        T Read(in JsonElement json);

        bool CanRead(in JsonElement json);
    }
}
