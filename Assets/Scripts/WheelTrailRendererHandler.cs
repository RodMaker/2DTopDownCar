using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelTrailRendererHandler : MonoBehaviour
{
    // Components
    CarController carController;
    TrailRenderer trailRenderer;

    private void Awake()
    {
        // Get the top down car controller
        carController = GetComponentInParent<CarController>();
        
        // Get the trail renderer component
        trailRenderer = GetComponent<TrailRenderer>();

        // Set the trail renderer to not emit in the start
        trailRenderer.emitting = false;
    }

    // Update is called once per frame
    void Update()
    {
        // If the car tires are screeching
        if (carController.IsTireScreeching(out float lateralVelocity, out bool isBraking))
        {
            trailRenderer.emitting = true;
        }
        else
        {
            trailRenderer.emitting = false;
        }
    }
}
