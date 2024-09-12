using System;
using System.Collections;
using UnityEngine;

public class PickAmount : MonoBehaviour
{
    public bool itemPick,pick;
    public GameObject targetItem;
    public AudioSource source;
    public AudioClip clip;
    public Canvas canvas_ui;

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
        targetItem.GetComponent<fuse>().Amount ++; // need something like target.GetComponent<transform.gameObject.name>().amount ++ any one can help me?
        canvas_ui.gameObject.SetActive(true);
        transform.gameObject.SetActive(false);
    }
} 