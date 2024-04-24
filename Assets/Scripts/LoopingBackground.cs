using UnityEngine;

public class LoopingBackground : MonoBehaviour
{
    private Bounds spriteBounds;
    private SpriteRenderer backgroundRenderer;
    private float backgroundWidth;
    private float leftBoundary;

    //The x-coordinate value to which the background will re-position itself
    public float repositionX = 46f;

    void Start()
    {

        //Get the SpriteRenderer component attached to the background GameObject
        backgroundRenderer = GetComponent<SpriteRenderer>();

        leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.5f, 0)).x;


    }

    void Update()
    {
        //Calculate the viewport position of the background's right edge
        UpdateLeftBoundary();
        
        //Calculate the width of the background sprite
        spriteBounds = backgroundRenderer.bounds;

        //Calculate the x-position of the right border of the sprite
        float rightBorderX = spriteBounds.max.x;

        //If the background's right edge is outside the camera's viewport (viewport x coordinate is greater than 1)
        if (rightBorderX <= leftBoundary)
        {
            //Calculate the new position of the background by subtracting the repositionX value
            Vector3 newPosition = transform.position + new Vector3(repositionX, 0f, 0f);

            //Set the new position of the background
            transform.position = newPosition;
        }
    }

    void UpdateLeftBoundary()
    {
        //Convert the left edge of the camera's viewport to world space
        Vector3 leftViewportEdge = Camera.main.ViewportToWorldPoint(new Vector3(0, 0.5f, 0));
        leftBoundary = leftViewportEdge.x - 0.5f;
    }

}
