using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

public class InputManager : MonoBehaviour
{
    [Header("Events to trigger:")]
    [SerializeField] private GameEvent _onTap;

    private TouchControls _touchControls;
    private SwipeDetection _swipeDetection;
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
        _swipeDetection = GetComponent<SwipeDetection>();
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
        _onTap.Raise();
    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        _swipeDetection.SwipeStart(Utils.ScreenToWorld(_mainCamera, _touchControls.Touch.TouchPosition.ReadValue<Vector2>()), 
            (float)context.startTime);
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        _swipeDetection.SwipeEnd(Utils.ScreenToWorld(_mainCamera, _touchControls.Touch.TouchPosition.ReadValue<Vector2>()), 
            (float)context.startTime);
    }

    public Vector2 TouchContact()
    {
        return Utils.ScreenToWorld(_mainCamera, _touchControls.Touch.TouchPosition.ReadValue<Vector2>());
    }
}
