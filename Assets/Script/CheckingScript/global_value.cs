using UnityEngine;

public class global_value : MonoBehaviour
{
    public bool lightOff;
    public int PlayerConsciousness;
    public InteractBox target_1;
    private bool fuse1Trigger;

    void Update(){
        if(target_1.Enable){
            lightOff = false;
            if(!fuse1Trigger){
                fuse1Trigger = true;
                GameObject.FindGameObjectWithTag("global").GetComponent<global_value>().PlayerConsciousness -= 50;
            }
        }
    }
}