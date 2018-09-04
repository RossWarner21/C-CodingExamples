using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astral {
    [CreateAssetMenu(menuName = "WeaponBehaviour/Pulse")]
    public class WeaponBehaviourPulse : WeaponBehaviour {

        public override void WeaponStartAction(Weapon bullet) {
            throw new System.NotImplementedException();
        }

        public override void WeaponAction(Weapon bullet) {
            DetermineCircleSize((WeaponPulse)bullet);
        }

        public override void WeaponHit(Weapon bullet) {
            DamagePlayer(bullet);
        }

        public override void WeaponHit(Weapon bullet, Collider2D playerCollider) {
            if(ThePlayerIsInLineOfSight((WeaponPulse)bullet, playerCollider)) DamagePlayer(bullet);
        }

        [SerializeField]
        float circleRadiusMaximum;

        [SerializeField]
        LayerMask whatToLookFor;
        
        void DetermineCircleSize(WeaponPulse bullet) {
            if(bullet.CircleCollider2D.radius > circleRadiusMaximum) {
                ResetCircleRadius(bullet);
            }
            else {
                IncreaseCircleRadius(bullet);
            }
        }

        void ResetCircleRadius(WeaponPulse bullet) {
            bullet.CircleCollider2D.radius = bullet.BulletSize;
        }
    
        void IncreaseCircleRadius(WeaponPulse bullet) {
            bullet.CircleCollider2D.radius += (Time.fixedDeltaTime * bullet.Speed);
        }               

        bool ThePlayerIsInLineOfSight(WeaponPulse bullet, Collider2D playerCollider) {
            RaycastHit2D whatWasHit = WhatIsInTheDirectionOfThePlayer(bullet, playerCollider);
            if (GameManager.self.search.IsThisThePlayer(whatWasHit.transform.gameObject)) {
                return true;
            }
            return false;
        }

        RaycastHit2D WhatIsInTheDirectionOfThePlayer(WeaponPulse bullet, Collider2D playerCollider) {
            Vector2 direction = playerCollider.transform.position - bullet.transform.position;
            return Physics2D.Raycast(bullet.transform.position, direction, bullet.CircleCollider2D.radius, whatToLookFor);
        }

    }
}