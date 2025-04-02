using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    public Transform target; 
    public float distance = 5.0f;  // Distancia de la cámara al jugador
    public float rotationSpeed = 200.0f;  // Sensibilidad del giro
    public float yDistance = 4f;

    private float currentYaw = 0.0f; // Ángulo horizontal

    void Update()
    {
       
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;

      
        currentYaw += mouseX;

        Vector3 offset = new Vector3(0f, yDistance, -distance); 
        Quaternion rotation = Quaternion.Euler(0, currentYaw, 0); 
        transform.position = target.position + rotation * offset;

        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}
