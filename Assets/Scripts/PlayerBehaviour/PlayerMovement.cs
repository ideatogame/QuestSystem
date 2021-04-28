using UnityEngine;

namespace PlayerBehaviour
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float playerSpeed;
        private CharacterController playerCharacterController;

        private Vector3 inputVector;
        private bool inputButton;
        
        private void Awake()
        {
            playerCharacterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            inputVector.x = Input.GetAxis("Horizontal");
            inputVector.z = Input.GetAxis("Vertical");
            inputVector = inputVector.normalized;
            
            inputButton = Input.GetButton("Horizontal") || Input.GetButton("Vertical");
        }
        
        private void FixedUpdate()
        {
            if (inputButton)
                Move();
        }

        private void Move()
        {
            Vector3 move = inputVector * playerSpeed;
            playerCharacterController.SimpleMove(move);
            
            Transform playerTransform = transform;
            playerTransform.LookAt(playerTransform.position + inputVector);
        }
    }
}