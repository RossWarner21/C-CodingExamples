using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astral {
    [CreateAssetMenu(menuName = "WeaponBehaviour/Homing")]
    public class WeaponBehaviourHoming : WeaponBehaviour {

        public override void WeaponStartAction(Weapon bullet) {
            bullet.StartCoroutine(AutomaticallyExplodeAfterXSeconds(bullet));
        }

        public override void WeaponAction(Weapon bullet) {
            LaunchHomingMissile(bullet);
        }

        public override void WeaponHit(Weapon bullet) {
            DamagePlayer(bullet);
            ExplodeSelf(bullet);
        }

        public override void WeaponHit(Weapon bullet, Collider2D collider2D) {
            DamagePlayer(bullet);
            ExplodeSelf(bullet);
        }

        [SerializeField]
        private float autoDestructionTime;

        private GameObject target;

        [SerializeField]
        private float homingSensitivity;

        IEnumerator AutomaticallyExplodeAfterXSeconds(Weapon bullet) {
            yield return new WaitForSecondsRealtime(autoDestructionTime);
            ExplodeSelf(bullet);
        }

        void ExplodeSelf(Weapon bullet) {
            bullet.gameObject.SetActive(false);
        }

        void LaunchHomingMissile(Weapon bullet) {
            AssignTarget();
            if(target != null) {
                TrackTarget((WeaponHoming)bullet);
            }
        }

        void AssignTarget() {
            target = GameManager.self.search.PlayerGameObject;
        }
        
        void TrackTarget(WeaponHoming bullet) {
            Vector2 direction = (Vector2)target.transform.position - (Vector2)bullet.transform.position;
            direction.Normalize();
            float rotateAmount = Vector3.Cross(direction, bullet.transform.up).z;
            bullet.GetRigidbody2D.angularVelocity = -homingSensitivity * rotateAmount;
            bullet.GetRigidbody2D.velocity = bullet.transform.up * bullet.Speed;
        }
    }
}