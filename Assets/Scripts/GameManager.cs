using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> Crowns;
    public List<Image> CrownsUI;
    public static GameManager instance;

    private int uiIndex;
    private int sceneIndex = 0;
    void Start()
    {
        if (instance)
            Destroy(gameObject);
        else
            instance = this;

        DontDestroyOnLoad(instance);


        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
    private void OnLevelWasLoaded(int level)
    {
        uiIndex = 0;
        FindAllCrowns();
        FindAllUICrowns();
    }
    public void CheckCrowns()
    {
        for (int i = 0; i < Crowns.Count; i++)
        {
            if (!Crowns[i].activeSelf)
            {
                Crowns.RemoveAt(i);
                CrownsUI[uiIndex].gameObject.SetActive(true);
                uiIndex++;
            }
        }
        if (Crowns.Count <= 0)
        {
            Debug.Log("You Won!!!");

            sceneIndex++;
            SceneManager.LoadScene(sceneIndex);
        }
    }
    public void FindAllCrowns()
    {
        List<GoldCup> temp = FindObjectsOfType<GoldCup>().ToList();
        for (int i = 0; i < temp.Count; i++)
        {
            Crowns.Add(temp[i].gameObject);
        }
    }
    public void FindAllUICrowns()
    {
        CrownsUI.Clear();

        List<GameObject> temp = GameObject.FindGameObjectsWithTag("CrownUI").ToList();
        for (int i = 0; i < temp.Count; i++)
        {
            CrownsUI.Add(temp[i].GetComponent<Image>());

            //set objects inactive
            CrownsUI[i].gameObject.SetActive(false);
        }
    }

}
