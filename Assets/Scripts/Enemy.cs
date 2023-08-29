using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private static readonly int Idle = Animator.StringToHash("Idle");
    private static readonly int Walk = Animator.StringToHash("Walk");
    private static readonly int Attack = Animator.StringToHash("Attack");
    private static readonly int Die = Animator.StringToHash("Die");

    // Component
    private Animator m_Anim;
    private NavMeshAgent m_Agent;

    public CharacterStatus status;

    // Enemy
    private Transform m_Target;


    public Transform playerTransform;
    public Transform standingPoint;


    public float returnDistance = 10f;
    private bool isAttacking = false;



    void Start()
    {
        m_Anim = GetComponent<Animator>();
        m_Agent = GetComponent<NavMeshAgent>();

        m_Agent.speed = status.speed;
    }

    private void Update()
    {

        if (status.isdead)
        {
            m_Anim.Play(Die);
        }

        else
        {

            float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

            if (isAttacking)
            {
                if (distanceToPlayer > status.range)
                {
                    isAttacking = false;
                    m_Anim.Play(Attack);
                    m_Anim.Play(Walk);
                    m_Agent.isStopped = false;
                    m_Agent.SetDestination(playerTransform.position);
                }
            }
            else
            {
                if (Vector3.Distance(transform.position, standingPoint.position) > returnDistance)
                {
                    m_Agent.isStopped = false;
                    m_Agent.SetDestination(standingPoint.position);
                    m_Anim.Play(Walk);
                }
                else
                {
                    m_Agent.isStopped = true;
                    m_Anim.Play(Idle);
                }

                if (distanceToPlayer <= status.range)
                {
                    isAttacking = true;
                    m_Anim.Play(Attack);
                    this.transform.LookAt(playerTransform);
                    m_Agent.isStopped = true;
                }
            }
        }
    }
}