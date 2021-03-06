﻿using JetBrains.Annotations;

namespace GW2SDK.Skills
{
    [PublicAPI]
    public sealed record EliteSkill : Skill
    {
        public int? Specialization { get; init; }

        public int? ToolbeltSkill { get; init; }

        public Attunement? Attunement { get; init; }

        public int? Cost { get; init; }

        public int[]? BundleSkills { get; init; }

        public int[]? TransformSkills { get; init; }

        public SkillReference[]? Subskills { get; init; }
    }
}