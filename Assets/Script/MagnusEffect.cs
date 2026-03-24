using UnityEngine;
using UnityEngine.InputSystem;

public class MagnusEffect : MonoBehaviour
{
    public float kickForce = 1.0f;
    public float spinAmount = 1.0f; 
    public float magnusStrength = 0.5f;
    private Rigidbody rb;
    private bool isShoot = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && !isShoot)
        {
            
            rb.AddForce(-1, 4f, kickForce, ForceMode.Impulse);
            
            rb.AddRelativeTorque(Vector3.up * spinAmount);
            isShoot = true;
        }
    }
    void FixedUpdate()
    {
        if (!isShoot) return;
        Vector3 velocity = rb.linearVelocity;
        Vector3 spin = rb.angularVelocity;
     
        Vector3 magnusForce = Vector3.Cross(spin, velocity);
        magnusForce *= magnusStrength;
        rb.AddForce(magnusForce);
    }
}