using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public GameObject[] pickups; // Array of pickup objects
    public TextMeshProUGUI distanceText; // UI Text component to display the distance

    private LineRenderer lineRenderer;

    void Start()
    {
        // Add the LineRenderer component to this GameObject
        lineRenderer = gameObject.AddComponent<LineRenderer>();

        // Set LineRenderer properties
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.positionCount = 2; // We need two points (start and end)
        lineRenderer.material = new Material(Shader.Find("Sprites/Default")); // Set a basic material
        lineRenderer.startColor = Color.red; // Set the starting color
        lineRenderer.endColor = Color.red; // Set the ending color
    }

    void Update()
    {
        UpdateClosestPickup();
    }

    void UpdateClosestPickup()
    {
        GameObject closestPickup = null;
        float closestDistance = float.MaxValue;
        Vector3 playerPosition = transform.position; // Assume this script is attached to the player

        // Reset colors of all pickups first
        foreach (GameObject pickup in pickups)
        {
            if (pickup.activeInHierarchy) // Check if pickup is active
            {
                pickup.GetComponent<Renderer>().material.color = Color.white;
            }
        }

        // Find the closest active pickup
        foreach (GameObject pickup in pickups)
        {
            if (pickup.activeInHierarchy) // Only check active pickups
            {
                float distance = Vector3.Distance(playerPosition, pickup.transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestPickup = pickup;
                }
            }
        }

        // Update the distance text if a closest pickup is found
        if (closestPickup != null)
        {
            // Change the color of the closest pickup to blue
            closestPickup.GetComponent<Renderer>().material.color = Color.blue;

            // Update the distance text
            distanceText.text = $"Distance to Closest Pickup: {closestDistance.ToString("0.00")}";

            // Draw the line to the closest pickup
            Vector3 closestPickupPosition = closestPickup.transform.position;
            lineRenderer.SetPosition(0, playerPosition); // Start point
            lineRenderer.SetPosition(1, closestPickupPosition); // End point
        }
        else
        {
            distanceText.text = "No pickups available.";
            lineRenderer.enabled = false; // Disable line if no pickups are available
        }
    }
}