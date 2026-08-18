using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class Bounds 
{
    public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Bounds bounds;

    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private float speed = 10f;
    [SerializeField]
    private float tilt = 5f;
    [SerializeField]
    private Vector2 input;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnMove(InputValue moveValue)
    {
        input = moveValue.Get<Vector2>();
    }

    void Start()
    {
        
    }

    // FixedUpdate is called on a fixed timestep and is used for physics
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(input.x, 0f, input.y);

        // Set linear velocity based on input and speed
        rb.linearVelocity = movement * speed;

        // Set rotation (tilt) based on current lateral velocity
        rb.rotation = Quaternion.Euler(0f, 0f, rb.linearVelocity.x * -tilt);

        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, bounds.xMin, bounds.xMax),
            0f,
            Mathf.Clamp(rb.position.z, bounds.zMin, bounds.zMax)
        );

    }
}
