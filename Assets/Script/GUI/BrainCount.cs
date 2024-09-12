using TMPro;
using UnityEngine;

public class BrainCount : MonoBehaviour
{
    public GameObject target;
    public TMP_Text amount;
    void Update(){
        amount.SetText(target.GetComponent<global_boolean>().PlayerConsciousness.ToString());
    }
}