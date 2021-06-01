﻿using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private CharacterController cc;
    private PlayerManager Manager;
    private float moveHorizontal, moveVertical;
    private float gravConstant = -9.81f;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        Manager = GetComponent<PlayerManager>();
    }

    private void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");

        if (cc.isGrounded) cc.Move(new Vector3(moveHorizontal, 0, moveVertical) * Manager.PlayerStats.moveSpeed * Time.deltaTime);
        else cc.Move(new Vector3(moveHorizontal, gravConstant, moveVertical) * Manager.PlayerStats.moveSpeed * Time.deltaTime);


        LookAtMouse();
    }

    void LookAtMouse()
    {
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        float angle = Mathf.Atan2(positionOnScreen.y - mouseOnScreen.y, positionOnScreen.x - mouseOnScreen.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0f, -angle, 0f));
    }
}
