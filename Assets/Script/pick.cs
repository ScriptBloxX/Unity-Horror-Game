using System.Collections;
using UnityEngine;

public class pick : MonoBehaviour
{
    public bool itemPick,Pick;
    public GameObject targetObj;
    public AudioSource source,callback_voice_source;
    public AudioClip clip,callback_voice;

    private void Update() {
        if(itemPick==true && Pick==false){
            Pick = true;
            source.PlayOneShot(clip);
            callback_voice_source.PlayOneShot(callback_voice);
            StartCoroutine(ActiveCoroutine());
        }
    }
    IEnumerator ActiveCoroutine(){
            yield return new WaitForSeconds((float).48);
            targetObj.SetActive(false);
    }
}
