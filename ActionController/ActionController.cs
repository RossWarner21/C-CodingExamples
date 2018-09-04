using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Astral {
    public class ActionController : MonoBehaviour {
        public bool Active() {
            return GameManager.self.IsTheGameActive();
        }   
    }
}