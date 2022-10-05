using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "MultiScene", menuName = "MultiSceneManager/MultiSceneObject", order = 1)]
public class MultiSceneObject : ScriptableObject
{
 public string[] sceneNames;

}
