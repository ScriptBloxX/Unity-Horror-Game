using UnityEngine;

public class rotation_trigger : MonoBehaviour
{
    public bool trigger;
    public GameObject target;
    public Vector3 rotation = new Vector3();
    public AudioClip clip;
    public AudioSource source;

    void OnTriggerEnter(Collider other)
    {
        if(trigger==false){
            trigger = true;
            target.transform.rotation = Quaternion.Euler(rotation);
            source.PlayOneShot(clip);
            GameObject.FindGameObjectWithTag("global").GetComponent<global_boolean>().PlayerConsciousness -= 5;
        }
    }
}
