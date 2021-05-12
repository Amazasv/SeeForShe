using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace CustomEvent
{
    [RequireComponent(typeof(EventBase))]
    public class EventDialog : MonoBehaviour, ICustomEvent
    {
        [SerializeField]
        private Talking talking = null;
        [SerializeField]
        private bool dontDestroy = false;
        [SerializeField]
        private string content = "";
        [SerializeField]
        private float existTime = 2.0f;
        public void Fire()
        {
            talking.Speak(content);
            if (!dontDestroy) talking.ClearAll(existTime);
        }
    }
}
