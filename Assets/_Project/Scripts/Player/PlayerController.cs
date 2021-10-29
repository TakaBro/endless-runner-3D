using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform _pointToMove;
    // As listener
    [Header("Event to register:")]
    [SerializeField] private GameEvent _OnTap;
    [SerializeField] private GameEvent _OnSwipeLeft;
    [SerializeField] private GameEvent _OnSwipeRight;
    // As invoker
    [Header("Event to response:")]
    [SerializeField] private GameEvent _onPlayerEnterPlatform;
    [SerializeField] private GameEvent _onPlayerExitPlatform;
    [SerializeField] private Vector3 _offsetFromPointToMove;

    private List<GameEvent> events = new List<GameEvent>();
    public List<GameEventListener> eventListeners = new List<GameEventListener>();

    private Animator _anim;
    private bool _onRight = false;
    private bool _onLeft = false;
    private bool _inMiddle = true;

    private void OnEnable()
    {
        AddEventToListen(_OnTap);
        AddEventToListen(_OnSwipeLeft);
        AddEventToListen(_OnSwipeRight);
        RegisterAsListenerToEvents();
    }

    private void AddEventToListen(GameEvent gameEvent)
    {
        events.Add(gameEvent);
        eventListeners.Add(new GameEventListener());
    }

    private void RegisterAsListenerToEvents()
    {
        for (int i = 0; i < events.Count ; i++)
        {
            events[i].RegisterListener(eventListeners[i]);
        }
    }

    private void OnDisable()
    {
        UnregisterAsListenerToEvents();
    }

    private void UnregisterAsListenerToEvents()
    {
        for (int i = 0; i < events.Count; i++)
        {
            events[i].UnregisterListener(eventListeners[i]);
        }
    }

    private void Start()
    {
        _anim = this.GetComponent<Animator>();
    }

    private void Update()
    {
        // TODO: Comment debug controls
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

    public void MoveLeft()
    {
        if (_inMiddle)
        {
            _pointToMove.position = new Vector3(_pointToMove.position.x - Constants.PLAYER_MOVEMENT_DISTANCE,
                _pointToMove.position.y, 0);

            _onLeft = true;
            _inMiddle = false;
        }
        else if (_onRight)
        {
            _pointToMove.position = new Vector3(_pointToMove.position.x - Constants.PLAYER_MOVEMENT_DISTANCE,
                _pointToMove.position.y, 0);

            _inMiddle = true;
            _onRight = false;
        }
    }

    public void MoveRight()
    {
        if (_inMiddle)
        {
            _pointToMove.position = new Vector3(_pointToMove.position.x + Constants.PLAYER_MOVEMENT_DISTANCE,
                _pointToMove.position.y, 0);

            _onRight = true;
            _inMiddle = false;
        }
        else if (_onLeft)
        {
            _pointToMove.position = new Vector3(_pointToMove.position.x + Constants.PLAYER_MOVEMENT_DISTANCE,
                _pointToMove.position.y, 0);

            _inMiddle = true;
            _onLeft = false;
        }
    }

    public void StartJump()
    {
        _pointToMove.position = new Vector3(_pointToMove.position.x, 
            _pointToMove.position.y + Constants.PLAYER_JUMP_HEIGHT, 0);
        _anim.SetBool(AnimatorParameter.Is_JUMPING, true);
    }

    public void StopJump()
    {
        _anim.SetBool(AnimatorParameter.Is_JUMPING, false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Platform platform))
        {
            Debug.Log("out Platform platform");
            _onPlayerEnterPlatform.Raise();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _onPlayerExitPlatform.Raise(other.gameObject.GetInstanceID());
    }
}
