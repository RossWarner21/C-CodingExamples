using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astral {
    [CreateAssetMenu(menuName = "Cannons/Ball/BurstShot")]
    public class CannonBallBurstShot : CannonBall {

        public override void Shoot(CannonObject tmpController) {
            if (!ThereAreShotsAvailable(tmpController))
                return;
            else {
                cannonObject = tmpController;
                ShotBehaviorStartToFinish();
            }
        }

        public bool ThereAreShotsAvailable(CannonObject tmpController) {
            if (tmpController.totalShotsCanBeFired == -1)
                return true;

            return tmpController.GetShotsFiredSoFar() < tmpController.totalShotsCanBeFired;
        }

        void ShotBehaviorStartToFinish() {
            cannonObject.StartCoroutine(ShootBulletsSpacedApart());
            cannonObject.IncrementShotFiredCounter();            
        }

        IEnumerator ShootBulletsSpacedApart() {
            var i = 0;
            while (i < shotAttributes.ShotsPerVolley()) {
                FireBullet();
                i++;
                yield return new WaitForSecondsRealtime(shotAttributes.GapBetweenShotsInVolley());
            }
        }
    }
}