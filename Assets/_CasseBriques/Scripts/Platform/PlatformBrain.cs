using NaughtyAttributes;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlatformBrain : MonoBehaviour
{
    [Required("Move Input est requis")]
    [SerializeField] private InputActionReference _moveInput;

    [ValidateInput("IsInParent", "Platform Movement doit être un composant valide dans le parent de ce gameObjecty")]
    [SerializeField] private PlatformMovement _platformMovement;

    private void Reset()
    {
        _moveInput = InputActionReference.Create(GetComponent<PlayerInput>().actions["Move"]);
        _platformMovement = transform.parent.GetComponent<PlatformMovement>();
    }

    private void Start()
    {
        _moveInput.action.started += OnMoveUpdated;
        _moveInput.action.performed += OnMoveUpdated;
        _moveInput.action.canceled += OnMoveCanceled;
    }

    private void OnDestroy()
    {
        _moveInput.action.started -= OnMoveUpdated;
        _moveInput.action.performed -= OnMoveUpdated;
        _moveInput.action.canceled -= OnMoveCanceled;
    }

    private void OnMoveUpdated(InputAction.CallbackContext ctx)
    {
        float direction = ctx.ReadValue<float>();
        _platformMovement.UpdateDirection(direction);
    }

    private void OnMoveCanceled(InputAction.CallbackContext ctx)
    {
        _platformMovement.UpdateDirection(0f);
    }

    private bool IsInParent(PlatformMovement pm)
    {
        return transform.parent.GetComponent<PlatformMovement>() == pm;
    } 
}
