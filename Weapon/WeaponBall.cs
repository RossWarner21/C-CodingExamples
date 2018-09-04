using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astral {
    public class WeaponBall : Weapon {

        public override void AdjustSize() {
            transform.localScale = new Vector3(bulletSizeAndDamage, bulletSizeAndDamage, bulletSizeAndDamage);
        }

        public override void WeaponHit() {
            weaponBehaviour.WeaponHit(this);
        }

        private void OnEnable() {
            weaponBehaviour.WeaponStartAction(this);
        }

        
    }
}