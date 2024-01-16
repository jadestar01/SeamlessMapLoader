using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapLoader : MonoBehaviour
{
    [SerializeField] private SceneField[] scenesToLoad;
    [SerializeField] private SceneField[] scenesToUnload;

    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    //¾À ·Îµå
    public void SceneLoader()
    {
        for (int i = 0; i < scenesToLoad.Length; i++)
        {
            bool isSceneLoaded = false;
            for (int j = 0; j < SceneManager.sceneCount; j++)
            {
                Scene loadedScene = SceneManager.GetSceneAt(j);
                //Áßº¹°Ë»ç
                if (loadedScene.name == scenesToLoad[i].SceneName)
                {
                    isSceneLoaded = true;
                    break;
                }
            }
            //Áßº¹ÀÌ ¾Æ´Ï¶ó¸é, ¾ÀÀ» µ¡´í´Ù.
            if (!isSceneLoaded)
            {
                SceneManager.LoadSceneAsync(scenesToLoad[i], LoadSceneMode.Additive);
            }
        }    
    }

    //¾À ¾ð·Îµå
    public void SceneUnloader()
    {
        for (int i = 0; i < scenesToUnload.Length; i++)
        {
            for (int j = 0; j < SceneManager.sceneCount; j++)
            {
                Scene loadedScene = SceneManager.GetSceneAt(j);
                if (loadedScene.name == scenesToUnload[i].SceneName)
                {
                    SceneManager.UnloadSceneAsync(scenesToUnload[i]);
                }
            }
        }
    }

    public void Loading()
    {
        SceneLoader();
        SceneUnloader();
    }
}
