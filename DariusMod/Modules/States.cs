using DariusMod.SkillStates;
using DariusMod.SkillStates.BaseStates;
using System.Collections.Generic;
using System;

namespace DariusMod.Modules
{
    public static class States
    {
        internal static void RegisterStates()
        {
            Modules.Content.AddEntityState(typeof(BaseMeleeAttack));
            Modules.Content.AddEntityState(typeof(CripplingStrike));

            Modules.Content.AddEntityState(typeof(Decimate));

            Modules.Content.AddEntityState(typeof(Pull));

            Modules.Content.AddEntityState(typeof(NoxianGuillotine));
        }
    }
}