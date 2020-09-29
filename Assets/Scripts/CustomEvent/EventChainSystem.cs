using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CustomEvent
{
    public class EventChainSystem : MonoBehaviour
    {
        [SerializeField]
        private float defaultGap = 2.0f;
        [SerializeField]
        private EventBase StartEvent = null;
        [SerializeField]
        private bool PlayOnAwake = true;

        private void OnEnable()
        {
            if (PlayOnAwake) Play();
        }

        public void Play()
        {
            StartCoroutine(CreateDialog(StartEvent, defaultGap));
        }

        public void FireEvent(EventBase target, float delay)
        {
            if (target)
            {
                StartCoroutine(CreateDialog(target, delay));
            }
            else
            {
                Debug.Log("null event");
            }
        }


        IEnumerator CreateDialog(EventBase dialog, float t)
        {
            yield return new WaitForSeconds(t);
            dialog.InvokeEvent();
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }
    }
}
