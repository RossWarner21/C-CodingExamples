using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astral {
    [CreateAssetMenu(menuName = "BulletBehaviour/Laser")]
    public class BulletBehaviourLaser : WeaponBehaviour {

        [Header("Negative number from total opacity")]
        [SerializeField]
        private float laserOpacityMinimum;

        public override void WeaponStartAction(Weapon bullet) {
            throw new System.NotImplementedException();
        }

        public override void WeaponAction(Weapon bullet) {
            ChangeLaserSize(bullet);
            ChangeLaserOpacity(bullet);
        }

        public override void WeaponHit(Weapon bullet) {
            DamagePlayer(bullet);
        }

        public override void WeaponHit(Weapon bullet, Collider2D collider2D) {
            DamagePlayer(bullet);
        }

        void ChangeLaserSize(Weapon bullet) {
            float scaleX = Random.Range(bullet.BulletSize * 0.8f, bullet.BulletSize * 1.2f);
            bullet.transform.localScale = new Vector3(scaleX, bullet.transform.localScale.y);            
        }

        void ChangeLaserOpacity(Weapon bullet) {
            float lightOpacity = Random.Range(laserOpacityMinimum, 0f);
            Color newColor = Color.cyan;
            newColor.a = bullet.StartColor.a + lightOpacity;
            bullet.GetComponent<SpriteRenderer>().color = newColor;
        }
    }
}