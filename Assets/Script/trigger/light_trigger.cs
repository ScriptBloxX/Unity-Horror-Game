using System.Collections;
using UnityEngine;

public class light_trigger : MonoBehaviour
{
    public GameObject light_1;
    public GameObject light_2;
    public GameObject lightSound;
    public GameObject diary;

    public bool ever_trigger = false;

    void OnTriggerEnter(Collider other)
    {
        if(ever_trigger==false){
            ever_trigger = true;

            lightSound.SetActive(true);
            StartCoroutine(ActiveCoroutine(lightSound,1.1,false));
            light_1.SetActive(false);
            StartCoroutine(ActiveCoroutine(light_1,.5,true));
            StartCoroutine(ActiveCoroutine(light_1,.6,false));
            StartCoroutine(ActiveCoroutine(diary,.6,true));
            StartCoroutine(ActiveCoroutine(light_1,.7,true));
            StartCoroutine(ActiveCoroutine(light_2,.7,true));
        }
    }

    IEnumerator ActiveCoroutine(GameObject obj,double sec,bool val)
    {
        yield return new WaitForSeconds((float)sec);
        obj.SetActive(val);
    }
}
