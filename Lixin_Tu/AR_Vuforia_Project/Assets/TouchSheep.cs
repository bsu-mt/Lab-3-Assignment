using UnityEngine;

public class TouchSheep : MonoBehaviour
{
    public GameObject snowEffect;
    public GameObject fireworksEffect;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;

            if (touch.phase == TouchPhase.Began)
            {
                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log("Raycast hit: " + hit.transform.name); // Add this line to see if the sheep is hit

                    if (hit.transform.name == "Sheep")
                    {
                        Debug.Log("Sheep touched!"); // Add this line to check if the sheep is detected
                        StartEffects();
                    }
                }
            }
        }
    }

    void StartEffects()
    {
        snowEffect.SetActive(true);
        fireworksEffect.SetActive(true);
        Debug.Log("Effects started!"); // Add this to confirm that effects are triggered
    }
}