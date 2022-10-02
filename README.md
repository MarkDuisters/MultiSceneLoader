<h1 align="center">MultiSceneLoader</h1>

Simple project that helps in managing scenes existing of multiple scenes.

## Use case

You or your team with members are working on a level. One does level and environment design, the other is doing the programming, etc.
Instead of placing each developer in a prefab within a single scene, you can each assign them a dedicated scene to work on for their part.

The MultiSceneObject will reference those scenes.

Instead of using the scenemanager to load a single scene, you can create a MultiSceneObject in your asset folder and assign each scene file (by string name) that should form a singular scene. Placing the Multiscene manager script in your scene allows you to load this object which will then 
use unity's scenemanager to load each contained scene. You call the load methods through a singleton static instance, but it looks similar to the
scenemanagers "LoadScene" syntax.


Note:

- All the scenes that you want to load do have to be present in your build list.
- The multiscenes that you are using should also be present in the LoadManager's build list.
- Working with this method also prevents/reduces merge conflicts within unity projects as developers are not touching each other's scenes.


## Installation - from scratch

- Clone this repo

## Installation - existing project

- Download the MultiScene_loader folder inside the script folder and import it.
- Create an Empty GameObject and attach the MultiSceneManager to it.

## Usage

- Create a MultiSceneObject by right clicking in your Asset folder.
- Go to ScriptableObjects
- Click on MultiSceneObject.
