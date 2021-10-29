using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class InputManager : MonoBehaviour
{
    [SerializeField] private GameEvent onTap;
    [SerializeField] private GameEvent onStartTouch;
    [SerializeField] private GameEvent onEndTouch;

    private TouchControls _touchControls;
    private Camera _mainCamera;

    private void Awake()
    {
        InitializeVariables();
    }

    private void InitializeVariables()
    {
        _touchControls = new TouchControls();
        _mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        _touchControls.Enable();
        
        TouchSimulation.Enable();
    }

    private void OnDisable()
    {
        _touchControls.Disable();
        
        TouchSimulation.Disable();
    }

    private void Start()
    {
        RegisterToTouchPress();
    }

    private void RegisterToTouchPress()
    {
        _touchControls.Touch.TouchTap.started += ctx => Tap();
        _touchControls.Touch.TouchContact.started += ctx => StartTouch(ctx);
        _touchControls.Touch.TouchContact.canceled += ctx => EndTouch(ctx);
    }

    private void Tap()
    {
        Debug.Log("TAP");
        onTap.Raise();
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        onStartTouch.Raise(Utils.ScreenToWorld(_mainCamera, _touchControls.Touch.TouchPosition.ReadValue<Vector2>()), (float)context.startTime);
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        onEndTouch.Raise(Utils.ScreenToWorld(_mainCamera, _touchControls.Touch.TouchPosition.ReadValue<Vector2>()), (float)context.time);
    }

    public Vector2 TouchContact()
    {
        return Utils.ScreenToWorld(_mainCamera, _touchControls.Touch.TouchPosition.ReadValue<Vector2>());
    }
}
