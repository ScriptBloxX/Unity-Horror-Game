using UnityEngine;

public class PlaySoundTrigger : MonoBehaviour
{
        private bool ever_trigger;
        public AudioSource source;
        public AudioClip clip;

        void Start(){
            ever_trigger = false;
        }
        void OnTriggerEnter(Collider other)
        {
            if(ever_trigger==false){
                ever_trigger = true;    
                GameObject.FindGameObjectWithTag("global").GetComponent<global_value>().PlayerConsciousness -= 5;
                source.PlayOneShot(clip);
            }
        }
}