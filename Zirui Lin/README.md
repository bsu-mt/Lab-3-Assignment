## Introduction
My part of the project, like everyone else's, is a Unity-based interactive 3D sheep modeling demo where the user clicks on the sheep to trigger a series of animations, audio, and special effects. This document describes in detail each step of the project's creation, as well as the interactive elements included.

## Project Steps

### 1. Create the 3D scene
First create a new 3D scene in Unity, importing a 3D model of a sheep as the main object. Place the model in the center of the scene so that it is easy for the user to see and click on it.

### 2. Add basic components
- **Collider**: Add a `Box Collider` or `Mesh Collider` to the sheep model to detect user clicks.
- **AudioSource**: adds an `AudioSource` component to play audio.
- **ParticleSystem**: Adds a particle system to generate fireworks during the interaction.

### 3. Write the interaction script
Write and attach a `SheepInteraction` script to the sheep model that controls the following behaviors:

#### 3.1 First click - start rotating
The first time the user clicks on the sheep, the sheep starts to rotate around the y-axis at a fixed speed. This is accomplished by `transform.Rotate()` in the `Update()` method.

#### 3.2 Second click - accelerated rotation and audio playback
On the second click on the sheep:
- The first audio is played.
- The rotation speed is doubled.

#### 3.3 Third click - speeds up the rotation and triggers the fireworks.
On the third click on the sheep:
- Play the second audio clip.
- Play the second audio clip.
- Triggers a fireworks effect, which is displayed through the particle system.
- The size of the sheep increases at a rate of 5% per second for 4 seconds.

#### 3.4 Fourth click - Increases spin speed, fireworks density and plays audio
On the fourth click of the sheep:
- The third audio is played, then the fourth audio is played after 1 second.
- The density of the fireworks starts to increase by 0.5x per second until it is 10x.
- The rotation speed also increases by 10% per second, reaching 400% of the original speed after 10 seconds.

#### 3.5 Fifth Click - Reset State
On the fifth click, all behaviors and states of the sheep are reset:
- Stops spinning.
- Stops all fireworks effects.
- Restores original size and rotation speed.
- Ready to accept user interaction again.

## Summary of interaction elements
- **Click event detection**: Use the `OnMouseDown()` method for click event detection.
- **Rotation and scaling**: implemented using `transform.Rotate()` in `Update()` and the concurrent control `transform.localScale`.
- **Audio playback**: Use `AudioSource.PlayOneShot()` to play audio.
- **FX display**: uses the `ParticleSystem` particle system to display the fireworks effect.

Translated with DeepL.com (free version)
