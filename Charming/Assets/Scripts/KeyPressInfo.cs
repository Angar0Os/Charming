using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyPressInfo : MonoBehaviour
{
    public Text InfoKeyPress;

    public static KeyPressInfo instance;
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    void Update()
    {
        InfoKeyPress.gameObject.SetActive(false);
    }

    public void SeeInfo(string infoPress)
    {
        // display the text 
        InfoKeyPress.gameObject.SetActive(true);
        // write a information in the text
        InfoKeyPress.text = infoPress;
    }
}
