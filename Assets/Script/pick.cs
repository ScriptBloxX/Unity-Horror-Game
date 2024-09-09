using UnityEngine;

public class pick : MonoBehaviour
{
    public bool itemPick;
    public GameObject targetObj;
    public AudioSource source,callback_voice_source;
    public AudioClip clip,callback_voice;

    private void Update() {
        if(itemPick==true){
            source.PlayOneShot(clip);
            callback_voice_source.PlayOneShot(callback_voice);
            targetObj.SetActive(false);
        }
    }
}
