using UnityEngine;

public class light_switch : MonoBehaviour
{
    public bool Disabled = false;
    public GameObject targetObj;

    private void Update() {
        if(Disabled){
            targetObj.SetActive(false);
        }else{
            targetObj.SetActive(true);
        }
    }
}
