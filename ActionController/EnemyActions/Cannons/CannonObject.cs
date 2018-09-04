using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astral {
    public class CannonObject : MonoBehaviour {

        [SerializeField]
        Cannon cannon;
        public Cannon Cannon {
            set { cannon = value; }
        }

        public bool active = true;

        public float timeBetweenVolleys;
        public float durationOfShot;

        [Header("-1 for unlimited shots")]
        public int totalShotsCanBeFired;

        [SerializeField]
        private int totalShotsFiredSoFar;

        public int GetShotsFiredSoFar() {
            return totalShotsFiredSoFar;
        }
        public void IncrementShotFiredCounter() {
            totalShotsFiredSoFar++;
        }
        public void ResetShotsFired() {
            totalShotsFiredSoFar = 0;
        }
        private float timeElapsed;

        private void OnEnable() {
            ResetShotsFired();
        }

        public void StartShooting() {
            StartCoroutine(ShootingEveryTimeBetweenShots());
        }

        IEnumerator ShootingEveryTimeBetweenShots() {
            while (active) {
                yield return new WaitForSecondsRealtime(timeBetweenVolleys);
                FireCannon();
            }
        }

        void FireCannon() {
            cannon.Shoot(this);     
        }

        public bool CheckIfCountDownElapsed(float duration) {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= duration) {
                timeElapsed = 0;
                return true;
            }
            else {
                return false;
            }
        }
    }
}