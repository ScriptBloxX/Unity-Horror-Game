using UnityEngine;

public class InteractWithElectric : MonoBehaviour
{
    public GameObject Target;
    public int Amount,AmountNeed;
    public bool Enable;
    public AudioSource source;
    public AudioClip enableClip,useClip;

    void Update(){
        if(Target && Target.GetComponent<global_value>().lightOff==false && Amount==AmountNeed){
            Enable = true;
            if(source&&enableClip){
                source.PlayOneShot(enableClip);
            }
            if(source&&useClip){
                source.PlayOneShot(useClip);
            }
        }else{
            Enable = false;
        }
    }
}