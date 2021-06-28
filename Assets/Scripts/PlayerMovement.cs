using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody body;
    public float forwardForce = 2000F;
    public float sidewaysForce = 500F;

    bool onGround = true;

    bool MoveRight = false;
    bool MoveLeft = false;
    bool Jump = false;

    void Update () {
        /* 
         Check for key inputs here.
        REASON: FixedUpdate runs slower, but its better for physics so it can miss some keys.
        check keys smoothly in update, and do nice physics in fixed update based on these bools
         */
        MoveRight = Input.GetKey("d");
        MoveLeft = Input.GetKey("a");
        Jump = Input.GetKey("space");
    }
    void FixedUpdate() {
        body.AddForce(0, 0, forwardForce * Time.deltaTime);

        if (MoveRight) {
            body.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (MoveLeft) {
            body.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Jump && onGround) {
            body.AddForce(0, 500 * Time.deltaTime, 0, ForceMode.Impulse);
            onGround = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "Ground") {
            onGround = true;
        }
    }
}
