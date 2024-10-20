using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTrigger : MonoBehaviour
{
    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        source.clip.LoadAudioData();
            
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + " hit me " + transform.name);
        source.Play();
    }
}
