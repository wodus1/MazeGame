using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class Player : MonoBehaviour
{
    private bool is_skill = false;

    private float h = 0.0f;
    private float v = 0.0f;
    public float moveSpeed;
    public float rotateSpeed;
    private bool jump = false;
    private Transform tr;
    private Animator anim;
    private Rigidbody rigid;
    public CinemachineVirtualCamera[] rt;   
    public GameObject Esc;
    public GameObject Die;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 2.4f;
        rotateSpeed = 160f;
        tr = GetComponent<Transform>();
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        Vector3 moveDir = (Vector3.forward * v);

        anim.SetBool("run", v != 0);
        anim.SetBool("attack", false);
        tr.Translate(moveDir.normalized * Time.deltaTime * moveSpeed, Space.Self);
        tr.Rotate(Vector3.up * Time.deltaTime * rotateSpeed * h);

        if (Input.GetKeyDown(KeyCode.Space) && jump ==false)
        {
            rigid.AddForce(Vector3.up * 180);
            jump = true;
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            anim.SetTrigger("attack");
        }


        if (Input.GetKeyDown(KeyCode.LeftShift) && is_skill == false)
        {
            moveSpeed = 4.0f;
            is_skill = true;
            Invoke("speed_up", 4.0f);

        }
        if(is_skill == true)
        { 
               RunHpScript.PlayerStamina -= 25 * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (rt[0].Priority == 15)
            {
                rt[1].Priority = 15;
                rt[0].Priority = 10;
            }
            else if (rt[0].Priority == 10)
            {
                rt[1].Priority = 10;
                rt[0].Priority = 15;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Esc.activeSelf)
            {
                Time.timeScale = 1;
                Esc.SetActive(false);
            }
            else
            {
                Time.timeScale = 0;
                Esc.SetActive(true);
            }
        }

    }

    IEnumerator SceneLoad() 
    {
        yield return new WaitForSeconds(1.6f);
        Time.timeScale = 0;
        Esc.SetActive(true);
        Die.SetActive(true);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jump = false;
        }

        if (collision.gameObject.CompareTag("monster"))
        {
            HpScript.PlayerHP -= 10;
            if (HpScript.PlayerHP == 0)
            {
                anim.SetBool("run", false);
                anim.SetTrigger("die");
                StartCoroutine(SceneLoad());
            }
        }
    }

    void speed_up()
    {
        moveSpeed = 2.4f;
        Invoke("cooltime", 7.0f);

    }

    void cooltime()
    {
        is_skill = false;
        RunHpScript.PlayerStamina = 100;
    }


}
