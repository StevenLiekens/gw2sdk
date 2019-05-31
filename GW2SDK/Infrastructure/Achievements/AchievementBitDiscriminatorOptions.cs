﻿using System;
using System.Collections.Generic;
using GW2SDK.Features.Achievements;

namespace GW2SDK.Infrastructure.Achievements
{
    public sealed class AchievementBitDiscriminatorOptions : DiscriminatorOptions
    {
        public override Type BaseType => typeof(AchievementBit);

        public override string DiscriminatorFieldName => "type";

        public override bool SerializeDiscriminator => false;

        public override IEnumerable<(string TypeName, Type Type)> GetDiscriminatedTypes()
        {
            yield return ("Text", typeof(AchievementTextBit));
            yield return ("Minipet", typeof(AchievementMinipetBit));
            yield return ("Item", typeof(AchievementItemBit));
            yield return ("Skin", typeof(AchievementSkinBit));
        }

        public override object Create(Type objectType)
        {
            if (objectType == typeof(AchievementTextBit))
            {
                return new AchievementTextBit();
            }

            if (objectType == typeof(AchievementMinipetBit))
            {
                return new AchievementMinipetBit();
            }


            if (objectType == typeof(AchievementItemBit))
            {
                return new AchievementItemBit();
            }

            if (objectType == typeof(AchievementSkinBit))
            {
                return new AchievementSkinBit();
            }

            return new AchievementBit();
        }
    }
}