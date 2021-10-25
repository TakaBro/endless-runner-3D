using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static GameObject player;

    [SerializeField] private Transform pointToMove;
    [SerializeField] private GameEvent onPlayenEnterPlatform;
    [SerializeField] private GameEvent onPlayenExitPlatform;
    [SerializeField] Vector3 offsetFromPointToMove;
    private Animator anim;
    private bool isAlive = true;

    private void Awake()
    {
        Singleton();
    }

    private void Singleton()
    {
        if (player == null)
        {
            player = this.gameObject;
        }
    }

    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    void Update()
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

        transform.position = Vector3.Lerp(transform.position, pointToMove.position + offsetFromPointToMove, 
            Constants.PLAYER_MOVEMENT_SPEED * Time.deltaTime);
    }

    public void MoveLeft()
    {
        pointToMove.position = new Vector3(pointToMove.position.x - Constants.PLAYER_MOVEMENT_DISTANCE,
                pointToMove.position.y, 0);
    }

    public void MoveRight()
    {
        pointToMove.position = new Vector3(pointToMove.position.x + Constants.PLAYER_MOVEMENT_DISTANCE,
                pointToMove.position.y, 0);
    }

    public void StartJump()
    {
        pointToMove.position = new Vector3(pointToMove.position.x, 
            pointToMove.position.y + Constants.PLAYER_JUMP_HEIGHT, 0);
        anim.SetBool(AnimatorParameter.Is_JUMPING, true);
    }

    public void StopJump()
    {
        anim.SetBool(AnimatorParameter.Is_JUMPING, false);
    }

    private void OnTriggerEnter(Collider other)
    {
        isAlive = true;
        onPlayenEnterPlatform.Raise();
        //Debug.Log("TriggerENTER: instanceID " + other.gameObject.GetInstanceID());
    }

    private void OnTriggerExit(Collider other)
    {
        onPlayenExitPlatform.Raise(other.gameObject.GetInstanceID());
        //Debug.Log("TriggerEXIT: instanceID " + other.gameObject.GetInstanceID());
    }
}
