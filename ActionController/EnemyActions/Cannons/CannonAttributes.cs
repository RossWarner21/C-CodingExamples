using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astral {
    [CreateAssetMenu(menuName = "CannonAttributes")]
    public class CannonAttributes : ScriptableObject{
                
        [SerializeField]
        private int shotsPerVolley;
        [SerializeField]
        private float gapBetweenShotsInVolley;
        [SerializeField]
        private float directionOfShot;
        [SerializeField]
        private float bulletSpeed;
        [SerializeField]
        private float bulletSizeAndDamage;

        private Vector3 currentPosition;
        public Vector3 CurrentPosition {
            get { return currentPosition; }
        }

        private Vector3 currentRotation;
        public Vector3 CurrentRotation {
            get { return currentRotation; }
        }

        public int ShotsPerVolley() {
            return shotsPerVolley;
        }

        public float GapBetweenShotsInVolley() {
            return gapBetweenShotsInVolley;
        }

        public float BulletSizeAndDamage() {
            return bulletSizeAndDamage;
        }

        public float BulletSpeed() {
            return bulletSpeed;
        }       
    }
}