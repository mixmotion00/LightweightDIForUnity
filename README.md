# Getting Started

Simply adding "MainLoader" script on any GameObject in scene then hit Play.

You may edit MainLoader.cs to expand the logic and support more classess.

## Prefab Instancer Support

To load more prefab, just add game object in MM00 > Manager > Prefab > Resources > PrefabLib.

And from any script use line
<pre> Transform yourPrefab = _managerPrefab.Instantiate<Transform>("KeyPathHere"); </pre>
