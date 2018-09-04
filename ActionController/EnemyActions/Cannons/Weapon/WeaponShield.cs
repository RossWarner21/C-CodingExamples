using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astral {
    public class WeaponShield : Weapon {

        public override void WeaponHit() {
            weaponBehaviour.WeaponHit(this);
        }

        public override void AdjustSize() {
            throw new System.NotImplementedException();
        }

        CircleCollider2D circleCollider2D;
        public CircleCollider2D CircleCollider2D {
            get { return circleCollider2D; }
        }

        public GameObject enemyToProtect;
        public GameObject EnemyToProtect {
            get { return enemyToProtect; }
            set { enemyToProtect = value; }
        }

        SpriteRenderer spriteRenderer;
        public SpriteRenderer SpriteRenderer {
            get { return spriteRenderer; }
        }

        private float totalHealth = 10;
        public float TotalHealth {
            set { totalHealth = value; }
        }

        private void Awake() {
            circleCollider2D = GetComponent<CircleCollider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnEnable() {
            if(enemyToProtect == null) {
                gameObject.SetActive(false);
            }
            else {
                weaponBehaviour.WeaponStartAction(this);
                UpdateHealth();
                UpdateShieldTouchEvent();
            }
        }

        void UpdateShieldTouchEvent() {
            ActionEvent damageEvent = GetComponent<ActionEvent>();
            WeaponBehaviourShield shieldBehaviour = (WeaponBehaviourShield)weaponBehaviour;
            damageEvent.touchEvent.RemoveAllListeners();
            damageEvent.touchEvent.AddListener((shieldBehaviour.CurrentDamageAction.Act));
        }

        private void Update() {
            UpdatePositionToEnemyBeingProtected();
        }

        public void UpdatePositionToEnemyBeingProtected() {
            Vector2 tempPosition = enemyToProtect.transform.position;
            transform.position = new Vector3(tempPosition.x, tempPosition.y, transform.position.z);
        }

        public void UpdateHealth() {
            GetComponent<HealthShield>().HealthShieldSetUp(totalHealth, this);
        }

        public void ShieldHasBeenDestroyed() {
            gameObject.SetActive(false);
        }

        
    }
}