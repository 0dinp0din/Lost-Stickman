using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float rotationSpeed = 100.0f;

    public Rigidbody2D rb;
    private void Start()
    {
        
    }

    private void Update()
    {
        float translation = Input.GetAxis("Horizontal") * speed;
        float rotation = Input.GetAxis("Vertical") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        
        transform.Translate(0, 0, translation);
        transform.Translate(0, rotation, 0);

    }
}
