using System.Collections;
using UnityEngine;

public class pick2 : MonoBehaviour
{
    public bool itemPick,pick;
    public GameObject targetObj,targetItem;
    public AudioSource source;
    public AudioClip clip;

    private void Update() {
        if(itemPick==true && pick==false){
            pick = true;
            source.PlayOneShot(clip);
            StartCoroutine(ActiveCoroutine());
        }
    }

    IEnumerator ActiveCoroutine()
    {
        yield return new WaitForSeconds((float).48);
        targetItem.GetComponent<flashlight_system>().have = true;
        targetObj.SetActive(false);
    }

}
