using UnityEngine;

public class flashlight_system : MonoBehaviour
{
    public bool have,enable;
    public GameObject target;

    private void Update() {
        if(have && Input.GetKeyDown(KeyCode.Q)){
            if(enable){
                enable = false;
                target.SetActive(false);
            }else{
                enable = true;
                target.SetActive(true);
            }
        }
    }       
}
