using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private static readonly int Idle = Animator.StringToHash("Idle");
    private static readonly int Walk = Animator.StringToHash("Walk");
    private static readonly int Attack = Animator.StringToHash("Attack");
    private static readonly int Die = Animator.StringToHash("Die");

    [SerializeField] private LayerMask m_Enemy;
    [SerializeField] private LayerMask m_Ground;

    // Component
    private Animator m_Anim;
    private NavMeshAgent m_Agent;

    // Enemy
    private Transform m_Target;

    float distancethreshole = 0f;

    public CharacterStatus characterstatus;

    public Transform target;

    void Start()
    {
        m_Anim = GetComponent<Animator>();
        m_Agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (characterstatus.isdead)
        {
            m_Anim.Play(Die);
        }

        else
        {

            // Left Click on Enemy
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, m_Enemy))
                {
                    m_Target = hit.collider.transform;
                    m_Anim.Play(Walk);
                    m_Anim.Play(Attack);
                    m_Agent.SetDestination(m_Target.position);


                }

            }

            // Right Click on Ground
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, m_Ground))
                {
                    m_Target = null;
                    m_Anim.Play(Walk);
                    //m_Anim.Play(Attack);

                    m_Agent.SetDestination(hit.point);

                }


            }

        }
    }
}