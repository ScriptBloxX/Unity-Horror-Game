using UnityEngine;

public class inject : MonoBehaviour
{
    public GameObject target;
    void Update(){
        if(GetComponent<InteractWithElectric>().Enable){
            target.SetActive(true);
        }else{
            target.SetActive(false);
        }
    }
}