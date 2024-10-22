using UnityEngine;

public class TouchSheepToTriggerEffects : MonoBehaviour
{
    public GameObject snowEffect;        // Assign this in the Inspector
    public GameObject fireworksEffect;   // Assign this in the Inspector
    public float fadeDuration = 2.0f;    // Time it takes for the sheep to fade out

    private bool effectsTriggered = false;   // To ensure we only trigger once per touch
    private Renderer sheepRenderer;          // Reference to the sheep's Renderer
    private Color originalColor;             // Store the original color of the sheep
    private bool startFading = false;        // Check if fading process has started
    private float fadeTimer = 0.0f;          // Timer to control fade duration

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
        if (Input.touchCount > 0 && !effectsTriggered)
        {
            Touch touch = Input.GetTouch(0);   // Get the first touch
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if (touch.phase == TouchPhase.Began)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform == this.transform)  // Check if the sheep was touched
                    {
                        StartEffects();
                    }
                }
            }
        }

        // Handle the fading process
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
                startFading = false;
            }
        }
    }
    
    void StartEffects()
    {
        if (snowEffect != null)
            snowEffect.SetActive(true);

        if (fireworksEffect != null)
            fireworksEffect.SetActive(true);

        effectsTriggered = true;

        // Stop the effects after 5 seconds and then start fading out the sheep
        Invoke("StopEffects", 5f);
    }

    void StopEffects()
    {
        if (snowEffect != null)
            snowEffect.SetActive(false);

        if (fireworksEffect != null)
            fireworksEffect.SetActive(false);

        // Start fading out the sheep
        StartFadeOut();
    }

    void StartFadeOut()
    {
        fadeTimer = 0.0f;       // Reset the fade timer
        startFading = true;     // Start the fading process
    }
}