using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBox : MonoBehaviour
{
    private int hp = 2;
    public AudioClip box;
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
        if (other.gameObject.CompareTag("sword"))
        {
            audio.PlayOneShot(box);
            hp -= 1;
            if (hp == 0)
            {

                CreateSkull.key -= 1;
                
                Invoke("destroy", 0.2f);
            }
        }
    }
    void destroy()
    {
        Destroy(gameObject);
    }
}
