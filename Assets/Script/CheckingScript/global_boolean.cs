using UnityEngine;

public class global_boolean : MonoBehaviour
{
    public bool lightOff;
    public InteractBox target_1;

    void Update(){
        if(target_1.Enable){
            lightOff = false;
        }
    }
}