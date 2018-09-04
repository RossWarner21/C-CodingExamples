using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astral {
    [CreateAssetMenu(menuName = "BulletBehaviour/Mine")]
    public class BulletBehaviourMine : WeaponBehaviour {

        public override void WeaponStartAction(Weapon bullet) {
            var rigid = bullet.GetComponent<Rigidbody2D>();
            rigid.velocity = bullet.transform.up * bullet.Speed;
        }

        public override void WeaponAction(Weapon bullet) {
            throw new System.NotImplementedException();
        }

        public override void WeaponHit(Weapon bullet) {
            throw new System.NotImplementedException();
        }

        public override void WeaponHit(Weapon bullet, Collider2D collider2D) {
            Explode(bullet);
            DamagePlayer(bullet);
        }

        void Explode(Weapon bullet) {
            bullet.gameObject.SetActive(false);
        }

        
        
    }
}