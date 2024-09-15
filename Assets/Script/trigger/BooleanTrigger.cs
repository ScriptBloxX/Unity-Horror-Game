using UnityEngine;

public class BooleanTrigger : MonoBehaviour{
        private bool ever_trigger;
        public GameObject target_trigger;
        public AudioSource source;
        public AudioClip clip;

        void Start(){
            ever_trigger = false;
        }
        void OnTriggerEnter(Collider other)
        {
            if(ever_trigger==false){
                ever_trigger = true;    
                GameObject.FindGameObjectWithTag("global").GetComponent<global_value>().lightOff = true;
                GameObject.FindGameObjectWithTag("global").GetComponent<global_value>().PlayerConsciousness -= 50;
                source.PlayOneShot(clip);
            }
        }
}