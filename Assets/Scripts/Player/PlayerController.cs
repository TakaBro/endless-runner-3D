using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInputActions inputActions;
    //private TouchControls touchControls;
    private Animator anim;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        //touchControls = new TouchControls();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        //touchControls.Enable();
    }

    private void OnDesable()
    {
        inputActions.Disable();
        //touchControls.Disable();
    }

    void Start()
    {
        inputActions.Player.Jump.started += ctx => StartJump();
        anim = this.GetComponent<Animator>();
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("isJumping", true);
        }*/
    }

    private void StartJump()
    {
        anim.SetBool("isJumping", true);
    }

    public void StopJump()
    {
        anim.SetBool("isJumping", false);
    }
}
