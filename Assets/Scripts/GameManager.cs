using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject[] Crowns;
    public Image[] CrownUI;
    public static GameManager instance;

    void Start()
    {
        if (!instance)
            instance = this;
        else
            Destroy(instance);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void CheckCrowns()
    {

    }

}
