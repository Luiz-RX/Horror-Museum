using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public bool canMove = false;
    public string roomName;
    public float attackRange = 2f;

    private Vector3 startPosition;
    private NavMeshAgent agent;
    private Transform player;
    private Animator animator;
    [SerializeField] private Color flashColor;
    [SerializeField] private float flashTime = 0.1f;
    [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;
    [SerializeField] private Material[] material;
    bool isDead;
    int hitCount = 0;

    public AudioClip[] attackSounds;
    private Coroutine _damageFlashCoroutine;

    [SerializeField] private bool playerInRoom = false;

    private void Awake()
    {
        skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        //material = skinnedMeshRenderer.materials;
        material = skinnedMeshRenderer.materials;
        //for (int i=0; i< skinnedMeshRenderer.materials.Length; i++)
        //{
        //    material[i] = skinnedMeshRenderer.materials[i];
        //}
    }

    private void Start()
    {
        startPosition = transform.position;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        EnemyManager.Instance.RegisterEnemy(this);
    }

    private void Update()
    {
        if (player == null) player = GameObject.FindGameObjectWithTag("Player").transform;

        if (!canMove || !playerInRoom)
        {
            ReturnToStart();
            animator.SetBool("IsWalking", false);
            return;
        }

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= attackRange)
        {
            
            agent.isStopped = true;
            animator.SetTrigger("Attacking");
        }
        else
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);
            animator.SetBool("IsWalking", true);
        }
    }

    private IEnumerator DamageFlash()
    {
        Debug.Log("Flash");
        SetFlashColor();

        float currentFlashAmount = 0f;
        float elapsedTime = 0f;
        while (elapsedTime < flashTime) 
        { 
            elapsedTime += Time.deltaTime;

            currentFlashAmount = Mathf.Lerp(1f, 0f, elapsedTime / flashTime);
            SetFlashAmount(currentFlashAmount);

            yield return null;
        }
    }

    public void CallDamageFlash()
    {
        _damageFlashCoroutine = StartCoroutine(DamageFlash());
    }

    private void SetFlashColor()
    {
        for (int i=0; i<material.Length; i++)
        {
            material[i].SetColor("_FlashColor", flashColor);
        }
        
    }

    private void SetFlashAmount(float amount)
    {

        for (int i = 0; i < material.Length; i++)
        {
            material[i].SetFloat("_FlashAmount", amount);
        }
       
    }

    public void RegisterHit()
    {
        if (isDead) return;

        CallDamageFlash();
        hitCount++;

        if (hitCount >= 4)
        {
           
            animator.SetBool("Die", true);
            agent.isStopped = true;
            agent.enabled = false;
            Collider col = GetComponent<Collider>();
            if (col != null) col.enabled = false;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            RegisterHit();
        }
    }

    private void ReturnToStart()
    {
        float distToStart = Vector3.Distance(transform.position, startPosition);
        if (distToStart > 0.1f)
        {
            agent.isStopped = false;
            agent.SetDestination(startPosition);
            animator.SetBool("IsWalking", true);
        }
        else
        {
            agent.isStopped = true;
            animator.SetBool("IsWalking", false);
        }
    }

    // Llamado por RoomManager o Trigger
    public void SetPlayerInRoom(bool inRoom)
    {
        playerInRoom = inRoom;
    }
    
    public void SetMove(bool t)
    {
        canMove = t;
    }

    public void playAttackSound()
    {
        SoundFXManager.Instance.PlayRandomSoundFXClip(attackSounds, this.transform, 1f);
    }
}
