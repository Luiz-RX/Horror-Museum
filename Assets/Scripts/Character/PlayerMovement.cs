using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 3.5f;  // Velocidad al avanzar
    public float backwardSpeed = 1.75f; // Velocidad al retroceder (más lenta)
    public float rotationSpeed = 150f; // Velocidad de rotación en grados por segundo
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Detectar entrada de movimiento (W/S)
        float moveDirection = Input.GetAxis("Vertical"); // W (1) / S (-1)

        // Determinar velocidad en función de la dirección
        float currentSpeed = (moveDirection > 0) ? forwardSpeed : backwardSpeed;

        Vector3 move = transform.forward * moveDirection * currentSpeed * Time.deltaTime;
        controller.Move(move);

        // Rotación izquierda / derecha (A/D)
        float rotation = Input.GetAxis("Horizontal"); // A (-1) / D (1)
        transform.Rotate(Vector3.up * rotation * rotationSpeed * Time.deltaTime);
    }
}
