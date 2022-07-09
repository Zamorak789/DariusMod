using DariusMod.SkillStates.BaseStates;
using RoR2;
using EntityStates;
using EntityStates.Merc;
using UnityEngine;
using System;
namespace DariusMod.SkillStates
{
    public class CripplingStrike : BaseState
    {
        private OverlapAttack attack;

        public static float baseDuration = 0.8f;

        private float duration;
        public override void OnEnter()
        {
            Transform modelTransform = base.GetModelTransform();
            HitBoxGroup hitBoxGroup = null;

            if (modelTransform)
            {
                hitBoxGroup = Array.Find<HitBoxGroup>(modelTransform.GetComponents<HitBoxGroup>(), (HitBoxGroup element) => element.groupName == "Sword");
            }
            duration = baseDuration / base.attackSpeedStat;


            this.attack = new OverlapAttack();
            attack.attacker = base.gameObject;
            attack.inflictor = base.gameObject;
            attack.damageType = DamageType.Generic;
            attack.procCoefficient = 1f;
            attack.teamIndex = base.GetTeam();
            attack.isCrit = base.RollCrit();
            attack.forceVector = Vector3.zero;
            attack.pushAwayForce = 1f;
            attack.damage = 2.8f * base.damageStat;
            attack.hitBoxGroup = hitBoxGroup;
            //attack.hitEffectPrefab = GroundLight.comboHitEffectPrefab;

            this.attack.Fire();

            //this.swingSoundString = "DariusSwordSwing";
            // this.hitSoundString = "";

            // this.impactSound = Modules.Assets.swordHitSoundEvent.index;
            // base.PlayAnimation("Gesture, Override", "Slash2", "Slash2.playbackRate", 1.0f);

            base.OnEnter();
        }
        public override void FixedUpdate()
        {
            base.FixedUpdate();

            if (base.fixedAge >= this.duration && base.isAuthority)
            {
                base.outer.SetNextStateToMain();
            }
        }
        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.Skill;
        }

        public override void OnExit()
        {
            base.OnExit();
        }
    }
}