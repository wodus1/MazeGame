using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
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
        arrowTr.LookAt(Skull);
    }

}
