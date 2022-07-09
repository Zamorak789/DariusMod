using R2API;
using System;

namespace DariusMod.Modules
{
    internal static class Tokens
    {
        internal static void AddTokens()
        {
            #region Darius
            string prefix = DariusPlugin.DEVELOPER_PREFIX + "_Darius_BODY_";

            string desc = "Darius is a Noxian warrior who uses brute force and intimidation to kill those in his path.<color=#CCD3E0>" + Environment.NewLine + Environment.NewLine;
            desc = desc + "< ! > Sword is a good all-rounder while Boxing Gloves are better for laying a beatdown on more powerful foes." + Environment.NewLine + Environment.NewLine;
            desc = desc + "< ! > Pistol is a powerful anti air, with its low cooldown and high damage." + Environment.NewLine + Environment.NewLine;
            desc = desc + "< ! > Roll has a lingering armor buff that helps to use it aggressively." + Environment.NewLine + Environment.NewLine;
            desc = desc + "< ! > Bomb can be used to wipe crowds with ease." + Environment.NewLine + Environment.NewLine;

            string outro = "..and so he left, in pursuit of power.";
            string outroFailure = "..and so he vanished, unable to satiate his bloodlust.";

            LanguageAPI.Add(prefix + "NAME", "Darius");
            LanguageAPI.Add(prefix + "DESCRIPTION", desc);
            LanguageAPI.Add(prefix + "SUBTITLE", "The Chosen One");
            LanguageAPI.Add(prefix + "LORE", "sample lore");
            LanguageAPI.Add(prefix + "OUTRO_FLAVOR", outro);
            LanguageAPI.Add(prefix + "OUTRO_FAILURE", outroFailure);

            #region Skins
            LanguageAPI.Add(prefix + "DEFAULT_SKIN_NAME", "Default");
            LanguageAPI.Add(prefix + "MASTERY_SKIN_NAME", "Godking");
            #endregion

            #region Passive
            LanguageAPI.Add(prefix + "PASSIVE_NAME", "Hemorrhage");
            LanguageAPI.Add(prefix + "PASSIVE_DESCRIPTION", "Darius's attacks create stacks of hemorrhage, up to 5 total. At 5 stacks he gains a boost to damage.");
            #endregion

            #region Primary
            LanguageAPI.Add(prefix + "PRIMARY_AXE_NAME", "Crippling Strike");
            LanguageAPI.Add(prefix + "PRIMARY_AXE_DESCRIPTION", Helpers.agilePrefix + $"Swing forward for <style=cIsDamage>{100f * StaticValues.swordDamageCoefficient}% damage</style>.");
            #endregion

            #region Secondary
            LanguageAPI.Add(prefix + "SECONDARY_SPIN_NAME", "Decimate");
            LanguageAPI.Add(prefix + "SECONDARY_SPIN_DESCRIPTION", Helpers.agilePrefix + $"Fire a handgun for <style=cIsDamage>{100f * StaticValues.gunDamageCoefficient}% damage</style>.");
            #endregion

            #region Utility
            LanguageAPI.Add(prefix + "UTILITY_PULL_NAME", "Apprehend");
            LanguageAPI.Add(prefix + "UTILITY_PULL_DESCRIPTION", "Roll a short distance, gaining <style=cIsUtility>300 armor</style>. <style=cIsUtility>You cannot be hit during the roll.</style>");
            #endregion

            #region Special
            LanguageAPI.Add(prefix + "SPECIAL_DUNK_NAME", "Noxian Guillotine");
            LanguageAPI.Add(prefix + "SPECIAL_DUNK_DESCRIPTION", $"Throw a bomb for <style=cIsDamage>{100f * StaticValues.bombDamageCoefficient}% damage</style>.");
            #endregion

            #region Achievements
            LanguageAPI.Add(prefix + "MASTERYUNLOCKABLE_ACHIEVEMENT_NAME", "Darius: Mastery");
            LanguageAPI.Add(prefix + "MASTERYUNLOCKABLE_ACHIEVEMENT_DESC", "As Darius, beat the game or obliterate on Monsoon.");
            LanguageAPI.Add(prefix + "MASTERYUNLOCKABLE_UNLOCKABLE_NAME", "Darius: Mastery");
            #endregion
            #endregion
        }
    }
}