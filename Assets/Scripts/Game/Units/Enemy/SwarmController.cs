using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

namespace SpaceInvaders.Game.Units.Enemy
{
    public class SwarmController : MonoBehaviour
    {
        public float maxMovementCoordX;
        public float minMovementCoordX;

        private MovementState _state;
        private AudioSource _audioSource;

        const int movementTime = 1000;

        private async void Start()
        {
            _state = MovementState.goRight;
            _audioSource = GetComponent<AudioSource>();
            await Move();
        }

        private async UniTask Move()
        {
            while (transform.childCount != 0 && transform != null)
            {
                if (_state != MovementState.stop)
                {
                    if (CheckSwitchMovement())
                    {
                        MoveVertical();
                        await Task.Delay(movementTime);
                    }
                    MoveHorizontal();
                    await Task.Delay(movementTime);

                    ShotWithChance();
                }
                else
                    break;
            }
        }

        private void MoveHorizontal()
        {
            if (_state == MovementState.goRight)
                transform.position = new Vector2(transform.position.x + 0.5f, transform.position.y);
            else if (_state == MovementState.goLeft)
                transform.position = new Vector2(transform.position.x - 0.5f, transform.position.y);
            _audioSource.Play();
        }

        private void MoveVertical()
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
            _audioSource.Play();
        }

        private bool CheckSwitchMovement()
        {
            if (transform.position.x >= maxMovementCoordX)
            {
                _state = MovementState.goLeft;
                return true;

            }
            else if (transform.position.x <= minMovementCoordX)
            {
                _state = MovementState.goRight;
                return true;
            }
            return false;
        }

        public void ShoiceShootStarship()
        {
            var starshipIndex = Random.Range(0, transform.childCount);
            var enemyScript = transform.GetChild(starshipIndex).GetComponent<EnemyController>();
            enemyScript.Fire();
        }

        public void ShotWithChance()
        {
            if (Random.Range(0, 2) == 1)
                ShoiceShootStarship();
        }

        enum MovementState
        {
            goRight,
            goLeft,
            stop,
        }
    }
}

