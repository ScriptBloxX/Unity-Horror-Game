using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ElevatorController : MonoBehaviour{
    public Button up,down;
    public bool CanLift;
    public GameObject player,Panel,model;
    public TextMeshProUGUI stateText;
    public Animator elevator_;
    public string UpAnimation,DownAnimation;
    public AudioClip liftClip,moveClip;
    public AudioSource lifeSource,moveSource;
    void Start () {
        CanLift = true;
		Button up_ = up.GetComponent<Button>();
		Button down_ = down.GetComponent<Button>();

		up_.onClick.AddListener(delegate{LiftControl("up");});
        down_.onClick.AddListener(delegate{LiftControl("down");});
	}
    void Update()
    {
        if(Panel.activeSelf){
            player.GetComponent<FPSController>().canRotate = false;
            player.GetComponent<FPSController>().ShowCursor = true;
        }else{
            player.GetComponent<FPSController>().canRotate = true;
            player.GetComponent<FPSController>().ShowCursor = false;
        }
    }

    void LiftControl(string command){
        if(CanLift){
            stateText.text = "[          "+model.GetComponent<Elevator>().state+"          ]";
            StartCoroutine(DoorClose(1,command));
        }
	}

    IEnumerator DoorClose(float delay,string command){
        model.GetComponent<Elevator>().open = false;
        if(command=="up" && model.GetComponent<Elevator>().state == 0&&CanLift){
            player.GetComponent<FPSController>().canMove = false;
        }else if(command=="down" && model.GetComponent<Elevator>().state == 1&&CanLift){
            player.GetComponent<FPSController>().canMove = false;
        }
        yield return new WaitForSeconds(delay);
        // lift work
        if(command=="up" && model.GetComponent<Elevator>().state == 0&&CanLift){
            CanLift = false;
            player.transform.SetParent(model.transform);
            elevator_.Play(UpAnimation,0,.0f);
            StartCoroutine(AnimationFinished(5,1));
        }else if(command=="down" && model.GetComponent<Elevator>().state == 1&&CanLift){
            CanLift = false;
            player.transform.SetParent(model.transform);
            elevator_.Play(DownAnimation,0,.0f);
            StartCoroutine(AnimationFinished(5,0));
        }
    }
    IEnumerator AnimationFinished(float delay,int LiftState){
        moveSource.PlayOneShot(moveClip);
        yield return new WaitForSeconds(delay-1);
        lifeSource.PlayOneShot(liftClip);
        yield return new WaitForSeconds(1);
        model.GetComponent<Elevator>().state = LiftState;
        stateText.text = "[          "+model.GetComponent<Elevator>().state+"          ]";
        player.transform.SetParent(null);
        model.GetComponent<Elevator>().open = true;
        player.GetComponent<FPSController>().canMove = true;
        CanLift = true;
    }
}
