using UnityEngine;

public class door : MonoBehaviour
{
    public bool Open,doorCheck;
    public Animator door_;
    public string OpenAnimation,CloseAnimation;
    public AudioSource source;
    public AudioClip clip;

    private void Update() {
        if(Open && doorCheck == false){
            doorCheck = true;
            source.PlayOneShot(clip);
            door_.Play(OpenAnimation,0,0.0f);
        }else if(Open == false && doorCheck == true){
            doorCheck = false;
            door_.Play(CloseAnimation,0,0.0f);
            source.PlayOneShot(clip);
        }
    }
}
