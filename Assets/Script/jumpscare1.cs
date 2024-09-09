using UnityEngine;

public class jumpscare1 : MonoBehaviour
{
    public bool trigger,value;
    public GameObject target;

    void OnTriggerEnter(Collider other)
    {
        if(trigger==false){
            trigger = true;
            target.SetActive(value);
        }
    }
}
