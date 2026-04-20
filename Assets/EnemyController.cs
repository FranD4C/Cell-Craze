using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Transform player;

    [SerializeField]
    private Detect los;

    [SerializeField]
    private FSM fsm;

    [Header("Movement")]
    [SerializeField]
    private float speed = 3f;

    [SerializeField]
    private float rotationSpeed = 5f;

    [SerializeField]
    private float attackRange = 2f;

    void Awake()
    {
        if (los == null)
            los = GetComponent<Detect>();

        if (fsm == null)
            fsm = GetComponent<FSM>();
    }

    void Update()
    {
        bool canSeePlayer =
            los.isInRange(transform, player)
            && los.isInAngle(transform, player)
            && los.hasLineOfSight(transform, player);
        if (canSeePlayer)
            Debug.Log("El enemigo te esta viendo");

        float distance = Vector3.Distance(player.position, transform.position);
        bool isInAttackRange = distance < attackRange;


        fsm.UpdateState(canSeePlayer, isInAttackRange);

        ExecuteState();

    }

    void ExecuteState()
    {
        switch (fsm.currentState)
        {
            case FSM.EnemyState.Patrol:
                Patrol();
                break;

            case FSM.EnemyState.Pursuit:
                PursuePlayer();
                break;

            case FSM.EnemyState.Attack:
                Attack(); 
                break;
        }
    }

    void Patrol()
    {
        transform.Rotate(Vector3.up * 30f * Time.deltaTime);
    }

    void PursuePlayer()
    {
        Vector3 dir = player.position - transform.position;
        dir.y = 0;

        Vector3 moveDir = dir.normalized;

        transform.position += moveDir * speed * Time.deltaTime;

        transform.forward = Vector3.Lerp(
            transform.forward,
            moveDir,
            Time.deltaTime * rotationSpeed
        );
    }

    void Attack()
    {
        Debug.Log("El enemigo te esta atacando");

        // Opcional: mirar al jugador
        Vector3 dir = player.position - transform.position;
        dir.y = 0;

        transform.forward = Vector3.Lerp(
            transform.forward,
            dir.normalized,
            Time.deltaTime * rotationSpeed
        );
    }
}