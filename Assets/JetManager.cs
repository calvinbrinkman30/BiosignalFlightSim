using UnityEngine;
using UnityEngine.InputSystem;

public class JetManager : MonoBehaviour
{
    public float sensitivity = 0.5f;
    private float roll;
    private float thrust;
    private InputAction pitchAction;
    private InputAction AAction;
    private InputAction DAction;
    private InputAction WAction;
    private InputAction SAction;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pitchAction = InputSystem.actions.FindAction("Pitch");
        AAction = InputSystem.actions.FindAction("A");
        DAction = InputSystem.actions.FindAction("D");
        WAction = InputSystem.actions.FindAction("W");
        SAction = InputSystem.actions.FindAction("S");
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        roll = 0.0f;
        thrust = 0.0f;
        if (AAction.IsPressed()) roll += sensitivity;
        if (DAction.IsPressed()) roll -= sensitivity;
        Vector2 pitchValue = pitchAction.ReadValue<Vector2>();
        gameObject.transform.Rotate(pitchValue[1]*sensitivity, 0f, roll);
        if (WAction.IsPressed()) thrust += 100.0f;
        if (SAction.IsPressed()) thrust -= 100.0f;
        rb.AddForce(0, 0, thrust, ForceMode.Impulse);
    }
}
