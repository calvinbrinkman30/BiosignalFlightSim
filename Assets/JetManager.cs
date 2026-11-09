using UnityEngine;
using UnityEngine.InputSystem;

public class JetManager : MonoBehaviour
{
    private InputAction pitchAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pitchAction = InputSystem.actions.FindAction("Pitch");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pitchValue = pitchAction.ReadValue<Vector2>();
        Debug.Log(pitchValue[1]);
    }
}
