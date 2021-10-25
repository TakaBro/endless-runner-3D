using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameEvent onTap;
    [SerializeField] private GameEvent onStartTouch;
    [SerializeField] private GameEvent onEndTouch;

    private TouchControls touchControls;
    private Camera mainCamera;

    private void Awake()
    {
        InitializeVariables();
    }

    private void InitializeVariables()
    {
        touchControls = new TouchControls();
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        touchControls.Enable();
        
        TouchSimulation.Enable();
    }

    private void OnDisable()
    {
        touchControls.Disable();
        
        TouchSimulation.Disable();
    }

    private void Start()
    {
        RegisterToTouchPress();
    }

    private void RegisterToTouchPress()
    {
        touchControls.Touch.TouchTap.started += ctx => Tap();
        touchControls.Touch.TouchContact.started += ctx => StartTouch(ctx);
        touchControls.Touch.TouchContact.canceled += ctx => EndTouch(ctx);
    }

    private void Tap()
    {
        Debug.Log("TAP");
        onTap.Raise();
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        onStartTouch.Raise(Utils.ScreenToWorld(mainCamera, touchControls.Touch.TouchPosition.ReadValue<Vector2>()), (float)context.startTime);
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        onEndTouch.Raise(Utils.ScreenToWorld(mainCamera, touchControls.Touch.TouchPosition.ReadValue<Vector2>()), (float)context.time);
    }

    public Vector2 TouchContact()
    {
        return Utils.ScreenToWorld(mainCamera, touchControls.Touch.TouchPosition.ReadValue<Vector2>());
    }
}
