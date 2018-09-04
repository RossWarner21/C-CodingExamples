using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astral {
    [CreateAssetMenu(menuName = "BulletBehaviour/Ball")]
    public class BulletBehaviourBall : WeaponBehaviour {

        public override void WeaponStartAction(Weapon bullet) {
            var rigid = bullet.GetComponent<Rigidbody2D>();
            rigid.velocity = bullet.transform.up * bullet.Speed;
        }

        public override void WeaponAction(Weapon bullet) {
            return;
        }

        public override void WeaponHit(Weapon bullet) {
            DamagePlayer(bullet);
            bullet.gameObject.SetActive(false);
        }

        public override void WeaponHit(Weapon bullet, Collider2D collider2D) {
            DamagePlayer(bullet);
            bullet.gameObject.SetActive(false);
        }
    }
}