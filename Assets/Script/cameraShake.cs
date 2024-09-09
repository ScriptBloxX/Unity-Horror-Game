using System.Collections;
using UnityEngine;

public class cameraShake : MonoBehaviour
{
    public bool shake = false;
    public AnimationCurve curve;
    public float duration = 1f;
    void Update()
    {
        if(shake){
            shake = false;
            StartCoroutine(Shaking());
        }
    }

    IEnumerator Shaking() {
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration) {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime/duration);
            transform.position = startPosition + Random.insideUnitSphere;
            yield return null;
        }
        transform.position = startPosition;
    }
}
