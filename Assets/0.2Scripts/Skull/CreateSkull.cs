using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSkull : MonoBehaviour
{
    public GameObject skull;
    public GameObject arrow;
    public static int key = 5;
    public static int monster = 4;
    // Start is called before the first frame update
    void Start()
    {
        skull.SetActive(false);
        arrow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (key == 0 && monster == 0)
        {
            skull.SetActive(true);
            arrow.SetActive(true);
        }
    }

}
