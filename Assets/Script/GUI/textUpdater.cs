using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class textUpdater : MonoBehaviour
{
    public GameObject target;
    public TMP_Text amount;
    void Update(){
       amount.SetText(target.GetComponent<fuse>().Amount.ToString());
    }
}