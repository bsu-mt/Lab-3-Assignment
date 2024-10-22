using UnityEngine;

public class SheepFadeOut : MonoBehaviour
{
    public float fadeDuration = 2.0f; // Duration for the sheep to fade out
    private Renderer sheepRenderer;
    private Color originalColor;
    private bool startFading = false;
    private float fadeTimer = 0.0f;

    void Start()
    {
        sheepRenderer = GetComponent<Renderer>();
        if (sheepRenderer != null)
        {
            // Store the original color of the sheep's material
            originalColor = sheepRenderer.material.color;
        }
    }

    void Update()
    {
        if (startFading)
        {
            fadeTimer += Time.deltaTime;

            // Calculate the fading factor
            float fadeFactor = 1 - (fadeTimer / fadeDuration);
            Color newColor = originalColor;
            newColor.a = Mathf.Clamp01(fadeFactor); // Adjust alpha

            if (sheepRenderer != null)
            {
                // Apply the new color to the material
                sheepRenderer.material.color = newColor;
            }

            // Once fully faded, disable the object
            if (fadeTimer >= fadeDuration)
            {
                gameObject.SetActive(false);
            }
        }
    }

    // Public method to start the fade-out process
    public void StartFadeOut()
    {
        startFading = true;
    }
}