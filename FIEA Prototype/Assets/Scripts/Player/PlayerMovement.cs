using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;
    private CharacterController cc;

    private PlayerManager Manager;
    private float moveHorizontal, moveVertical;

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
        Manager = GetComponent<PlayerManager>();
    }

    private void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        if (cc.isGrounded) cc.Move(new Vector3(moveHorizontal, 0, moveVertical) * Manager.PlayerStats.moveSpeed * Time.deltaTime);
        else cc.Move(new Vector3(moveHorizontal, -9.81f, moveVertical) * Manager.PlayerStats.moveSpeed * Time.deltaTime);


        LookAtMouse();
    }


    void FixedUpdate()
    {
        //rb.velocity = new Vector3(moveHorizontal * Manager.PlayerStats.moveSpeed, rb.velocity.y, moveVertical * Manager.PlayerStats.moveSpeed) * Time.deltaTime;
    }

    void LookAtMouse()
    {
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        float angle = Mathf.Atan2(positionOnScreen.y - mouseOnScreen.y, positionOnScreen.x - mouseOnScreen.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0f, -angle, 0f));
    }
}
