using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astral {
    public class WeaponHoming : Weapon {

        public override void WeaponHit() {
            weaponBehaviour.WeaponHit(this);
        }

        Rigidbody2D rigidBody;
        public Rigidbody2D GetRigidbody2D {
            get { return rigidBody; }
        }

        private void Awake() { 
            rigidBody = GetComponent<Rigidbody2D>();
        }

        private void OnEnable() {
            weaponBehaviour.WeaponStartAction(this);
        }

        private void FixedUpdate() {
            weaponBehaviour.WeaponAction(this);
            //transform.Translate(Speed * Time.deltaTime, Speed * Time.deltaTime, 0, Space.Self);
            
        }

        public override void AdjustSize() {
            throw new System.NotImplementedException();
        }
    }
}