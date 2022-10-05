using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
namespace MultiSceneManagement
{
    public class MultiSceneManager
    {
        public static bool isDone = true;
        public static float progress = 0f;
        public static MultiSceneObject[] multiScenesInBuild;
        public class StaticCoroutineContainer : MonoBehaviour { void Awake() { DontDestroyOnLoad(gameObject); } }
        private static StaticCoroutineContainer staticCoroutine;

        //The same functionality as Unity's SceneManager.LoadScene();
        public static void LoadMultiScene(MultiSceneObject sceneObject)
        {
            isDone = false;
            progress = 0f;
            Debug.Log(isDone);
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
            Debug.Log(isDone);
        }
        //The same functionality as Unity's SceneManager.LoadSceneAsync();
        public static void LoadMultiSceneAsync(MultiSceneObject sceneObject)
        {
            InitStaticCoroutineContainer();
            staticCoroutine.StartCoroutine(LoadOperation(sceneObject));
        }
        //We need to create a placeholder container that derives from monobehavior so we can use Coroutines in this static class.
        private static void InitStaticCoroutineContainer()
        {
            //If the instance not exit the first time we call the static class
            if (staticCoroutine == null)
            {
                // GameObject gameObject = GameObject.FindObjectOfType<GameManager>().gameObject;
                GameObject gameObject = new GameObject("LoadContainer");
                //Add this script to the object and instantly reference it in our staticCoroutine.
                staticCoroutine = gameObject.AddComponent<StaticCoroutineContainer>();
                Debug.Log(gameObject.name);
                Debug.Log(gameObject.scene.name);
            }
        }
        public static IEnumerator LoadOperation(MultiSceneObject sceneObject)
        {
            isDone = false;
            Debug.Log(isDone);
            progress = 0f;
            Debug.Log($"sceneNames length:{sceneObject.sceneNames.Length}");
            for (int i = 0; i < sceneObject.sceneNames.Length; i++)
            {
                //Als we de eerste index hebben [0] laden we de scene normaal, de opvolgende indexes laden additief.
                if (i == 0)
                {
                    Debug.Log("Loading scene:" + i);
                    AsyncOperation op = SceneManager.LoadSceneAsync(sceneObject.sceneNames[i], LoadSceneMode.Single);
                    while (!op.isDone)
                    {
                        progress = Mathf.Clamp01(op.progress / .9f);
                        Debug.Log(op.progress);
                        yield return null;
                    }
                    Debug.Log("Loading scene:" + i + " DONE");
                }
                else
                {
                    Debug.Log("Loading scene:" + i);
                    AsyncOperation op = SceneManager.LoadSceneAsync(sceneObject.sceneNames[i], LoadSceneMode.Additive);
                    while (!op.isDone)
                    {
                        progress = Mathf.Clamp01(op.progress / .9f);
                        Debug.Log(op.progress);
                        yield return null;
                    }
                    Debug.Log("Loading scene:" + i + " DONE");
                }
                isDone = true;
                Debug.Log(isDone);
            }
        }
    }
}