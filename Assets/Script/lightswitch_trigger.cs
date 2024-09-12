using UnityEngine;

public class lightswitch_trigger : MonoBehaviour
{
    public GameObject target;
    public AudioSource targetSource;
    public AudioClip clip;
    public bool trigger = false;

    void OnTriggerEnter(Collider other)
    {
        if(trigger==false){
            trigger = true;
            target.GetComponent<light_switch>().Disabled = true;
            targetSource.PlayOneShot(clip);
            GameObject.FindGameObjectWithTag("global").GetComponent<global_boolean>().PlayerConsciousness -= 5;
        }
    }
}
