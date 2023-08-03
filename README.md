# 1cgs-Test-Task

Project was created as a test tesk for 1C Game Studios.

![](https://github.com/A1exdV/1cgs-Test-Task/blob/main/Misc/Game-gif.gif)
____________________

Required to implement detection mechanics in Unity (version 2022.3.5):

- Top-down view in 2D;
- Static camera. The game field is defined by a rectangular object;
- There are two objects on the field. Objects move across this field in a randomly chosen direction. After colliding with the field boundaries, the object's direction changes to a new random direction. The direction remains unchanged while moving from one wall to another.
- Each object must have the following settings (to be set in a component attached to the object):
  - Detection radius;
  - Detection sector in degrees - from 0 to 360;
  - Movement speed;
  - Initial color;
  - Color when detected.
    
 - The detection sector is oriented in the direction of movement;
 - While moving across the field, an object should change color when detecting another object. After the detected object moves out of the visibility zone, the detecting object's color should return to the initial color.
 - Collider, Physics, NavMesh components cannot be used.

A plus will be conciseness and the ability to scale the number of objects.
 _____________________

 Character prefab has a [Character Config](https://github.com/A1exdV/1cgs-Test-Task/blob/main/Assets/Scripts/Character/CharacterConfig.cs) on it with object settings.

 <img src="https://github.com/A1exdV/1cgs-Test-Task/blob/main/Misc/Editor%20fiels.png" width="300">

Other objects are considered found even if they appear within the field of view only as a small part.

 You can esely expand number of objects on scene. They are automaticly detected at the start of the game by [CharacterObjectsFinder](https://github.com/A1exdV/1cgs-Test-Task/blob/main/Assets/Scripts/CharacterObjectsFinder.cs).
