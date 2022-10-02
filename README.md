<h1 align="center">MultiSceneLoader</h1>

Simple project that helps in managing scenes existing of multiple scenes.

Usecase:

You or your team with members working on a level. One does level and environment design, the other is doing the programming, etc..
Instead of placing each developer in a prefab within a single scene, you can each assign them a dedicated scene to work on their part.

The MultiSceneObject will reference those scenes.

Instead of using the scenemanager to load a single scene, you can create a MultiSceneObject in your asset folder and assign each scene-file (by string name) 
that should form a singular scene. Placing the Multiscene manager script in your scene allows you to load this object which will then 
use unity's scenemanager to load each contained scene. You call the load methods through a singleton static instance, but it looks similar to the
scenemanagers "LoadScene" syntax.
