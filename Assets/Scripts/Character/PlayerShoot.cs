using JetBrains.Annotations;
using System.IO.MemoryMappedFiles;
using System.Runtime.CompilerServices;
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
    [SerializeField] float rotateSpeed = 15f;
    public Rig rig;
    private PlayerAmmo ammo;
    bool canShoot;
    [SerializeField] float timeBetweenShots = 0.25f;
    float timeUntilNextShot;
    bool isReloading;

    [SerializeField] AudioClip shotShound;
    [SerializeField] AudioClip shotLowAmmoSound;
    [SerializeField] AudioClip shotNoAmmoSound;

    bool hasAimedFirstTime;
    bool hasUnaimedFirstTime;
    bool hasOpenedInventoryFirstTime;

    public GameObject aimTutorialUI;
    public GameObject inventoryTutorialUI;
    public GameObject WASDAimTutorialUI;
    

    [SerializeField] GameObject glockHip;
    [SerializeField] GameObject glockhand;

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
        ammo = GetComponent<PlayerAmmo>();
    }

    void Update()
    {
        
        // Activar modo de apuntado con Click Derecho (Botón Secundario)
        if (Input.GetMouseButtonDown(1)) // Click derecho
        {
            glockhand.SetActive(true);
            glockHip.SetActive(false); 
            anim.SetBool("Aim", true);
            isAiming = true;

            if(!hasAimedFirstTime)
            {
                aimTutorialUI.SetActive(false);
                hasAimedFirstTime = true;
                if (WASDAimTutorialUI != null)
                {
                    WASDAimTutorialUI.SetActive(true);
                }
            }
            
            // Mostrar crosshair
            //animator.SetBool("IsAiming", true); // Activar animación de apuntado
        }



        if (Input.GetKeyDown(KeyCode.I) && !hasOpenedInventoryFirstTime)
        {
            if(!hasOpenedInventoryFirstTime)
            {
                inventoryTutorialUI.SetActive(false);
                hasOpenedInventoryFirstTime = true;
            }
        }

        else if (Input.GetMouseButtonUp(1))
        {
            if (isReloading)
            {
                anim.SetTrigger("StopReload");
            }
            glockhand.SetActive(false);
            glockHip.SetActive(true);
            anim.SetBool("Aim", false);
            isAiming = false;
            crosshairUI.SetActive(false); // Ocultar crosshair
            aimLine.SetActive(false);
            //animator.SetBool("IsAiming", false); // Volver a animación normal
        }

        if (isAiming)
        {
            if (Input.GetKeyDown(KeyCode.R) && !isReloading && ammo.ammo < 12 && ammo.extraAmmo != 0)
            {
                rig.weight = 0f;
                isReloading = true;
                anim.SetTrigger("Reload");
                HideAimingUI();

            }
            if (rig.weight < 0.99 && !isReloading)
            {
                rig.weight = Mathf.Lerp(rig.weight, 1.0f, 0.05f);
            } else
            {
                if(!isReloading)
                {
                    crosshairUI.SetActive(true);
                    aimLine.SetActive(true);
                }
                
            }


            float hInput = Input.GetAxis("Horizontal");
            float vInput = Input.GetAxis("Vertical");

           

            rayInicialPos.transform.Rotate(0, hInput * rotateSpeed * Time.deltaTime, 0);
            rayInicialPos.transform.Rotate(-vInput * rotateSpeed * Time.deltaTime, 0, 0);

            

            
            Ray ray = new Ray(rayInicialPos.transform.position, rayInicialPos.transform.forward);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, aimMask))
            {
                aimPos.position = hit.point;
            }

            //AimingShoot();
        }
        if (!isAiming)
        {
            rayInicialPos.transform.rotation = this.transform.rotation;
            

            Ray ray = new Ray(rayInicialPos.transform.position, rayInicialPos.transform.forward);
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
        if (isAiming && Input.GetMouseButtonDown(0) && ammo.ammo > 0 && timeUntilNextShot < Time.time)
        {
            Shoot();
            timeUntilNextShot = Time.time + timeBetweenShots;
            if(ammo.ammo > 5)
            {
                //Normal Sound
                SoundFXManager.Instance.PlaySoundFXClip(shotShound, firePoint.transform, 1f);
            } else
            {
                //Low bullets sound
                SoundFXManager.Instance.PlaySoundFXClip(shotLowAmmoSound, firePoint.transform, 1f);
            }
        }

        if (isAiming && Input.GetMouseButtonDown(0) && ammo.ammo == 0 && timeUntilNextShot < Time.time)
        {
            //Click sound
            SoundFXManager.Instance.PlaySoundFXClip(shotNoAmmoSound, firePoint.transform, 1f);
            timeUntilNextShot = Time.time + timeBetweenShots;
        }
    }

    void Shoot()
    {
        

        Vector3 shootDirection = (aimPos.position - firePoint.position).normalized;

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(shootDirection));
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = shootDirection * bulletSpeed;
        ammo.TakeAmmo();
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

    public void FinishedReload()
    {
        isReloading = false;
    }

    void HideAimingUI()
    {
        crosshairUI.SetActive(false);
        aimLine.SetActive(false);
    }

    void ShowAimingUI()
    {

    }
}
