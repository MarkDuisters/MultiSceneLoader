using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    [SerializeField] bool loadAsync = false;

    // Start is called before the first frame update
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



   public void LoadTest()
    {
        //Simple load test of the system.
        if (loadAsync)
            MultiSceneManager.instance.LoadMultiSceneAsync(MultiSceneManager.instance.multiScenesInBuild[0]);
        else
        {
            MultiSceneManager.instance.LoadMultiScene(MultiSceneManager.instance.multiScenesInBuild[0]);
        }
    }


}
