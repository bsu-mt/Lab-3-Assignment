1. Setting Up the Image Target (Workbook)

In this AR project, the workbook image was uploaded to the Vuforia Target Manager, processed, and used to create a database. This database was then imported into Unity. Once in Unity, an Image Target object was added to the scene, where the Vuforia database was selected, and the workbook image was assigned as the target. This setup ensures that when the camera detects the workbook image, the AR content is displayed in the scene.

2. Adding the 3D Sheep Model

A 3D sheep model was imported and positioned above the workbook image in the Unity scene. The sheep model was then made a child of the Image Target object, ensuring that it only becomes visible when the camera recognizes the workbook image. This approach links the virtual sheep to the real-world workbook image, so it appears in AR when the image is scanned.

3. Adding Interaction: Touch to Trigger Snow and Fireworks

To introduce interactivity, a script was created to handle touch input. The script detects when the user touches the sheep by casting a ray from the touch position on the screen. If the ray hits the sheep, two particle effects—falling snow and fireworks—are activated. These effects are initially set to inactive and only become active when triggered by a touch. This interaction adds an engaging layer to the AR experience, making the sheep interactive and responsive to user input.

4. Pseudo-code Summary for Interaction and Visual Effects

The interaction and visual effects were implemented using the following logic. When the scene loads, Vuforia initializes and the sheep is positioned above the workbook image, ready to appear when the workbook is recognized. If the user touches the screen, the system checks whether the sheep was touched using a raycast. If the sheep is touched, the snow and fireworks effects are activated by enabling the respective particle systems. After the effects are displayed for a set duration, the sheep gradually fades out. Below is the pseudo-code breakdown:

	1.	Scene Load:
	•	Initialize Vuforia to detect the workbook image.
	•	Position the sheep model above the workbook image.
	2.	Touch Interaction:
	•	Detect if the user touches the screen.
	•	Cast a ray from the touch point into the scene.
	•	Check if the ray hits the sheep model.
	3.	Trigger Effects:
	•	If the sheep is touched:
	•	Activate the snow particle system.
	•	Activate the fireworks particle system.
	4.	Fade Out:
	•	After a set duration (5 seconds in this case), stop the effects.
	•	Gradually fade out the sheep by reducing its opacity, and then disable the object once it becomes fully transparent.