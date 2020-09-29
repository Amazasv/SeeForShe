using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace CustomEvent
{
    public class EventBase : MonoBehaviour
    {
        public UnityEvent OnInvoke;
        private void Awake()
        {
            ICustomEvent[] addons = GetComponents<ICustomEvent>();
            foreach (ICustomEvent i in addons) OnInvoke.AddListener(i.Fire);
        }
        public void InvokeEvent()
        {
            OnInvoke.Invoke();
        }
    }
}