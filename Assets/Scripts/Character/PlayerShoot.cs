using System.IO.MemoryMappedFiles;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Animations.Rigging;

public class PlayerShoot : MonoBehaviour
{
    public GameObject crosshairUI; // Referencia al crosshair en la UI
    public RectTransform crosshairTransform;
    public float crosshairMoveSpeed = 0.1f;
    //public Animator animator; // Referencia al Animator
    public GameObject bulletPrefab;
    public Transform firePoint; // Lugar desde donde dispara
    public float bulletSpeed = 300f;
    public Transform rayInicialPos;
    public Rig rig;

    Vector3 lookDirection;
    Vector3 rotatedDirection;

    private Vector3 rayDirection = Vector3.forward;
    
    
    
    [SerializeField] LayerMask aimMask;
    [SerializeField] Transform aimPos;
    public GameObject aimLine;

    Animator anim;

    public bool isAiming { get; private set; }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
        // Activar modo de apuntado con Click Derecho (Botón Secundario)
        if (Input.GetMouseButtonDown(1)) // Click derecho
        {
            anim.SetBool("Aim", true);
            isAiming = true;
            
            // Mostrar crosshair
            //animator.SetBool("IsAiming", true); // Activar animación de apuntado
        }
        else if (Input.GetMouseButtonUp(1))
        {
            anim.SetBool("Aim", false);
            isAiming = false;
            crosshairUI.SetActive(false); // Ocultar crosshair
            aimLine.SetActive(false);
            //animator.SetBool("IsAiming", false); // Volver a animación normal
        }

        if (isAiming)
        {
            if (rig.weight < 0.99)
            {
                rig.weight = Mathf.Lerp(rig.weight, 1.0f, 0.05f);
            } else
            {
                crosshairUI.SetActive(true);
                aimLine.SetActive(true);
            }

            float hInput = Input.GetAxis("Vertical");
            float vInput = Input.GetAxis("Horizontal");

            if(hInput != 0)
            {
                if(hInput >0)
                {
                    Quaternion rotation = Quaternion.AngleAxis(hInput * 45, Vector3.right);
                     rotatedDirection = rotation * transform.forward;
                    //lookDirection = rotatedDirection;
                    Debug.Log("Rotate right");
                } else
                {
                    Quaternion rotation = Quaternion.AngleAxis(hInput * 45, Vector3.right);
                     rotatedDirection = rotation * transform.forward;
                    //lookDirection = rotatedDirection;
                    Debug.Log("Rotate left");
                }
                
            } else if (vInput != 0)
            {
                if (vInput > 0)
                {
                    Quaternion rotation = Quaternion.AngleAxis(vInput * 30, Vector3.up);
                     rotatedDirection = rotation * transform.forward;
                    //lookDirection = rotatedDirection;
                }
                else
                {
                    Quaternion rotation = Quaternion.AngleAxis(vInput * 30, Vector3.up);
                     rotatedDirection = rotation * transform.forward;
                    //lookDirection = rotatedDirection;
                }
            }

            lookDirection = rotatedDirection;
            Ray ray = new Ray(rayInicialPos.transform.position, lookDirection);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, aimMask))
            {
                aimPos.position = hit.point;
            }

            //AimingShoot();
        }
        if (!isAiming)
        {
            Ray ray = new Ray(rayInicialPos.transform.position, transform.forward);
            //rayDirection = Vector3.forward;
            //lookDirection = new Vector3(0, 0, transform.position.z);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, aimMask))
            {
                aimPos.position = hit.point;
            }
            if (rig.weight > 0.001)
            {
                rig.weight = Mathf.Lerp(rig.weight, 0f, 0.05f);
            }
           
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

        Vector3 shootDirection = (aimPos.position - firePoint.position).normalized;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(shootDirection));
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = shootDirection * bulletSpeed;
        Destroy(bullet, 2f);
    }
    void AimingShoot()
    {
        //Vector2 pos = Camera.main.ScreenToWorldPoint(aimPos.transform.position);

        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        rayDirection += input * crosshairMoveSpeed * Time.deltaTime;
        rayDirection.Normalize();
        Ray ray = new Ray(rayInicialPos.transform.position, (rayDirection));
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, aimMask))
        {
            aimPos.position = hit.point;
        }

        //aimPos.transform.position += input * crosshairMoveSpeed * Time.deltaTime;
        //crosshairTransform.anchoredPosition = pos;
    }
}
