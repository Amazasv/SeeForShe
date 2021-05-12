using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomEvent
{
    [RequireComponent(typeof(EventBase))]
    public class EventAutoFire : MonoBehaviour, ICustomEvent
    {
        [SerializeField]
        private EventBase next = null;
        [SerializeField]
        private float delay = 2.0f;
        [SerializeField]
        private bool isEnter = false;

        private void Start()
        {
            if (isEnter) Fire();
        }
        public void Fire()
        {
            StartCoroutine(InvokeNext());
        }

        private IEnumerator InvokeNext()
        {
            yield return new WaitForSeconds(delay);
            next.InvokeEvent();
        }
    }
}
