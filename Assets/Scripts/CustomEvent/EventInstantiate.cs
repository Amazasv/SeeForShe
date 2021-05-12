using CustomEvent;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CustomEvent
{
    public class EventInstantiate : MonoBehaviour, ICustomEvent
    {
        [SerializeField]
        private GameObject prefab = null;
        [SerializeField]
        private Transform parent = null;
        [SerializeField]
        private bool onlyone = false;

        private GameObject last = null;
        public void Fire()
        {
            if (onlyone && last) return;
            last = Instantiate(prefab, parent);
        }
    }
}
