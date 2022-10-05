using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MultiSceneManagement;

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
            MultiSceneManager.LoadMultiSceneAsync(MultiSceneManager.multiScenesInBuild[0]);
        else

            MultiSceneManager.LoadMultiScene(MultiSceneManager.multiScenesInBuild[0]);

    }


}
