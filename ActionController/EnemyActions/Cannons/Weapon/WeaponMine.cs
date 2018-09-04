using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astral {
    public class WeaponMine : Weapon {

        public override void WeaponHit() {
            throw new System.NotImplementedException();
        }

        CircleCollider2D circleCollider2D;
        public CircleCollider2D CircleCollider2D {
            get { return circleCollider2D; }
        }

        private void Awake() {
            circleCollider2D = GetComponent<CircleCollider2D>();
        }

        private void OnEnable() {
            weaponBehaviour.WeaponStartAction(this);
        }

        public override void AdjustSize() {
            throw new System.NotImplementedException();
        }
    }
}