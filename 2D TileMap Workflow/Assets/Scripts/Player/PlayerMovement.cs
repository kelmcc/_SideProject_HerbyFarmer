using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;

    Vector3 movement;
    Rigidbody2D playerRigidbody;
    int floorMask;

    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");

        playerRigidbody = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        if (h != 0 || v != 0)
        {
            Move(h, v);
        }
    }

    void Move(float h, float v)
    {
        Turning(h,v);

        movement.Set(h, v, 0f);

        movement = movement.normalized * speed * Time.deltaTime;

        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turning(float h, float v)
    {
        Vector2 pointer = new Vector2(h, v);
        float angleBetween = Vector2.SignedAngle(new Vector2(0,1), pointer);

       // Debug.Log("angleBetween" + angleBetween);
        playerRigidbody.rotation = angleBetween;
    }
}
