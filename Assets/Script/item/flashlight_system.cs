using UnityEngine;
using System.Collections;

public class flashlight_system : MonoBehaviour
{
    public bool have, enable;
    public GameObject target;
    private Coroutine disableCoroutine;

    private void Update()
    {
        if (have && Input.GetKeyDown(KeyCode.Q)){
            if (enable){
                enable = false;
                target.SetActive(false);
                if (disableCoroutine != null)
                {
                    StopCoroutine(disableCoroutine);
                    disableCoroutine = null;
                }
            }else{
                enable = true;
                target.SetActive(true);
                StartCoroutine(DisableFlashlightAfterRandomTime());
            }
        }
    }
    private IEnumerator DisableFlashlightAfterRandomTime()
    {
        float randomTime = Random.Range(30f, 60f);
        yield return new WaitForSeconds(randomTime);
        if (enable){
            enable = false;
            target.SetActive(false);
            yield return new WaitForSeconds(.2f);
            enable = true;
            target.SetActive(true);
            yield return new WaitForSeconds(.1f);
            enable = false;
            target.SetActive(false);
            GameObject.FindGameObjectWithTag("global").GetComponent<global_value>().PlayerConsciousness -= 3;
        }
    }
}
