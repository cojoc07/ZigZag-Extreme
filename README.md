# ZigZag Extreme - Unity game designed for Android devices, also compatible with other platforms, such as the PC.
> The application was created using the Unity Engine. 
> The scripts used for the game logic are written in C# using Visual Studio.

<img src="https://i.imgur.com/maSO7Xa.png">

![](header.png)

## Summary

The game is a clone of the popular Zigzag game but with an extreme difficulty setting. It uses an isometric perspective and the goal is to stay alive for as long as possible by running along the edge of walls, avoiding obstacles and collecting diamonds along the way.
The difficulty increases with the distance travelled by using a MonoBehaviour.InvokeRepeating which calls a function that increases speed every few seconds.

## How it works

The falling blocks are generated procedurally at the start of a game. The blocks that are no longer visible are "recycled" for performance purposes and placed again in the player's path (to avoid spawning a lot of unnecessary blocks).

## Meta

Stefan Cojocaru – cojoc07@gmail.com
