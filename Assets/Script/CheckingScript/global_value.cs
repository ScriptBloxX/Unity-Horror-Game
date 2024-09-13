using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class global_value : MonoBehaviour
{
    public bool lightOff;
    public int PlayerConsciousness;
    public InteractBox target_1;
    private bool fuse1Trigger;
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
    }
    IEnumerator RegenConsciousness(){
        while (true){
            yield return new WaitForSeconds(2f);
            if(PlayerConsciousness >49 && PlayerConsciousness<100){
                PlayerConsciousness++;
            }else if(PlayerConsciousness>0 && PlayerConsciousness<30){
                PlayerConsciousness--;
            }else if(PlayerConsciousness<=0){
                PlayerConsciousness = 100;
                SceneManager.LoadScene("OutdoorsScene");
            }
        }
    }
}
