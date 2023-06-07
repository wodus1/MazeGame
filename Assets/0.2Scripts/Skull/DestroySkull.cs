using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DestroySkull : MonoBehaviour
{
    public GameObject expEffect;
    public MeshRenderer skullRenderer;
    private Transform tr;
    private int skullHp = 2;
    // Start is called before the first frame update
    void Start()
    {
        tr = tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("sword"))
        {
            skullHp --;
            if(skullHp == 0)
            {
                ExpSkull();
                StartCoroutine(SceneLoad());
            }
        }
    }
    IEnumerator SceneLoad()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("End");
    }
    void ExpSkull()
    {
        skullRenderer.enabled = false;
        GameObject exp = Instantiate(expEffect, tr.position, Quaternion.identity);
        Destroy(exp, 1.0f);
    }

}
