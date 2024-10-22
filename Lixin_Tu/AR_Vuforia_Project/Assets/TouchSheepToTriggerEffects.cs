using UnityEngine;

public class TouchSheepToTriggerEffects : MonoBehaviour
{
    public GameObject snowEffect;        // Assign this in the Inspector
    public GameObject fireworksEffect;   // Assign this in the Inspector

    private bool effectsTriggered = false;   // To ensure we only trigger once per touch

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
    }
    
    void StartEffects()
    {
        if (snowEffect != null)
            snowEffect.SetActive(true);

        if (fireworksEffect != null)
            fireworksEffect.SetActive(true);

        effectsTriggered = true;

        // Stop the effects after 5 seconds
        Invoke("StopEffects", 5f);
    }

    void StopEffects()
    {
        if (snowEffect != null)
            snowEffect.SetActive(false);

        if (fireworksEffect != null)
            fireworksEffect.SetActive(false);

        effectsTriggered = false;  // Allow effects to be triggered again
    }
    
    
}