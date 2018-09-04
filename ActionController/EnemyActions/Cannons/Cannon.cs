using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astral {
    public abstract class Cannon : ScriptableObject {

        public abstract void Shoot(CannonObject controller);

        [SerializeField]
        protected WeaponTypes weaponToBeFired;

        [SerializeField]
        protected CannonTypes cannonType;        

        [SerializeField]
        protected CannonAttributes shotAttributes;

        protected CannonObject cannonObject;

        //[SerializeField]
        //protected int totalShotsFiredSoFar;

        [SerializeField]
        protected Sprite cannonImage;

        public CannonAttributes GetShot() {
            return shotAttributes;
        }

        public void SetShot(CannonAttributes newShot) {
            shotAttributes = newShot;
        }

        //public void IncrementShotFiredCounter() {
        //    totalShotsFiredSoFar++;
        //}

        //public void ResetShotsFired() {
        //    totalShotsFiredSoFar = 0;
        //}

        public Sprite Image() {
            return cannonImage;
        }

        protected void FireBullet() {
            GameObject bulletGO = BulletPool.bulletPool.BulletTypeSearch(weaponToBeFired);
            SetUpBulletAttributes(ref bulletGO);
            bulletGO.SetActive(true);
        }

        protected void SetUpBulletAttributes(ref GameObject bulletGO) {
            Weapon weapon = bulletGO.GetComponent<Weapon>();
            weapon.UpdateStatsBulk(shotAttributes, cannonObject.transform);
        }
    }
}