using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public GameManager gameManager;
    public RhythmManager rhythmManager;
    public float hitWindow = 0.15f;

    private Animator animator;
    private PlayerControls controls;

    private void Awake()
    {
        controls = new PlayerControls();
        animator = GetComponent<Animator>();

        controls.Gameplay.Left.performed += ctx => animator.SetTrigger("Left");
        controls.Gameplay.Right.performed += ctx => animator.SetTrigger("Right");
        controls.Gameplay.Up.performed += ctx => animator.SetTrigger("Up");
        controls.Gameplay.Down.performed += ctx => animator.SetTrigger("Down");
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
        void Update()
    {
        if (Keyboard.current.aKey.wasPressedThisFrame)
            gameManager.PlayerInput("Left");

        if (Keyboard.current.dKey.wasPressedThisFrame)
            gameManager.PlayerInput("Right");

        if (Keyboard.current.wKey.wasPressedThisFrame)
            gameManager.PlayerInput("Up");

        if (Keyboard.current.sKey.wasPressedThisFrame)
            gameManager.PlayerInput("Down");
    }
}