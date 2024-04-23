using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 2f; //Adjust this to control the movement speed of the enemy
    public LayerMask groundLayer; //Set this in the Inspector to the layer where your platforms are placed
    public float edgeDetectionOffset = 0.05f; //Offset to adjust the position of ground detector colliders

    private Rigidbody2D rb;
    private Collider2D col;
    private BoxCollider2D[] groundDetectors; //BoxColliders to detect the edge of the platform
    private bool movingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        //Create ground detector colliders on both sides of the enemy
        groundDetectors = new BoxCollider2D[2];
        groundDetectors[0] = CreateGroundDetector(Vector2.left);
        groundDetectors[1] = CreateGroundDetector(Vector2.right);
    }

    void FixedUpdate()
    {
        //Check if we are about to fall off the edge
        if (!IsGroundAhead())
        {
            //If about to fall off, change direction
            FlipDirection();
        }

        //Move the enemy
        Vector2 movement = movingRight ? Vector2.right : Vector2.left;
        rb.velocity = movement * moveSpeed;
    }

    BoxCollider2D CreateGroundDetector(Vector2 direction)
    {
        //Create and position the ground detector collider with an offset
        BoxCollider2D detector = gameObject.AddComponent<BoxCollider2D>();
        detector.isTrigger = true;
        Vector2 detectorSize = new Vector2(0.5f, col.bounds.size.y);
        Vector2 offset = new Vector2(direction.x * (col.bounds.extents.x - edgeDetectionOffset), 0f);
        detector.size = detectorSize;
        detector.offset = offset;
        return detector;
    }

    bool IsGroundAhead()
    {
        //Check if there's ground detected by any of the ground detector colliders
        foreach (BoxCollider2D detector in groundDetectors)
        {
            Collider2D[] colliders = Physics2D.OverlapBoxAll(detector.bounds.center, detector.size, 0f, groundLayer);
            foreach (Collider2D collider in colliders)
            {
                if (collider != col)
                {
                    //If there's ground ahead, return true
                    return true;
                }
            }
        }

        //If no ground found at the check position, return false
        return false;
    }

    void FlipDirection()
    {
        //Change the direction of movement
        movingRight = !movingRight;
        //Flip the enemy sprite horizontally to match the new direction
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
}
