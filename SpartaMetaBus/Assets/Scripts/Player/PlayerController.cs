using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpHeight = 1f;
    [SerializeField] private float jumpDuration = 0.5f;
    private bool isJumping = false;

    SpriteRenderer spriteRenderer;    
    private Vector2 startPosition;
    private Vector2 moveInput;

    private Rigidbody2D _rigidbody2D;
    public float moveSpeed = 5f;

    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        _rigidbody2D.velocity = moveInput * moveSpeed;
    }

    public void OnMove(InputValue value)
    {
        //if (isJumping) { return; }
        moveInput = value.Get<Vector2>();

        if (moveInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveInput.x > 0) { spriteRenderer.flipX = false; }        
    }

    public void OnJump(InputValue value)
    {
        if (!isJumping)
        {
            StartCoroutine(JumpRoutine());
        }
    }

    private IEnumerator JumpRoutine()
    {
        isJumping = true;
        startPosition = transform.position;

        Vector2 jumpTarget = startPosition + Vector2.up * jumpHeight;
        float downTime = 0f;

        while (downTime < jumpDuration / 2f)
        {
            transform.position = Vector2.Lerp(startPosition, jumpTarget, (downTime / (jumpDuration / 2f)));
            downTime += Time.deltaTime;
            yield return null;
        }

        downTime = 0f;
        while (downTime < jumpDuration / 2f)
        {
            transform.position = Vector2.Lerp(jumpTarget, startPosition, (downTime / (jumpDuration / 2f)));
            downTime += Time.deltaTime;
            yield return null;
        }

        transform.position = startPosition;
        isJumping = false;
    }
}
