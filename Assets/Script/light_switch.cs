using UnityEngine;

public class light_switch : MonoBehaviour
{
    public bool Disabled = false;
    public GameObject targetObj;

    private void Update() {
        if(GameObject.FindGameObjectWithTag("global").GetComponent<global_value>().lightOff){
            targetObj.SetActive(false);
        }else{
            if(Disabled){
                targetObj.SetActive(false);
            }else{
                targetObj.SetActive(true);
            }
        }
    }
}
