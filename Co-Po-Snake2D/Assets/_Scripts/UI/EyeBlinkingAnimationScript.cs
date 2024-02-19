using System.Collections;
using UnityEngine;

public class EyeBlinkingAnimationScript : MonoBehaviour
{
    [SerializeField] private GameObject leftEye;
    [SerializeField] private GameObject rightEye;

    private bool isBlinking = false;
    private const float initialDelay = 1f;
    private const float minDelay = 2f;
    private const float maxDelay = 4f;
    private const int minBlinks = 1;
    private const int maxBlinks = 2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EyeBlinkingCoroutine());
    }

    private IEnumerator EyeBlinkingCoroutine()
    {
        while (true)
        {
            // Generate a random number of blinks
            int numBlinks = Random.Range(minBlinks, maxBlinks + 1);

            for (int i = 0; i < numBlinks; i++)
            {
                // Start blinking
                isBlinking = true;
                BlinkEyes();

                // Wait for a short time for the blink animation to complete
                yield return new WaitForSeconds(0.1f);

                // Stop blinking
                isBlinking = false;
                BlinkEyes();

                // Wait for a random interval between blinks
                float blinkInterval = Random.Range(0.1f, 0.5f);
                yield return new WaitForSeconds(blinkInterval);
            }

            // Wait for a random delay before starting the next blinking sequence
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);
        }
    }

    private void BlinkEyes()
    {
        // Toggle the state of the eye game objects
        leftEye.SetActive(!isBlinking);
        rightEye.SetActive(!isBlinking);
    }
}
