using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerBehavior : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float RotateSpeed = 75f;
    private float _vInput;
    private float _hInput;
    // 1
    public float JumpVelocity = 5f;
    private bool _isJumping;
    private Rigidbody _rb;
    // 1
    public float DistanceToGround = 0.1f;
    // 2 
    public LayerMask GroundLayer;
    // 3
    private CapsuleCollider _col;
    // 2

    void Start()
    {
        // 3
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
    }
    void Update()
    {
        _vInput = Input.GetAxis("Vertical") * MoveSpeed;
        _hInput = Input.GetAxis("Horizontal") * RotateSpeed;
        /*
        this.transform.Translate(Vector3.forward * _vInput * 
        Time.deltaTime);
        this.transform.Rotate(Vector3.up * _hInput * Time.deltaTime);
        */
        _isJumping |= Input.GetKeyDown(KeyCode.Space);
    }
    // 1
    void FixedUpdate()
    {
        // 2
        Vector3 rotation = Vector3.up * _hInput;
        // 3
        Quaternion angleRot = Quaternion.Euler(rotation *
            Time.fixedDeltaTime);
        // 4
        _rb.MovePosition(this.transform.position +
            this.transform.forward * _vInput * Time.fixedDeltaTime);
        // 5
        _rb.MoveRotation(_rb.rotation * angleRot);

        if (IsGrounded() && _isJumping)
        {
            _rb.AddForce(Vector3.up * JumpVelocity,
                 ForceMode.Impulse);
        }
        _isJumping = false;
    }
    private bool IsGrounded()
    {
        // 7
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x,
             _col.bounds.min.y, _col.bounds.center.z);

        // 8
        bool grounded = Physics.CheckCapsule(_col.bounds.center,
            capsuleBottom, DistanceToGround, GroundLayer,
               QueryTriggerInteraction.Ignore);

        // 9
        return grounded;
    }
}
