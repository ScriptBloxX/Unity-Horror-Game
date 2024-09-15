using System.Collections;
using UnityEngine;

public class cam_trigger : MonoBehaviour
{
    public bool trigger,value,nextStep;
    public Camera playerCamera,targetCamera;
    public GameObject target,target2,nextTrigger,door;
    public AudioSource source;
    public AudioClip clip;
    void OnTriggerEnter(Collider other){
        if(trigger==false){
            trigger = true;
            target.SetActive(value);
            GameObject.FindGameObjectWithTag("global").GetComponent<global_value>().PlayerConsciousness -= 35;
            targetCamera.GetComponent<Camera>().enabled = true;
            playerCamera.GetComponent<Camera>().enabled = false;
            if(door){
                door.GetComponent<door>().Open = false;
            }
            source.PlayOneShot(clip);
            StartCoroutine(SwitchCam());
        }
    }
    IEnumerator SwitchCam(){
        yield return new WaitForSeconds(.5f);
            playerCamera.GetComponent<Camera>().enabled = true;
            targetCamera.GetComponent<Camera>().enabled = false;
            source.Stop();
            target.SetActive(false);
            target2.SetActive(value);
            nextTrigger.SetActive(value);
    }
}