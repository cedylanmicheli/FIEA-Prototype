using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    private PlayerManager Manager;
    private float moveHorizontal, moveVertical;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Manager = GetComponent<PlayerManager>();
    }

    private void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        LookAtMouse();
    }


    void FixedUpdate()
    {
        rb.velocity = new Vector3(moveHorizontal * Manager.currentMoveSpeed, rb.velocity.y, moveVertical * Manager.currentMoveSpeed) * Time.deltaTime;
    }

    void LookAtMouse()
    {
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        float angle = Mathf.Atan2(positionOnScreen.y - mouseOnScreen.y, positionOnScreen.x - mouseOnScreen.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0f, -angle, 0f));
    }
}
