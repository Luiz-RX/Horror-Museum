using UnityEngine;

public class StatuePuzzle : MonoBehaviour
{

    [SerializeField] private Animator animator; //Animator de la puerta que se abre
    [SerializeField] private GameObject coll;
    RotateStatue rotateStatue;

    private void Start()
    {
        rotateStatue = FindAnyObjectByType<RotateStatue>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ActivatorPuzzle")
        {
            animator.SetTrigger("Open");
            coll.SetActive(true);
            rotateStatue.hasActivated = true;
        }
    }
}
