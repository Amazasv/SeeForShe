using CustomEvent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CustomEvent
{
    [RequireComponent(typeof(EventBase))]
    public class EventInstantiate : MonoBehaviour, ICustomEvent
    {
        [SerializeField]
        private GameObject prefab = null;
        [SerializeField]
        private Transform parent = null;
        public void Fire()
        {
            Instantiate(prefab, parent);
        }
    }
}
