using System.Collections;
using UnityEngine;

public class strobe : MonoBehaviour
{
    public GameObject target;
    void Start(){
        StartCoroutine(flash());
    }
    IEnumerator flash(){
        while (true){
            target.gameObject.SetActive(false);
            yield return new WaitForSeconds(.1f);
            target.gameObject.SetActive(true);
            yield return new WaitForSeconds(.1f);
        }
    }
}