using UnityEngine;

public class door_trigger : MonoBehaviour
{
    public GameObject target_door_1;
    public GameObject target_door_2;
    public AudioSource source;
    public AudioClip clip;
    public bool trigger = false;
   void OnTriggerEnter(Collider other)
   {
    if(trigger==false){
        trigger = true;
        target_door_1.SetActive(false);
        target_door_2.SetActive(true);
        source.PlayOneShot(clip);
        GameObject.FindGameObjectWithTag("global").GetComponent<global_boolean>().PlayerConsciousness -= 7;
    }
   }
}
