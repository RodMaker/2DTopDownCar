using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelParticleHandler : MonoBehaviour
{
    // Local variables
    float particleEmissionRate = 0;

    // Components
    CarController carController;

    ParticleSystem particleSystemSmoke;
    ParticleSystem.EmissionModule particleSystemEmissionModule;

    private void Awake()
    {
        carController = GetComponentInParent<CarController>();
        particleSystemSmoke = GetComponent<ParticleSystem>();
        particleSystemEmissionModule = particleSystemSmoke.emission;
        particleSystemEmissionModule.rateOverTime = 0;
    }

    private void Update()
    {
        // Reduce the particles over time
        particleEmissionRate = Mathf.Lerp(particleEmissionRate, 0, Time.deltaTime * 5);
        particleSystemEmissionModule.rateOverTime = particleEmissionRate;

        if (carController.IsTireScreeching(out float lateralVelocity, out bool isBraking))
        {
            if (isBraking)
            {
                particleEmissionRate = 30;
            }
            else
            {
                particleEmissionRate = Mathf.Abs(lateralVelocity) * 2;
            }
        }
    }
}
