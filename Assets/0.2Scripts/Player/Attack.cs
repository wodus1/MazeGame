using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public BoxCollider atkBox;
    public AudioClip swing;
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

    void AtkSound()
    {
        audio.PlayOneShot(swing);
    }
    void EnableAttackBox()
    {
        atkBox.enabled = true;
    }
    void DisableAttackBox()
    {
        atkBox.enabled = false;
    }
}
