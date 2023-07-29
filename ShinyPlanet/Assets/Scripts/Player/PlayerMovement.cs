using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            // Check if the player is grounded
            _grounded = Physics2D.OverlapCircle(_groundCheck.position, _groundCheckRadius, _groundLayer);

            // Handle player movement
            float horizontalInput = Input.GetAxis("Horizontal");
            Vector2 movement = new Vector2(horizontalInput * _moveSpeed, _rb.velocity.y);
            _rb.velocity = movement;

            // Flip the player sprite if moving left or right
            if (horizontalInput < 0)
                transform.localScale = new Vector3(-1, 1, 1);
            else if (horizontalInput > 0)
                transform.localScale = new Vector3(1, 1, 1);

            // Handle player jumping
            if (_grounded && Input.GetButtonDown("Jump"))
            {
                _rb.AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
            }
        }

        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _jumpForce = 10f;
        [SerializeField] private Transform _groundCheck;
        [SerializeField] private LayerMask _groundLayer;

        private Rigidbody2D _rb;
        private bool _grounded;
        private float _groundCheckRadius = 0.2f;
    }
}
