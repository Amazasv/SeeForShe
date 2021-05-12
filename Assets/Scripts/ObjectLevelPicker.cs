using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ObjectLevelPicker : MonoBehaviour
{
    [SerializeField]
    private Button c1 = null;
    [SerializeField]
    private Button c2 = null;
    [SerializeField]
    private Button c3 = null;
    [SerializeField]
    private Button c5 = null;

    private void Awake()
    {
        c1.onClick.AddListener(delegate { SaveSystem.LoadData("pass_c1"); });
        c2.onClick.AddListener(delegate { SaveSystem.LoadData("pass_c2"); });
        c3.onClick.AddListener(delegate { SaveSystem.LoadData("pass_c3"); });
        c5.onClick.AddListener(delegate { SaveSystem.LoadData("pass_c5"); });
    }


    private void OnEnable()
    {
        c1.interactable = SaveSystem.IsDataExist("pass_c1");
        c2.interactable = SaveSystem.IsDataExist("pass_c2");
        c3.interactable = SaveSystem.IsDataExist("pass_c3");
        c5.interactable = SaveSystem.IsDataExist("pass_c5");
    }

}
