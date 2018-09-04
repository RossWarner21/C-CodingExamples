using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astral {
    public class WeaponInvisible : Weapon {

        public override void WeaponHit() {
            throw new System.NotImplementedException();
        }

        SpriteRenderer spriteRenderer;
        public SpriteRenderer SpriteRenderer {
            get { return spriteRenderer; }
        }
        public void UpdateSpriteRendererAlpha(float newAlphaValue) {
            var newColor = SpriteRenderer.color;
            newColor.a = newAlphaValue;
            SpriteRenderer.color = newColor;
        }

        private void Awake() {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnEnable() {
            weaponBehaviour.WeaponStartAction(this);
            weaponBehaviour.WeaponAction(this);
        }

        public override void AdjustSize() {
            throw new System.NotImplementedException();
        }
    }
}