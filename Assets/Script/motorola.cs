using UnityEngine;

public class motorola : MonoBehaviour
{
    public GameObject equip;
    public AudioSource source,talk_2;
    public AudioClip clip;
    public AudioClip[] call;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)&&equip.GetComponent<pick>().itemPick){
            source.PlayOneShot(clip);
            randomCall();
        }
    }
    void randomCall(){
        talk_2.PlayOneShot(call[Random.Range(0, call.Length)]);
    }
}
