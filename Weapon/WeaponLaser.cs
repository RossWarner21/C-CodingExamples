using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astral {
    public class WeaponLaser : Weapon {

        public override void AdjustSize() {
            throw new System.NotImplementedException();
        }

        public override void WeaponHit() {
            weaponBehaviour.WeaponHit(this);
        }

        private void Awake() {
            startColor = GetComponent<SpriteRenderer>().color;
        }

        private void FixedUpdate() {
            weaponBehaviour.WeaponAction(this);
        }
    }
}