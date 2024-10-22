using System.Collections;
using UnityEngine;

public class SheepRotation : MonoBehaviour
{
    private bool isRotating = false;  
    public float rotationSpeed = 100f;  

    void Update()
    {
        if (isRotating)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }

    void OnMouseDown()
    {
        isRotating = !isRotating;
    }
}
