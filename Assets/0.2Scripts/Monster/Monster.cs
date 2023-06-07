using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public AudioClip monsterAdio;
    private AudioSource audio;
   
    public enum State
    {
        IDLE,
        PATROL,
        TRACE,
        ATTACK,
        DIE
    }

    public State state = State.IDLE;
    public float tracedist = 10.0f;
    public float attackDist = 3.0f;
    public bool isDie = false;

    private Transform monsterTr;
    private Transform playerTr;
    private NavMeshAgent nvAgent;
    private Animator anim;  

    private readonly int hashTrace = Animator.StringToHash("walk");
    private readonly int hashAttack = Animator.StringToHash("attack");
    private readonly int hashDie = Animator.StringToHash("die");

    public int HP = 3;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        monsterTr = this.GetComponent<Transform>();
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
        nvAgent = this.GetComponent<NavMeshAgent>();
        anim = this.GetComponent<Animator>();

        StartCoroutine(CheckMonsterState());
        StartCoroutine(MonsterAction());
    }

    // Update is called once per frame
    IEnumerator CheckMonsterState()
    {
        while (!isDie) 
        {
            yield return new WaitForSeconds(0.3f);

            float distance = Vector3.Distance(playerTr.position, monsterTr.position);

            if (distance <= attackDist)
            {
                state = State.ATTACK;
            }
            else if (distance > attackDist && distance <= tracedist)
            {
                state = State.TRACE;
            }
            else
            {
                state = State.IDLE;
            }
        }
        
    }
    IEnumerator MonsterAction()
    {
        while (!isDie)
        {
            yield return new WaitForSeconds(0.3f);
            switch (state)
            {
                case State.IDLE:
                    nvAgent.isStopped = true;
                    anim.SetBool(hashTrace, false);
                    break;
                case State.TRACE:
                    audio.PlayOneShot(monsterAdio);
                    nvAgent.SetDestination(playerTr.position);
                    nvAgent.isStopped = false;
                    anim.SetBool(hashTrace, true);
                    anim.SetBool(hashAttack, false);
                    break;
                case State.ATTACK:
                    anim.SetBool(hashTrace, false);
                    anim.SetBool(hashAttack, true);
                    break;
                case State.DIE:
                    break;
            }
        }   
    }
    IEnumerator MonsterDie()
    {
        yield return new WaitForSeconds(0.8f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("sword"))
        {
            HP--;
            if (HP == 0)
            {
                anim.SetBool(hashAttack, false);
                anim.SetBool(hashTrace, false);
                anim.SetBool(hashDie, true);
                CreateSkull.monster -= 1;
                StartCoroutine(MonsterDie());
            }

        }
    }

  
}
