using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MultiSceneManagement;


public class MultiSceneBuildList : MonoBehaviour
{


    [SerializeField] MultiSceneObject[] multiScenesInBuild;

    void Awake()
    {
        MultiSceneManager.multiScenesInBuild = multiScenesInBuild;
        DontDestroyOnLoad(gameObject);

    }

}
