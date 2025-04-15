using UnityEngine;

public class CharacterMouvementController : MonoBehaviour
{
    public Joystick joystick;
    private Rigidbody rb;
    public float movespeed;
    public bool isGrounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask LayerIsGround;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, LayerIsGround);

        Vector3 move = new Vector3(joystick.Horizontal * movespeed, 0f, joystick.Vertical * movespeed);
        Vector3 newPosition = transform.position + move * Time.deltaTime;

        rb.MovePosition(new Vector3(newPosition.x, rb.position.y, newPosition.z));
    }

}
