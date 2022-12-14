# CMPM 121 - Final Project - NPC Chase Scene

## Build file
Located at `./Final_Project/Build/Final_Project.exe`

## Link to demonstration video
https://drive.google.com/file/d/1OYG1K_cfBpQxjmMuhQQ9JAJLClJd1R4U/view?usp=share_link

## Basic controls
- WASD to move around
- Mouse to look around (only on horizontal axis)
- Click to throw cupcake

## Imported Objects (Made by Amanda in Blender)
- Hello Kitty (Controllable character)
- Chococat (NPC)
- Playground objects
  - Bench
  - Bike
  - Sandbox
  - Slide
  - Swing
  - Wagon
- Trees
- Landscape

## Particle System
Hearts being emitted from Chococat

## NPC
When the player gets within range of the NPC (detected by radius), it starts to follow.

## Interactions
- When the NPC makes contact with the player, the scene resets
- When the player throws a cupcake at the NPC, it will stop for a couple seconds

## Obstacles
The playground objects and trees have colliders that act as obstacles for the player and NPC characters.
