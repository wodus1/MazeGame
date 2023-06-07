using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Vector3 Offset;
    public Transform Player;
    public Transform Skull;
    private Transform arrowTr;
    // Start is called before the first frame update
    void Start()
    {
        arrowTr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Player.position + Offset;
        arrowTr.LookAt(Skull);
        transform.position = Vector3.Lerp(arrowTr.position, pos, Time.deltaTime * 10);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 0.3f))
        {
            if (hit.collider.CompareTag("Wall"))
            {
                transform.position = hit.point - transform.forward * 0.2f;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            transform.position = collision.contacts[0].point - transform.forward * 0.3f;
        }
    }
}
