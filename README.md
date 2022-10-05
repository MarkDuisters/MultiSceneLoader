<h1 align="center">MultiSceneLoader</h1>

Simple project that helps in managing scenes existing of multiple scenes.

## Use case

You or your team are working on a level consisting of multiple scene files. One does level and environment design, the other is doing the programming, etc.
Instead of placing each developer in a prefab within a single scene, you can each assign them a dedicated scene to work on for their part.

The MultiSceneObject will reference those scenes.
![MultiScenefile](img/MultiScenefile.PNG)

Instead of using the scenemanager to load a single scene, you can create a MultiSceneObject in your asset folder and assign each scene file (by string name) that should form a singular scene.
You can then use MultiSceneManager as you would use unity's scenemanager to load each scene. You call the load methods similar to the scenemanager's "LoadScene" syntax. Instead you use MultiSceneManager.LoadMultiScene/(Async).
Adding to that. You can use either the MultiScene buildt list or use a direct MulstiScene reference to load all your scenes.
![multisceneobject](img/multisceneobject.PNG)
![LoadingSyntax](ader/img/LoadingSyntax.PNG)

Note:

- All the scenes that you want to load, do have to be present in your build list.
- The multiscenes that you are using should also be present in the LoadManager's build list.


- Working with this method also prevents/reduces merge conflicts within unity projects as developers are not touching each other's scenes.


## Installation - from scratch

- Clone this repo

## Installation - existing project

- Download the MultiScene_loader folder inside the script folder and import it.

## Usage

- Create a MultiSceneObject by right clicking in your Asset folder.
- Go to MultiSceneManager.
- Click on MultiScene.
![createmultisceneobject](img/createmultisceneobject.gif)

-Add the MultiSceneBuildList script to an empty GameObject (This object will get the DoNotDestroy flag).
![mutliscenebuildlist](img/mutliscenebuildlist.PNG)
- Create a script similar to the normal scenemanager's method that loads the MultiScene file (see syntax above).

