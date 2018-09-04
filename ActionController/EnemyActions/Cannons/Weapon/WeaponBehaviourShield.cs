using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astral {
    [CreateAssetMenu(menuName = "WeaponBehaviour/Shield")]
    public class WeaponBehaviourShield : WeaponBehaviour {

        public override void WeaponStartAction(Weapon weapon) {
            InitiateShield((WeaponShield)weapon);
        }

        public override void WeaponAction(Weapon weapon) {
            throw new System.NotImplementedException();
        }

        public override void WeaponHit(Weapon weapon) {
            throw new System.NotImplementedException();
        }

        public override void WeaponHit(Weapon weapon, Collider2D collider2D) {
            throw new System.NotImplementedException();
        }

        [SerializeField]
        EnemyDamageTouchAction[] damageActions;

        EnemyDamageTouchAction currentDamageAction;
        public EnemyDamageTouchAction CurrentDamageAction {
            get { return currentDamageAction; }
        }

        void InitiateShield(WeaponShield weapon) {
            AssignCurrentDamageAction();
            UpdateShieldColour(weapon);
            MatchSizeToEnemy(weapon);
        }

        void AssignCurrentDamageAction() {
            int i = Random.Range(0, damageActions.Length);
            currentDamageAction = damageActions[i];
        }

        void UpdateShieldColour(WeaponShield weapon) {
            Color newColor = currentDamageAction.EnemyColor;
            newColor.a = 0.5f;
            weapon.SpriteRenderer.color = newColor;
        }

        void MatchSizeToEnemy(WeaponShield weapon) {
            var enemyScale = weapon.enemyToProtect.transform.localScale;
            weapon.gameObject.transform.localScale = (enemyScale * 1.2f) ;
        }

    }
}