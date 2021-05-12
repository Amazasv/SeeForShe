using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
namespace CustomEvent
{
    [RequireComponent(typeof(EventBase))]
    public class EventGame : MonoBehaviour, ICustomEvent
    {
        [SerializeField]
        private Transform gameAnchor = null;
        [SerializeField]
        private GameObject gamePrefab = null;
        [SerializeField]
        private Transform caster = null;
        [SerializeField]
        private GameObject DialogPrefab = null;

        [SerializeField]
        private UnityEvent OnVictory = new UnityEvent();

        private GameObject lastGame;
        private GameObject textObject;
        public void Fire()
        {
            textObject = Instantiate(DialogPrefab, caster);
            textObject.GetComponentInChildren<Text>().text = "...";
            if (lastGame == null)
            {
                lastGame = Instantiate(gamePrefab, gameAnchor);
                lastGame.GetComponent<DotsGC>().OnVictory.AddListener(Complete);
            }
        }
        private void Complete()
        {
            Destroy(textObject);
            Destroy(lastGame);
            OnVictory.Invoke();
        }
    }
}

