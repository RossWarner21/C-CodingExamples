using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astral {
    //[CreateAssetMenu(menuName = "BulletBehaviour/Ball")]
    public abstract class WeaponBehaviour : ScriptableObject {

        public abstract void WeaponStartAction(Weapon weapon);
        public abstract void WeaponAction(Weapon weapon);
        public abstract void WeaponHit(Weapon weapon);
        public abstract void WeaponHit(Weapon weapon, Collider2D collider2D);

        protected void DamagePlayer(Weapon weapon) {
            HealthPlayer.self.InflictDamage(weapon.BulletDamage);
        }

    }
}