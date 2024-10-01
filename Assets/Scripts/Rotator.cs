using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update
    public  TextMeshProUGUI displayText; // Assign in the inspector
    private Vector3 lastPosition;
    void Start()
    {
        // Initialize the last position
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
         // Calculate the current position and velocity
        Vector3 currentPosition = transform.position;
        Vector3 velocity = (currentPosition - lastPosition) / Time.deltaTime;

        // Update the last position for the next frame
        lastPosition = currentPosition;

        // Calculate speed as a scalar
        float speed = velocity.magnitude;

        // Format position and velocity
        string positionString = $"Position: {currentPosition.ToString("0.00")}";
        string velocityString = $"Velocity: {velocity.ToString("0.00")}";
        string speedString = $"Speed: {speed.ToString("0.00")}";

        // Update the display text
        displayText.text = $"{positionString}\n{velocityString}\n{speedString}";
    }
}