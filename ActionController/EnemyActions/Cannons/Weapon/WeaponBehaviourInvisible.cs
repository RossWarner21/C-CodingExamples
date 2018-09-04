using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astral {
    [CreateAssetMenu(menuName = "WeaponBehaviour/Invisible")]
    public class WeaponBehaviourInvisible : WeaponBehaviour {

        public override void WeaponStartAction(Weapon bullet) {
            bullet.Rigidbody.velocity = bullet.transform.up * bullet.Speed;
        }

        public override void WeaponAction(Weapon bullet) {
            bullet.StartCoroutine(ChangeVisibilityState((WeaponInvisible)bullet));
        }

        public override void WeaponHit(Weapon bullet) {
            DamagePlayer(bullet);
            bullet.gameObject.SetActive(false);
        }

        public override void WeaponHit(Weapon bullet, Collider2D playerCollider) {
        }

        [SerializeField]
        float timeInvisible;
        [SerializeField]
        float timeVisible;

        [SerializeField]
        float transitionSpeed;
        
        IEnumerator ChangeVisibilityState(WeaponInvisible bullet) {
            while (bullet.gameObject.activeSelf) {
                yield return new WaitForSecondsRealtime(timeVisible);
                TurnInvisible(bullet);
                yield return new WaitForSecondsRealtime(timeInvisible);
                TurnVisible(bullet);
            }
        }

        void TurnInvisible(WeaponInvisible bullet) {
            bullet.UpdateSpriteRendererAlpha(0);
        }

        void TurnVisible(WeaponInvisible bullet) {
            bullet.UpdateSpriteRendererAlpha(1);
        }

    }
}