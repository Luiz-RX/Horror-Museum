using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 3.5f;  // Velocidad al avanzar
    public float backwardSpeed = 1.75f; // Velocidad al retroceder (más lenta)
    public float rotationSpeed = 150f; // Velocidad de rotación en grados por segundo
    private CharacterController controller;
    private Animator animator;
    private PlayerShoot playerShoot;

    [SerializeField] AudioClip[] stepSounds;

    public InventoryObject inventory;
    bool canPickupItem;

    
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        //Provisional lock camera
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerShoot = GetComponent<PlayerShoot>();
    }

    void Update()
    {
        //if (canPickupItem)
        //{
        //    if (Input.GetKeyDown(KeyCode.E))
        //    {
        //        var item = other.GetComponent<Item>();
        //        if (item)
        //        {
        //            inventory.AddItem(item.item, 1);
        //            Destroy(other.gameObject);
        //        }
        //    }
        //}

        if (playerShoot != null && playerShoot.isAiming) return;
        // Detectar entrada de movimiento (W/S)
        float moveDirection = Input.GetAxis("Vertical"); // W (1) / S (-1)

        animator.SetFloat("MoveY", moveDirection);

        // Determinar velocidad en función de la dirección
        float currentSpeed = (moveDirection > 0) ? forwardSpeed : backwardSpeed;

        Vector3 move = transform.forward * moveDirection * currentSpeed * Time.deltaTime;
        controller.Move(move);

        // Rotación izquierda / derecha (A/D)
        float rotation = Input.GetAxis("Horizontal"); // A (-1) / D (1)
        transform.Rotate(Vector3.up * rotation * rotationSpeed * Time.deltaTime);
    }

    public void PlayRandomStepSound()
    {
        SoundFXManager.Instance.PlayRandomSoundFXClip(stepSounds, this.transform, 0.65f);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            var item = other.GetComponent<Item>();
            if (item)
            {
                inventory.AddItem(item.item, 1);
                Destroy(other.gameObject);
            }
        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Item")
    //    {
    //        canPickupItem = true;
    //    }

    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Item")
    //    {

    //        canPickupItem = false;
    //    }
    //}

    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}
