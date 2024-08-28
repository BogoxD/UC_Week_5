using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> Crowns;
    public List<Image> CrownUI;
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
        for(int i = 0; i < Crowns.Count; i++)
        {
            if(!Crowns[i].activeSelf)
            {
                Crowns.RemoveAt(i);
                CrownUI[i].gameObject.SetActive(true);
            }   
        }
        if(Crowns.Count <= 0)
        {
            Debug.Log("You Won!!!");
        }
    }

}
