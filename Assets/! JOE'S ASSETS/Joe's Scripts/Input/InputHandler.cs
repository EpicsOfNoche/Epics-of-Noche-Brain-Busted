using UnityEngine;
using UnityEngine.InputSystem;

[DisallowMultipleComponent, RequireComponent(typeof(PlayerInput))]
public class InputHandler : MonoBehaviour
{
    public static InputHandler Instance { get; private set; }

    [SerializeField] private PlayerInput playerInput;

    public bool InteractPressed { get; private set; }
    public bool CancelPressed { get; private set; }

    private void Awake() => Instance = this;
    private void Update()
    {
        if (playerInput == null)
        {
            Debug.LogWarning("InputActionAsset is not assigned in InputHandler.");
            return;
        }

        InteractPressed = playerInput.actions.FindAction("Dialogue_Interact").WasPressedThisFrame();
        CancelPressed = playerInput.actions.FindAction("Dialogue_Cancel").WasPressedThisFrame();
    }
}