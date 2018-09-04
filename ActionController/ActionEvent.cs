using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Astral {
    [System.Serializable]
    public class ActionControllerEvent : UnityEvent<ActionController> {
    }

    [System.Serializable]
    public class TouchEvent : UnityEvent<ActionController, Touch> {
    }

    public class ActionEvent : MonoBehaviour {
        public TouchEvent touchEvent;
        public ActionControllerEvent actionEvent;
    }
}