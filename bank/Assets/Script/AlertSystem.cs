using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AlertSystem : MonoBehaviour
{
    [Header("Lights & Sound")]
    public List<Light> alertLights = new List<Light>(); // assign multiple lights
    public AudioSource alertSound;

    private bool isAlertActive = false;

    // Trigger the alert
    public void StartAlert()
    {
        if (isAlertActive) return;
        isAlertActive = true;

        if (alertSound != null && !alertSound.isPlaying)
            alertSound.Play();

        StartCoroutine(BlinkLoop());
    }

    // Stop the alert
    public void StopAlert()
    {
        isAlertActive = false;

        if (alertSound != null)
            alertSound.Stop();

        foreach (var light in alertLights)
        {
            if (light != null)
                light.enabled = false;
        }
    }

    // Loop for blinking lights
    private IEnumerator BlinkLoop()
    {
        while (isAlertActive)
        {
            foreach (var light in alertLights)
            {
                if (light != null)
                    light.enabled = !light.enabled;
            }
            yield return new WaitForSeconds(0.5f);
        }

        // Ensure all lights off when done
        foreach (var light in alertLights)
        {
            if (light != null)
                light.enabled = false;
        }
    }
}
