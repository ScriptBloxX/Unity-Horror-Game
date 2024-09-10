using UnityEngine;
using TMPro;

public class raycast : MonoBehaviour
{
    // config
    public Camera cam;
    public LayerMask mask;
    public float distance;
    // ui
    public GameObject button_ui,motorola_ui,motorola_text_ui,dairyUI,ElevatorControl;
    public TextMeshProUGUI ui;
    [HideInInspector] public bool diaryRead;

    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);

        if (Physics.Raycast(ray, out hit, distance, mask)){
            // light switch
            light_switch LightSwitchScript = gameObject.GetComponent<light_switch>();
            if(hit.collider.gameObject.GetComponent<light_switch>()!=null){
                // turn on/off the light
                if(Input.GetKeyDown(KeyCode.F)){
                    if(hit.collider.gameObject.GetComponent<light_switch>().Disabled){
                        hit.collider.gameObject.GetComponent<light_switch>().Disabled = false;
                    }else{
                        hit.collider.gameObject.GetComponent<light_switch>().Disabled = true;
                    }
                    hit.collider.gameObject.GetComponent<AudioSource>().Play();
                }
                    // in distance
                    if(hit.collider.gameObject.GetComponent<light_switch>().Disabled){
                        ui.text = "F To Turn On The Light";
                    }else{
                        ui.text = "F To Turn Off The Light";
                    }
                    button_ui.SetActive(true);
                }

            // pick item
            pick motorola = gameObject.GetComponent<pick>();
            if(hit.collider.gameObject.GetComponent<pick>()!=null){
                // pick item
                if(Input.GetKeyDown(KeyCode.F)){
                    hit.collider.gameObject.GetComponent<pick>().itemPick = true;
                    motorola_ui.SetActive(true);
                    motorola_text_ui.SetActive(true);
                }
                // in distance
                ui.text = "F To Pick";
                button_ui.SetActive(true);
            }

            // diary reader
            diaryUI diary = gameObject.GetComponent<diaryUI>();
            if(hit.collider.gameObject.GetComponent<diaryUI>()!=null){
                if(dairyUI.transform.Find(hit.collider.gameObject.name)!=null){
                    dairyUI.SetActive(true);
                    dairyUI.transform.Find(hit.collider.gameObject.name).gameObject.SetActive(true);
                    if(diaryRead==false){
                        diaryRead = true;
                    }
                }
            }

            // door system
            door doorSystem = gameObject.GetComponent<door>();
            if(hit.collider.gameObject.GetComponent<door>()!=null){
                if(Input.GetKeyDown(KeyCode.F)){
                    if(hit.collider.gameObject.GetComponent<door>().Open){
                        hit.collider.gameObject.GetComponent<door>().Open = false;
                    }else{
                        hit.collider.gameObject.GetComponent<door>().Open = true;
                    }
                }
                // in distance
                if(hit.collider.gameObject.GetComponent<door>().Open){
                    ui.text = "F To Close The Door";
                }else{
                    ui.text = "F To Open The Door";
                }
                button_ui.SetActive(true);
            }

            // pick item 2
            pick2 item = gameObject.GetComponent<pick2>();
            if(hit.collider.gameObject.GetComponent<pick2>()!=null){
                // pick item
                if(Input.GetKeyDown(KeyCode.F)){
                    hit.collider.gameObject.GetComponent<pick2>().itemPick = true;
                }
                // in distance
                ui.text = "F To Pick";
                button_ui.SetActive(true);
            }

            // Elevator Control
            ElevatorControl_Check elevator = gameObject.GetComponent<ElevatorControl_Check>();
            if(hit.collider.gameObject.GetComponent<ElevatorControl_Check>()!=null){
                ElevatorControl.SetActive(true);
            } 

        }else{ // out distance
            if(button_ui.activeSelf || dairyUI.activeSelf || ElevatorControl.activeSelf){
                button_ui.SetActive(false);
                dairyUI.SetActive(false);
                ElevatorControl.SetActive(false);
            }

            if(diaryRead){
                diaryRead = false;
                foreach(Transform child in dairyUI.transform){
                    child.gameObject.SetActive(false);
                }
            }

        } 
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(cam.transform.position,cam.transform.forward*distance);   
    }

}
