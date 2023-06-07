using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsteHItAdio : MonoBehaviour
{
    public AudioClip damage;
    private AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("monster"))
        {
            audio.PlayOneShot(damage);
        }
    }
}
