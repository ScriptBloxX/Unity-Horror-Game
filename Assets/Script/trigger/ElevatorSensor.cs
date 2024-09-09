using UnityEngine;
using System.Collections;

public class ElevatorSensor : MonoBehaviour
{
    public GameObject Elevator_;
    public bool delay;
    
    void OnTriggerEnter(Collider other)
    {
        var target = Elevator_.GetComponent<Elevator>();    
        if(target.open && delay == false){
            StartCoroutine(delay_());
            target.open = false;
        }else if(target.open == false && delay == false){
            StartCoroutine(delay_());
            target.open = true;
        }
    }
    IEnumerator delay_()
    {
        delay = true;
        yield return new WaitForSeconds(1);
        delay = false;
    }
}
