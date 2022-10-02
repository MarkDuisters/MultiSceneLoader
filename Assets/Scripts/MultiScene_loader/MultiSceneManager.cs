using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MultiSceneManager : MonoBehaviour
{

  [HideInInspector]  public bool isDone = true;
    public static MultiSceneManager instance;
    public MultiSceneObject[] multiScenesInBuild;


    void Awake()
    {
        //Maak een singleton, als er al eentje aanwezig is pleeg meteen zelfmoord.
        if (instance != null)
        {
            DestroyImmediate(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }


    public void LoadMultiScene(MultiSceneObject sceneObject)
    {

        isDone = false;
        Debug.Log("Finished:"+isDone);
        for (int i = 0; i < sceneObject.sceneNames.Length; i++)
        {
            //Als we de eerste index hebben [0] laden we de scene normaal, de opvolgende indexes laden additief.
            if (i == 0)
            {
                SceneManager.LoadScene(sceneObject.sceneNames[i], LoadSceneMode.Single);
            }
            else
            {
                SceneManager.LoadScene(sceneObject.sceneNames[i], LoadSceneMode.Additive);

            }
        }
        isDone = true;
        Debug.Log("Finished:"+isDone);
    }

    public void LoadMultiSceneAsync(MultiSceneObject sceneObject)
    {

        isDone = false;
        Debug.Log("Finished:"+isDone);
        StartCoroutine(LoadOperation(sceneObject));
        isDone = true;
        Debug.Log("Finished:"+isDone);

    }


    IEnumerator LoadOperation(MultiSceneObject sceneObject)
    {
        float progress = 0f;

        for (int i = 0; i < sceneObject.sceneNames.Length; i++)
        {
            //Als we de eerste index hebben [0] laden we de scene normaal, de opvolgende indexes laden additief.
            if (i == 0)
            {
                AsyncOperation op = SceneManager.LoadSceneAsync(sceneObject.sceneNames[i], LoadSceneMode.Single);
                while (!op.isDone)
                {
                    progress = Mathf.Clamp01(op.progress / .9f);
                    Debug.Log(op.progress);

                    yield return null;
                }
            }
            else
            {
                AsyncOperation op = SceneManager.LoadSceneAsync(sceneObject.sceneNames[i], LoadSceneMode.Additive);
                while (!op.isDone)
                {
                    progress = Mathf.Clamp01(op.progress / .9f);
                    Debug.Log(op.progress);

                    yield return null;
                }

            }


        }

    }


}
