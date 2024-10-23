# Encounter a Sheep and Interact Scene
### Add an Image Target
In this scene, the workbook picture is used as the image target through Vuforia to enable marker-based AR implementation.
### Import Assets
A group of assets containing sheep models and so on was imported from the Unity Assets Store. Finally, we only used the sheep model.
### Write a Script (The explanation of the code is in the comments of the script)
A C# script was written to implement the following function:
- Click on the sheep on the screen for the first time and the sheep bleats.
- click on the sheep for the second time, it says "Okay, nice to meet you. Bye~" and moves away out of the screen.
### Add Components to the Sheep
Add components including AudioSource, Script, Collider, and so on.
### Build and Debug
In the Settings of the Android tablet, activate developer mode and enable USB-Debugging. Then connect the tablet to the laptop and build the application.
### Test and Adjust
Test on the app to see if it works, and modify the code to achieve a satisfactory result.
