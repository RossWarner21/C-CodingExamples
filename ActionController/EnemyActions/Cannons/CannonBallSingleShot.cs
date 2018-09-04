using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astral {
    [CreateAssetMenu(menuName = "Cannons/Ball/SingleShot")]
    public class CannonBallSingleShot : CannonBall {

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
            FireBullet();
            cannonObject.IncrementShotFiredCounter();            
        }     
    }
}