using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CustomEvent
{
    public class EventDestroy : MonoBehaviour, ICustomEvent
    {
        [SerializeField]
        private GameObject target = null;
        public void Fire()
        {
            Destroy(target);
        }
    }
}