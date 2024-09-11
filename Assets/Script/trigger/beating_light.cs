using System.Collections;
using UnityEngine;

public class beating_light : MonoBehaviour
{   
    public Light pl;

void Start()
{
    if (pl == null)
    {
        Debug.LogError("Light component not assigned!");
        return;
    }
    StartCoroutine(LightBeating());
}

    private IEnumerator LightBeating()
    {
        while (true)
        {
            pl.intensity = 600f;
            yield return new WaitForSeconds(.100f);
            pl.intensity = 200f;
            yield return new WaitForSeconds(.100f);
        }
    }
}