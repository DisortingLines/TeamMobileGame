using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float travelSpeed = 5f;
    public float jumpHeight = 3f;
    public float fallMultiplier = 2.5f;

    [Space]
    [Header("Platforms")]
    public float detectionRadius = 8f;
    [Space]
    [Header("Components")]
    public Rigidbody rb;
    public CapsuleCollider col;
    [Space]
    [Header("Progression")]
    public int coinsCollected = 0;

    [Space]
    public LayerMask groundLayers;

    public Button moveBtn;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
    }

    void FixedUpdate()
    {
        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if(Input.GetKey(KeyCode.D))
        {
            StartCoroutine(Move());
        }
    }

    public IEnumerator Move()
    {
        transform.Translate(new Vector3(0, 0, travelSpeed) * Time.deltaTime);

        yield return null;
    }

    public void Jump()
    {
        if(IsGrounded())
        {
            rb.velocity = Vector2.up * jumpHeight;
        }
    }

    [SerializeField]
    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), 0.01f, groundLayers);
    }

    public IEnumerator SpeedBoost(float timeDuration)
    {
        travelSpeed = travelSpeed * 1.5f;
        Debug.Log("Speed boost!");

        yield return new WaitForSecondsRealtime(timeDuration);

        travelSpeed = travelSpeed / 1.5f;

        Debug.Log("Speed boost end...");
    }
}
