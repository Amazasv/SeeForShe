using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CustomEvent
{
    [RequireComponent(typeof(EventBase))]

    public class EventSetFlag : MonoBehaviour, ICustomEvent
    {
        [SerializeField]
        private string m_FlagName = "";
        public void Fire()
        {
            GameManager.Instance.globalFlags[m_FlagName] = true;
        }
    }
}
