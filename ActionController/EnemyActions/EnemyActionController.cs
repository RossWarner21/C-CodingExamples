using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astral {

    //Enemy Action Controller plays the action set in the inspector for shootAction. 

    public class EnemyActionController : ActionController {
        
        //public ShotAction shootAction;
        public List<CannonObject> cannons;

        //public float timeBetweenVolleys;
        //public float durationOfShot;

        //[Header("-1 for unlimited shots")]
        //public int totalShotsCanBeFired;

        //[SerializeField]
        //private int totalShotsFiredSoFar;

        //public int GetShotsFiredSoFar() {
        //    return totalShotsFiredSoFar;
        //}

        //public void IncrementShotFiredCounter() {
        //    totalShotsFiredSoFar++;
        //}

        //public void ResetShotsFired() {
        //    totalShotsFiredSoFar = 0;
        //}

        //private float timeElapsed;

        private PlayerCollisionThreats playerCollisionThreat = PlayerCollisionThreats.enemy;

        private void OnDisable() {
        }

        private void OnEnable() {
            //ResetShotsFired();
            StartAction();
        }
        
        public void StartAction() {
            //shootAction.Act(this);
            foreach(CannonObject cannonObject in cannons) {
                cannonObject.StartShooting();
            }
        }

        //public bool CheckIfCountDownElapsed(float duration) {
        //    timeElapsed += Time.deltaTime;
        //    if (timeElapsed >= duration) {
        //        timeElapsed = 0;
        //        return true;
        //    }
        //    else {
        //        return false;
        //    }
        //}

        //public void UpdateConfiguration(EnemyConfiguration enemyConfig) {
        //    NewAction(enemyConfig.howTheEnemyShoots);
        //    NewCannons(enemyConfig.cannons);
        //}

        //public void NewAction(ShotAction action) {
        //    shootAction = action;
        //}

        //public void NewCannons(List<Cannon> tempCannons) {
        //    cannons = tempCannons;
        //}

        public void NewCannons(List<Cannon> tempCannons) {
            for (var i = 0; i < tempCannons.Count;i++) {
                cannons[i].Cannon = tempCannons[i];
            }
        }

        public void UpdateConfiguration(EnemyConfiguration enemyConfig) {
            NewCannons(enemyConfig.cannons);            
        }
    }
}