using System;
using UnityEngine;

public class GameInput : MonoBehaviour {

    public EventHandler OnInteractAction;
    PlayerInputActions playerInputActions;

    private void Awake() {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();

        playerInputActions.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj) {
        OnInteractAction?.Invoke(this, EventArgs.Empty); // use of ?.Invoke => fire if OnInteractAction != null
    }

    public Vector2 GetMovementVectorNormalized() {
        //movement input
        Vector2 inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();

        inputVector = inputVector.normalized;
        return inputVector;
    }
}
