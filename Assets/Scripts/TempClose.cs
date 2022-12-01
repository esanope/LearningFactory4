using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempClose : MonoBehaviour
{

    public GameObject loginUI;

    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void CloseScreen()
    {
        loginUI.SetActive(false);
    }
}
