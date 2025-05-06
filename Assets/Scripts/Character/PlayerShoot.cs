using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject crosshairUI; // Referencia al crosshair en la UI
    public RectTransform crosshairTransform;
    public float crosshairMoveSpeed = 300f;
    //public Animator animator; // Referencia al Animator
    public GameObject bulletPrefab;
    public Transform firePoint; // Lugar desde donde dispara
    public float bulletSpeed = 20f;

    Ray ray;
    [SerializeField] LayerMask aimMask;
    [SerializeField] Transform aimPos;

    Animator anim;

    public bool isAiming { get; private set; }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, aimMask)) 
        {
            aimPos.position = hit.point;
        }
        // Activar modo de apuntado con Click Derecho (Botón Secundario)
        if (Input.GetMouseButtonDown(1)) // Click derecho
        {
            anim.SetBool("Aim", true);
            isAiming = true;
            crosshairUI.SetActive(true); // Mostrar crosshair
            //animator.SetBool("IsAiming", true); // Activar animación de apuntado
        }
        else if (Input.GetMouseButtonUp(1))
        {
            anim.SetBool("Aim", false);
            isAiming = false;
            crosshairUI.SetActive(false); // Ocultar crosshair
            //animator.SetBool("IsAiming", false); // Volver a animación normal
        }

        if (isAiming)
        {
            Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            Vector2 pos = Camera.main.ScreenToWorldPoint(aimPos.transform.position);
            //crosshairTransform.anchoredPosition += input * crosshairMoveSpeed * Time.deltaTime;
            crosshairTransform.anchoredPosition = pos;
        }
        if (!isAiming)
        {
            ray = new Ray(transform.position, transform.forward);
        }
        // Disparar con Click Izquierdo
        if (isAiming && Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Raycast desde la cámara hacia el punto del crosshair en pantalla
        //Vector3 crosshairScreenPos = crosshairTransform.position;
        //Ray ray = Camera.main.ScreenPointToRay(crosshairScreenPos);

        //Vector3 targetPoint;
        //if (Physics.Raycast(ray, out RaycastHit hit))
        //{
        //    targetPoint = hit.point;
        //}
        //else
        //{
        //    targetPoint = ray.GetPoint(100f);
        //}

        //Vector3 shootDirection = (targetPoint - firePoint.position).normalized;

        //GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(shootDirection));
        //Rigidbody rb = bullet.GetComponent<Rigidbody>();
        //rb.linearVelocity = shootDirection * bulletSpeed;
    }
}
