using UnityEngine;

public class SheepClickHandler : MonoBehaviour
{
    private AudioSource sheepAudioSource;
    public AudioClip sheepBleatingClip;  // Assign in the inspector for "sheep-bleating"
    public AudioClip complaintClip;  // Assign in the inspector for "complaint"
    private int clickCount = 0;  // To keep track of clicks
    private bool isMoving = false;  // To control movement
    public float movespeed; // To control sheep running speed

    void Start()
    {
        // Get the AudioSource component
        sheepAudioSource = GetComponent<AudioSource>();

        if (sheepAudioSource != null)
        {
            Debug.Log("AudioSource component successfully retrieved.");
        }
        else
        {
            Debug.LogError("AudioSource component not found!");
        }
    }

    void Update()
    {
        // Check for click event
        if (Input.GetMouseButtonDown(0))  // 0 indicates left mouse button or touchscreen
        {
            Debug.Log("Click detected.");

            // Create a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Shoot the ray and detect collision
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Ray hit: " + hit.collider.gameObject.name);

                // Check if the object clicked is the sheep
                if (hit.collider != null && hit.collider.gameObject == this.gameObject)
                {
                    Debug.Log("Sheep clicked.");

                    clickCount++;  // Increment click count

                    if (clickCount == 1)
                    {
                        // Play the sheep-bleating sound
                        if (sheepAudioSource != null && sheepBleatingClip != null)
                        {
                            sheepAudioSource.clip = sheepBleatingClip;
                            sheepAudioSource.Play();
                            Debug.Log("Sheep bleating sound playing.");
                        }
                    }
                    else if (clickCount == 2)
                    {
                        // Play the complaint sound
                        if (sheepAudioSource != null && complaintClip != null)
                        {
                            sheepAudioSource.clip = complaintClip;
                            sheepAudioSource.Play();
                            Debug.Log("Complaint sound playing.");
                        }

                        // Start moving the sheep forward indefinitely
                        isMoving = true;
                    }
                }
                else
                {
                    Debug.Log("Object clicked is not the sheep.");
                }
            }
            else
            {
                Debug.Log("Ray hit nothing.");
            }
        }

        // Move the sheep forward indefinitely if the flag is set
        if (isMoving)
        {
            transform.Translate(Vector3.forward * movespeed * Time.deltaTime);
        }
    }
}
