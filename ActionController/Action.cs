using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astral {
    public abstract class Action : ScriptableObject {
        public abstract void Act(ActionController controller);
        public abstract void Act(ActionController controller, Touch touch);      
    }

    public abstract class ShotAction : Action {
        [SerializeField]
        protected ShootingStyles shotStyle;
        [SerializeField]
        protected Sprite baseImage;

        public Sprite Image() {
            return baseImage;
        }
    }

    public abstract class MovementAction : Action {
        [SerializeField]
        protected Sprite shapeImage;

        public Sprite Image() {
            return shapeImage;
        }
    }

    public abstract class EnemyDamageTouchAction : Action {
        public sealed override void Act(ActionController controller) {
            return;
        }

        [SerializeField]
        protected float damageDoneByPlayer;

        [SerializeField]
        protected Color enemyColor;

        public Color EnemyColor {
            get { return enemyColor; }
        }

    }

}