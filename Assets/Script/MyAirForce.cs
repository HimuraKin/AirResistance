using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MyAirForce : MonoBehaviour
{
    private Rigidbody rb;
    public float enginePower = 50f;
    public float liftBooster = 0.5f ;
    public float dragDamp = 0.03f;
    public float angulDragDamp = 0.03f;

    public float yawPower = 50;
    public float pitchPower = 50;
    public float rollPower = 30;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(transform.forward * enginePower);

        }
        Vector3 lift = Vector3.Project(rb.linearVelocity, transform.forward);
        rb.AddForce(transform.up * lift.magnitude * liftBooster);

        rb.linearVelocity -= rb.linearVelocity * dragDamp;
        rb.angularVelocity -= rb.angularVelocity * angulDragDamp;

        float yaw = Input.GetAxis("Horizontal") * yawPower;
        rb.AddTorque(transform.up * yaw);

        float pitch = Input.GetAxis("Vertical") * pitchPower;
        rb.AddTorque(-transform.right * pitch);

        float roll = Input.GetAxis("Roll") * rollPower;
        rb.AddForce(-transform.forward * roll);
    }
}
