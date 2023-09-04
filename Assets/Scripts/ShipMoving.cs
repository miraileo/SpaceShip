using UnityEngine;

public class ShipMoving : MonoBehaviour
{
    private Rigidbody2D rigidbody2;
    private FixedJoystick joystick;
    [SerializeField] float speed;

    private Touch touch;
    
    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();   
        joystick = FindObjectOfType<FixedJoystick>();
    }
    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if(touch.phase== TouchPhase.Moved)
            {
                rigidbody2.velocity = new Vector2(-speed * touch.deltaPosition.x, -speed * touch.deltaPosition.y);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                rigidbody2.velocity = Vector2.zero;
            }
        }
    }
}
