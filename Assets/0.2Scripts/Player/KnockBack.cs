using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    Rigidbody rigid;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("monster"))
        {
            anim.SetBool("run", false);
            Vector3 direction = transform.position - collision.gameObject.transform.position;

            rigid.velocity = Vector3.zero;
            rigid.AddForce(direction * 300);
            rigid.velocity = Vector3.zero;
        }
    }
}
