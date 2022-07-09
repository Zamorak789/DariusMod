using BepInEx.Configuration;
using DariusMod.Modules.Characters;
using RoR2;
using RoR2.Skills;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace DariusMod.Modules.Survivors
{
    internal class Darius : SurvivorBase
    {
        public override string bodyName => "Darius";

        public const string Darius_PREFIX = DariusPlugin.DEVELOPER_PREFIX + "_Darius_BODY_";
        //used when registering your survivor's language tokens
        public override string survivorTokenPrefix => Darius_PREFIX;

        public override BodyInfo bodyInfo { get; set; } = new BodyInfo
        {
            bodyName = "DariusBody",
            bodyNameToken = DariusPlugin.DEVELOPER_PREFIX + "_Darius_BODY_NAME",
            subtitleNameToken = DariusPlugin.DEVELOPER_PREFIX + "_Darius_BODY_SUBTITLE",

            characterPortrait = Assets.mainAssetBundle.LoadAsset<Texture>("DariusIcon"),
            bodyColor = Color.white,

            crosshair = Modules.Assets.LoadCrosshair("Standard"),
            podPrefab = RoR2.LegacyResourcesAPI.Load<GameObject>("Prefabs/NetworkedObjects/SurvivorPod"),

            maxHealth = 180f,
            healthRegen = 3f,
            armor = 25f,

            jumpCount = 1,
        };

        public override CustomRendererInfo[] customRendererInfos { get; set; } = new CustomRendererInfo[] 
        {
                new CustomRendererInfo
                {
                    childName = "Mesh_0",
                    material = Materials.CreateHopooMaterial("matDarius"),
                },
                new CustomRendererInfo
                {
                    childName = "Weapon",
                }
        };

        public override UnlockableDef characterUnlockableDef => null;

        public override Type characterMainState => typeof(EntityStates.GenericCharacterMain);

        public override ItemDisplaysBase itemDisplays => new DariusItemDisplays();

                                                                          //if you have more than one character, easily create a config to enable/disable them like this
        public override ConfigEntry<bool> characterEnabledConfig => null; //Modules.Config.CharacterEnableConfig(bodyName);

        private static UnlockableDef masterySkinUnlockableDef;

        public override void InitializeCharacter()
        {
            base.InitializeCharacter();
        }

        public override void InitializeUnlockables()
        {
            //uncomment this when you have a mastery skin. when you do, make sure you have an icon too
            //masterySkinUnlockableDef = Modules.Unlockables.AddUnlockable<Modules.Achievements.MasteryAchievement>();
        }

        public override void InitializeHitboxes()
        {
            ChildLocator childLocator = bodyPrefab.GetComponentInChildren<ChildLocator>();
            GameObject model = childLocator.gameObject;

            //example of how to create a hitbox
            Transform hitboxTransform = childLocator.FindChild("SwordHitbox");
            Modules.Prefabs.SetupHitbox(model, hitboxTransform, "Sword");
            Modules.Prefabs.SetupHitbox(model, childLocator.FindChild("SpinHitBox"), "Spin");
        }

        public override void InitializeSkills()
        {
            Modules.Skills.CreateSkillFamilies(bodyPrefab);
            string prefix = DariusPlugin.DEVELOPER_PREFIX;


            #region Primary
            // SkillDef PrimarySkillDef = Modules.Skills.CreateSkillDef(new SkillDefInfo
            // {
            //     skillName = prefix + "_Primary_NAME",
            //   skillNameToken = prefix + "Crippling Strike",
            //    skillDescriptionToken = prefix + "Strike in an area in front of Darius, dealing damage.",
            //    skillIcon = Modules.Assets.mainAssetBundle.LoadAsset<Sprite>("dariusability2"),
            //    activationState = new EntityStates.SerializableEntityStateType(typeof(SkillStates.CripplingStrike)),
            //    activationStateMachineName = "Weapon",
            //    baseMaxStock = 1,
            //    baseRechargeInterval = 0.0f,
            //    beginSkillCooldownOnSkillEnd = false,
            //    canceledFromSprinting = false,
            //    forceSprintDuringState = false,
            //    fullRestockOnAssign = true,
            //    interruptPriority = EntityStates.InterruptPriority.Skill,
            //    resetCooldownTimerOnUse = false,
            //    isCombatSkill = true,
            //    mustKeyPress = false,
            //    cancelSprintingOnActivation = false,
            //    rechargeStock = 1,
            //   requiredStock = 1,
            //   stockToConsume = 1,
            // });
            // Modules.Skills.AddPrimarySkills(bodyPrefab, PrimarySkillDef);

            //Creates a skilldef for a typical primary 
            SkillDef primarySkillDef = Modules.Skills.CreateSkillDef(new SkillDefInfo(prefix + "_HENRY_BODY_PRIMARY_SLASH_NAME",
                                                                                      prefix + "_HENRY_BODY_PRIMARY_SLASH_DESCRIPTION",
                                                                                      Modules.Assets.mainAssetBundle.LoadAsset<Sprite>("dariusability2"),
                                                                                      new EntityStates.SerializableEntityStateType(typeof(SkillStates.CripplingStrike)),
                                                                                      "Weapon",
                                                                                      true));


            Modules.Skills.AddPrimarySkills(bodyPrefab, primarySkillDef);
            #endregion

            #region Secondary
            SkillDef shootSkillDef = Modules.Skills.CreateSkillDef(new SkillDefInfo
            {
                skillName = prefix + "_Darius_BODY_SECONDARY_GUN_NAME",
                skillNameToken = prefix + "_Darius_BODY_SECONDARY_GUN_NAME",
                skillDescriptionToken = prefix + "_Darius_BODY_SECONDARY_GUN_DESCRIPTION",
                skillIcon = Modules.Assets.mainAssetBundle.LoadAsset<Sprite>("dariusability1"),
                activationState = new EntityStates.SerializableEntityStateType(typeof(SkillStates.Decimate)),
                activationStateMachineName = "Slide",
                baseMaxStock = 1,
                baseRechargeInterval = 1f,
                beginSkillCooldownOnSkillEnd = false,
                canceledFromSprinting = false,
                forceSprintDuringState = false,
                fullRestockOnAssign = true,
                interruptPriority = EntityStates.InterruptPriority.Skill,
                resetCooldownTimerOnUse = false,
                isCombatSkill = true,
                mustKeyPress = false,
                cancelSprintingOnActivation = false,
                rechargeStock = 1,
                requiredStock = 1,
                stockToConsume = 1,
                keywordTokens = new string[] { "KEYWORD_AGILE" }
            });

            Modules.Skills.AddSecondarySkills(bodyPrefab, shootSkillDef);

            #endregion

            #region Utility
            SkillDef rollSkillDef = Modules.Skills.CreateSkillDef(new SkillDefInfo
            {
                skillName = prefix + "_Darius_BODY_UTILITY_ROLL_NAME",
                skillNameToken = prefix + "_Darius_BODY_UTILITY_ROLL_NAME",
                skillDescriptionToken = prefix + "_Darius_BODY_UTILITY_ROLL_DESCRIPTION",
                skillIcon = Modules.Assets.mainAssetBundle.LoadAsset<Sprite>("dariusability3"),
                activationState = new EntityStates.SerializableEntityStateType(typeof(SkillStates.Pull)),
                activationStateMachineName = "Body",
                baseMaxStock = 1,
                baseRechargeInterval = 4f,
                beginSkillCooldownOnSkillEnd = false,
                canceledFromSprinting = false,
                forceSprintDuringState = true,
                fullRestockOnAssign = true,
                interruptPriority = EntityStates.InterruptPriority.PrioritySkill,
                resetCooldownTimerOnUse = false,
                isCombatSkill = false,
                mustKeyPress = false,
                cancelSprintingOnActivation = false,
                rechargeStock = 1,
                requiredStock = 1,
                stockToConsume = 1
            });

            Modules.Skills.AddUtilitySkills(bodyPrefab, rollSkillDef);
            #endregion

            #region Special
            SkillDef bombSkillDef = Modules.Skills.CreateSkillDef(new SkillDefInfo
            {
                skillName = prefix + "_Darius_BODY_SPECIAL_BOMB_NAME",
                skillNameToken = prefix + "_Darius_BODY_SPECIAL_BOMB_NAME",
                skillDescriptionToken = prefix + "_Darius_BODY_SPECIAL_BOMB_DESCRIPTION",
                skillIcon = Modules.Assets.mainAssetBundle.LoadAsset<Sprite>("dariusability4"),
                activationState = new EntityStates.SerializableEntityStateType(typeof(SkillStates.NoxianGuillotine)),
                activationStateMachineName = "Slide",
                baseMaxStock = 1,
                baseRechargeInterval = 10f,
                beginSkillCooldownOnSkillEnd = false,
                canceledFromSprinting = false,
                forceSprintDuringState = false,
                fullRestockOnAssign = true,
                interruptPriority = EntityStates.InterruptPriority.Skill,
                resetCooldownTimerOnUse = false,
                isCombatSkill = true,
                mustKeyPress = false,
                cancelSprintingOnActivation = true,
                rechargeStock = 1,
                requiredStock = 1,
                stockToConsume = 1
            });

            Modules.Skills.AddSpecialSkills(bodyPrefab, bombSkillDef);
            #endregion
        }

        public override void InitializeSkins()
        {
            GameObject model = bodyPrefab.GetComponentInChildren<ModelLocator>().modelTransform.gameObject;
            CharacterModel characterModel = model.GetComponent<CharacterModel>();

            ModelSkinController skinController = model.AddComponent<ModelSkinController>();
            ChildLocator childLocator = model.GetComponent<ChildLocator>();

            SkinnedMeshRenderer mainRenderer = characterModel.mainSkinnedMeshRenderer;

            CharacterModel.RendererInfo[] defaultRenderers = characterModel.baseRendererInfos;

            List<SkinDef> skins = new List<SkinDef>();

            #region DefaultSkin
            SkinDef defaultSkin = Modules.Skins.CreateSkinDef(DariusPlugin.DEVELOPER_PREFIX + "_Darius_BODY_DEFAULT_SKIN_NAME",
                Assets.mainAssetBundle.LoadAsset<Sprite>("texMainSkin"),
                defaultRenderers,
                mainRenderer,
                model);

            defaultSkin.meshReplacements = new SkinDef.MeshReplacement[]
            {
                //place your mesh replacements here
                //unnecessary if you don't have multiple skins
                //new SkinDef.MeshReplacement
                //{
                //    mesh = Modules.Assets.mainAssetBundle.LoadAsset<Mesh>("meshDariusSword"),
                //    renderer = defaultRenderers[0].renderer
                //},
                //new SkinDef.MeshReplacement
                //{
                //    mesh = Modules.Assets.mainAssetBundle.LoadAsset<Mesh>("meshDariusGun"),
                //    renderer = defaultRenderers[1].renderer
                //},
                //new SkinDef.MeshReplacement
                //{
                //    mesh = Modules.Assets.mainAssetBundle.LoadAsset<Mesh>("meshDarius"),
                //    renderer = defaultRenderers[2].renderer
                //}
            };

            skins.Add(defaultSkin);
            #endregion

            //uncomment this when you have a mastery skin
            #region MasterySkin
            /*
            Material masteryMat = Modules.Materials.CreateHopooMaterial("matDariusAlt");
            CharacterModel.RendererInfo[] masteryRendererInfos = SkinRendererInfos(defaultRenderers, new Material[]
            {
                masteryMat,
                masteryMat,
                masteryMat,
                masteryMat
            });

            SkinDef masterySkin = Modules.Skins.CreateSkinDef(DariusPlugin.DEVELOPER_PREFIX + "_Darius_BODY_MASTERY_SKIN_NAME",
                Assets.mainAssetBundle.LoadAsset<Sprite>("texMasteryAchievement"),
                masteryRendererInfos,
                mainRenderer,
                model,
                masterySkinUnlockableDef);

            masterySkin.meshReplacements = new SkinDef.MeshReplacement[]
            {
                new SkinDef.MeshReplacement
                {
                    mesh = Modules.Assets.mainAssetBundle.LoadAsset<Mesh>("meshDariusSwordAlt"),
                    renderer = defaultRenderers[0].renderer
                },
                new SkinDef.MeshReplacement
                {
                    mesh = Modules.Assets.mainAssetBundle.LoadAsset<Mesh>("meshDariusAlt"),
                    renderer = defaultRenderers[2].renderer
                }
            };

            skins.Add(masterySkin);
            */
            #endregion

            skinController.skins = skins.ToArray();
        }
    }
}