using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Button button1;
    public Button button2;
    bool toggler = true;

void OnEnable()
{
    //Register Button Events
    button1.onClick.AddListener(() => buttonCallBack1());
    button2.onClick.AddListener(() => buttonCallBack2());
}

private void buttonCallBack1() { 
    Debug.Log("Button 1 called");
    button2.gameObject.SetActive(toggler);
    if(toggler == true)
    {
        toggler = false;
    }
    else
        toggler = true;
}

private void buttonCallBack2() { 
    Debug.Log("Button 2 called");
    GameManager.gameInst.UpgradeSeats();
}
}
