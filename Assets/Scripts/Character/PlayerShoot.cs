using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject crosshairUI; // Referencia al crosshair en la UI
    //public Animator animator; // Referencia al Animator
    public GameObject bulletPrefab;
    public Transform firePoint; // Lugar desde donde dispara
    public float bulletSpeed = 20f;

    private bool isAiming = false;

    void Update()
    {
        // Activar modo de apuntado con Click Derecho (Botón Secundario)
        if (Input.GetMouseButton(1)) // Click derecho
        {
            isAiming = true;
            crosshairUI.SetActive(true); // Mostrar crosshair
            //animator.SetBool("IsAiming", true); // Activar animación de apuntado
        }
        else
        {
            isAiming = false;
            crosshairUI.SetActive(false); // Ocultar crosshair
            //animator.SetBool("IsAiming", false); // Volver a animación normal
        }

        // Disparar con Click Izquierdo
        if (isAiming && Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = firePoint.forward * bulletSpeed;

        //animator.SetTrigger("Shoot"); // Activar animación de disparo
    }
}
