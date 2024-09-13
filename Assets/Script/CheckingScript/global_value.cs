using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
using UnityEngine.SceneManagement;

public class global_value : MonoBehaviour
{
    public bool lightOff;
    private bool fuse1Trigger,ReadySwitch;
    public int PlayerConsciousness;
    public InteractBox target_1;
    public Volume SkyLight;
    public AudioSource source;
    public AudioClip clip1,clip2;
    void Start()
    {
        StartCoroutine(RegenConsciousness());    
    }
    void Update(){
        if(target_1.Enable){
            lightOff = false;
            if(!fuse1Trigger){
                fuse1Trigger = true;
                Debug.Log("On Trigger");
                PlayerConsciousness -= 50;
            }
        }
        if(PlayerConsciousness>49&&source.clip!=clip1){
            source.clip = clip1;
            source.Stop();
            source.PlayOneShot(clip1);
        }else if(PlayerConsciousness<=49&&source.clip!=clip2){
            source.clip = clip2;
            source.Stop();
            source.PlayOneShot(clip2);
        }
    }
    IEnumerator RegenConsciousness(){
        while (true){
            yield return new WaitForSeconds(2f);
            if (SkyLight.TryGetComponent<Volume>(out var globalVolume)){
                if(globalVolume.profile.TryGet<MotionBlur>(out var motionBlurComponents)){
                    motionBlurComponents.intensity = new MinFloatParameter(CalV(PlayerConsciousness,1.85f,200f),CalV(PlayerConsciousness,1.85f,200f),true);
                    motionBlurComponents.maximumVelocity = new ClampedFloatParameter(CalV(PlayerConsciousness,9f,1000f),2f,CalV(PlayerConsciousness,9f,1000f),true);
                }
            }
            if(PlayerConsciousness >49 && PlayerConsciousness<100){
                PlayerConsciousness++;
            }else if(PlayerConsciousness>0 && PlayerConsciousness<30){
                PlayerConsciousness--;
            }else if(PlayerConsciousness<=0){
                SceneManager.LoadScene("OutdoorsScene");
            }
        }
    }
    public float CalV(float playerConsciousness,float default_, float max)
    {
        playerConsciousness = Mathf.Clamp(playerConsciousness, 0, 100);
        float intensity = -default_ * playerConsciousness + max;
        
        return intensity;
    }
}
