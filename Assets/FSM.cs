using UnityEngine;

public class FSM : MonoBehaviour
{
    public enum EnemyState
    {
        Patrol,
        Pursuit,
        Attack
    }

    public EnemyState currentState = EnemyState.Patrol;

    public void UpdateState(bool canSeePlayer, bool isInAttackRange)
    {
        switch (currentState)
        {
            case EnemyState.Patrol:

                if (canSeePlayer)
                {
                    currentState = EnemyState.Pursuit;
                    Debug.Log("Switch to Pursuit");
                }

                break;

            case EnemyState.Pursuit:

                if (!canSeePlayer)
                {
                    currentState = EnemyState.Patrol;
                    Debug.Log("El enemigo esta patrullando");
                }
                else if (isInAttackRange)
                {
                    currentState = EnemyState.Attack;
                    Debug.Log("Switch to Attack");
                }

                break;

            case EnemyState.Attack:

                if (!isInAttackRange)
                {
                    currentState = EnemyState.Pursuit;
                    Debug.Log("Back to Pursuit");
                }

                break;
        }
    }
}
