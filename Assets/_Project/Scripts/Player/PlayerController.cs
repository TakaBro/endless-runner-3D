using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform _pointToMove;
    [SerializeField] private Vector3 _offsetFromPointToMove;

    [Header("Events to register:")] // As listener
    [SerializeField] private GameEvent _OnTap;
    [SerializeField] private GameEvent _OnSwipeLeft;
    [SerializeField] private GameEvent _OnSwipeRight;

    [Header("Events to trigger:")]
    [SerializeField] private GameEvent _OnPlayerEnterPlatform;
    [SerializeField] private GameEventIntParameter _OnPlayerExitPlatform;

    private Animator _anim;
    private bool _isPlayerOnRight = false;
    private bool _isPlayerOnLeft = false;
    private bool _isPlayerInMiddle = true;

    private void OnEnable()
    {
        RegisterAsListener();
    }

    private void RegisterAsListener()
    {
        _OnTap.RegisterListener(StartJump);
        _OnSwipeLeft.RegisterListener(MoveLeft);
        _OnSwipeRight.RegisterListener(MoveRight);
    }

    private void OnDisable()
    {
        UnregisterAsListener();
    }

    private void UnregisterAsListener()
    {
        _OnTap.UnregisterListener(StartJump);
        _OnSwipeLeft.UnregisterListener(MoveLeft);
        _OnSwipeRight.UnregisterListener(MoveRight);
    }

    private void Start()
    {
        _anim = this.GetComponent<Animator>();
    }

    private void Update()
    {
        // Comment debug controls
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }

        FollowMovePoint();
    }

    private void FollowMovePoint()
    {
        transform.position = Vector3.Lerp(transform.position, _pointToMove.position + _offsetFromPointToMove,
            Constants.PLAYER_MOVEMENT_SPEED * Time.deltaTime);
    }

    private void StartJump()
    {
        _pointToMove.position = new Vector3(_pointToMove.position.x,
            _pointToMove.position.y + Constants.PLAYER_JUMP_HEIGHT, 0);
        _anim.SetBool(AnimatorParameter.Is_JUMPING, true);
    }

    public void StopJump()
    {
        _anim.SetBool(AnimatorParameter.Is_JUMPING, false);
    }

    private void MoveLeft()
    {
        if (_isPlayerInMiddle)
        {
            _pointToMove.position = new Vector3(_pointToMove.position.x - Constants.PLAYER_MOVEMENT_DISTANCE,
                _pointToMove.position.y, 0);

            _isPlayerOnLeft = true;
            _isPlayerInMiddle = false;
        }
        else if (_isPlayerOnRight)
        {
            _pointToMove.position = new Vector3(_pointToMove.position.x - Constants.PLAYER_MOVEMENT_DISTANCE,
                _pointToMove.position.y, 0);

            _isPlayerInMiddle = true;
            _isPlayerOnRight = false;
        }
    }

    private void MoveRight()
    {
        if (_isPlayerInMiddle)
        {
            _pointToMove.position = new Vector3(_pointToMove.position.x + Constants.PLAYER_MOVEMENT_DISTANCE,
                _pointToMove.position.y, 0);

            _isPlayerOnRight = true;
            _isPlayerInMiddle = false;
        }
        else if (_isPlayerOnLeft)
        {
            _pointToMove.position = new Vector3(_pointToMove.position.x + Constants.PLAYER_MOVEMENT_DISTANCE,
                _pointToMove.position.y, 0);

            _isPlayerInMiddle = true;
            _isPlayerOnLeft = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out PlatformController platform))
        {
            _OnPlayerEnterPlatform.Raise();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _OnPlayerExitPlatform.Raise(other.gameObject.GetInstanceID());
    }
}
