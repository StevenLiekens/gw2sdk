﻿namespace GW2SDK.Features.Items
{
    public enum ItemFlag
    {
        // Skip index 0 so that Enum.IsDefined returns false for default(ItemFlag)
        AccountBindOnUse = 1,

        AccountBound,

        Attuned,

        BulkConsume,

        DeleteWarning,

        HideSuffix,

        Infused,

        MonsterOnly,

        NoMysticForge,

        NoSalvage,

        NoSell,

        NoUnderwater,

        NotUpgradeable,

        SoulBindOnUse,

        SoulbindOnAcquire,

        Tonic,

        Unique
    }
}