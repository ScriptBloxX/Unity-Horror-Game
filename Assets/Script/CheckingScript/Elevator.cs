using UnityEngine;

public class Elevator : MonoBehaviour
{
    public bool open,check;
    public int state;
    public Animator elevator_;
    public string OpenAnimation,CloseAnimation,OpenAnimation1,CloseAnimation1;
    public AudioSource source;
    public AudioClip clip;
    void Update()
    {
        if (open && check == false){
            check = true;
            //source.PlayOneShot(clip);
            if(state < 1){
                elevator_.Play(OpenAnimation, 0, 0.0f);
            }else if(state > 0){
                elevator_.Play(OpenAnimation1, 0, 0.0f);
            }
        }
        else if (open == false && check == true){
            check = false;
            //source.PlayOneShot(clip);
            if(state < 1){
                elevator_.Play(CloseAnimation, 0, 0.0f);
            }else if(state > 0){
                elevator_.Play(CloseAnimation1, 0, 0.0f);
            }
        }
    }
}
