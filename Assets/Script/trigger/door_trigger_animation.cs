using UnityEngine;

public class door_trigger_animation : MonoBehaviour
{
    public GameObject target_door;
    public bool trigger,value;
   void OnTriggerEnter(Collider other)
   {
    if(trigger==false){
        trigger = true;
        target_door.GetComponent<door>().Open = value;
    }
   }
}
