﻿using System;
using System.Collections.Generic;
using GW2SDK.Features.Achievements;

namespace GW2SDK.Infrastructure.Achievements
{
    public sealed class AchievementRewardDiscriminatorOptions : DiscriminatorOptions
    {
        public override Type BaseType => typeof(AchievementReward);

        public override string DiscriminatorFieldName => "type";
        
        public override bool SerializeDiscriminator => false;
        
        public override IEnumerable<(string TypeName, Type Type)> GetDiscriminatedTypes()
        {
            yield return ("Title", typeof(TitleReward));
            yield return ("Mastery", typeof(MasteryReward));
            yield return ("Item", typeof(ItemReward));
            yield return ("Coins", typeof(CoinsReward));
        }

        public override object Create(Type objectType)
        {
            if (objectType == typeof(TitleReward))
            {
                return new TitleReward();
            }

            if (objectType == typeof(MasteryReward))
            {
                return new MasteryReward();
            }

            if (objectType == typeof(ItemReward))
            {
                return new ItemReward();
            }

            if (objectType == typeof(CoinsReward))
            {
                return new CoinsReward();
            }

            return new AchievementReward();
        }
    }
}