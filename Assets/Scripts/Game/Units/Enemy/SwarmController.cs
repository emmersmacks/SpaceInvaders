using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class SwarmController : MonoBehaviour
{
    public float maxMovementCoordX;
    public float minMovementCoordX;

    private MovementState _state;

    const int movementTime = 1000;

    private void Start()
    {
        _state = MovementState.goRight;
        Move();
    }

    private async Task MovementStateSwitchAndGoDown()
    {
        if(transform.position.x >= maxMovementCoordX)
        {
            _state = MovementState.goLeft;
            await Task.Delay(movementTime);
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
        }
        else if(transform.position.x <= minMovementCoordX)
        {
            _state = MovementState.goRight;
            await Task.Delay(movementTime);
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
        }
    }

    private async void Move()
    {
        

        while(transform.childCount != 0 && transform != null)
        {
            await MovementStateSwitchAndGoDown();
            await Task.Delay(movementTime);

            if (_state == MovementState.goRight)
                transform.position = new Vector2(transform.position.x + 0.5f, transform.position.y);
            else if (_state == MovementState.goLeft)
                transform.position = new Vector2(transform.position.x - 0.5f, transform.position.y);
            else
                break;
            ShoiceShootStarship();

        }
    }

    public void ShoiceShootStarship()
    {
        var starshipIndex = Random.Range(0, transform.childCount);
        var enemyScript = transform.GetChild(starshipIndex).GetComponent<EnemyController>();
        enemyScript.Fire();
    }

    enum MovementState
    {
        goRight,
        goLeft,
        stop,
    }
}
