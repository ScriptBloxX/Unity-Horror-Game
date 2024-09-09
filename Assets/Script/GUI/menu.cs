using UnityEngine;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    public Button start_btn,options,credits,exit;
    public GameObject MainMenu,Player;

	void Start () {
		Button start_ = start_btn.GetComponent<Button>();
		Button options_ = options.GetComponent<Button>();
		Button credits_ = credits.GetComponent<Button>();
		Button exit_ = exit.GetComponent<Button>();

		start_.onClick.AddListener(StartClick);
	}

	void Update() {
		if(Input.GetKeyDown(KeyCode.Escape) && MainMenu.activeSelf==false){
			Player.GetComponent<FPSController>().canMove = false;
			MainMenu.SetActive(true);
		}else if(Input.GetKeyDown(KeyCode.Escape) && MainMenu.activeSelf) {
			Player.GetComponent<FPSController>().canMove = true;
        	MainMenu.SetActive(false);
		}
	}

	void StartClick(){
		Player.GetComponent<FPSController>().canMove = true;
        MainMenu.SetActive(false);
	}
}
