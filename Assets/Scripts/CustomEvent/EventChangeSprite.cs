using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace CustomEvent
{
    [RequireComponent(typeof(EventBase))]
    public class EventChangeSprite : MonoBehaviour, ICustomEvent
    {
        [SerializeField]
        private Image target = null;
        [SerializeField]
        private Sprite sprite = null;
        public void Fire()
        {
            target.sprite = sprite;
        }
    }
}
