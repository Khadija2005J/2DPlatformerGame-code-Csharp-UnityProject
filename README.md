# Roller Ball Platformer – Unity C# Scripts

**Gameplay scripts for a Unity platformer where the player rolls a ball through a course of platforms, traps and obstacles to reach the goal.**

This repository contains the C# scripts only. To play, add them to a Unity scene (see below).

## Gameplay

- Move the ball with the arrow keys / WASD (physics-based movement)
- Avoid traps: touching one sends you back to the respawn point after a short delay
- You have **3 lives**
- Obstacles turn the player red on contact
- Reach the goal zone to win: the ball is launched and a "You Win!" message appears
- Click a switch object to toggle the scene light

## Scripts

| Script | Role |
|--------|------|
| `RollerBall.cs` | Player movement, lives and respawn |
| `TriggerZone.cs` | Trap zones that trigger a respawn |
| `Obstacle.cs` | Changes the player's color on collision |
| `GoalZone.cs` | Win condition, launch force and win text |
| `CameraTracker.cs` | Camera that follows the player |
| `LightSwitch.cs` | Toggles a light when clicked |
| `PlayerController.cs` | Empty placeholder |

## Using the scripts

1. Create a new Unity project and import **TextMeshPro**.
2. Copy the `.cs` files into `Assets/Scripts/`.
3. Create a sphere tagged **Player** with a **Rigidbody**, and attach `RollerBall`. Assign a respawn point.
4. Attach `CameraTracker` to the main camera and drag the player into its `player` field.
5. Add colliders for traps (`TriggerZone`), obstacles (`Obstacle`) and the goal (`GoalZone`, with a TextMeshPro text for the win message).

## Tech stack

Unity, C#, Unity Physics (Rigidbody), TextMeshPro.

## Author

Khadija Alaoui Mrani – [GitHub](https://github.com/Khadija2005J)
