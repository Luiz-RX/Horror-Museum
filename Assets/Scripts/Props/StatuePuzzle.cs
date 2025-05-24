using UnityEngine;

public class StatuePuzzle : MonoBehaviour
{

    [SerializeField] private Animator animator; //Animator de la puerta que se abre
    [SerializeField] private GameObject coll; //Collider del objeto que cogemos de la estatua, el martillo.

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ActivatorPuzzle")
        {
            //animator.Play(Animacion de abrir la puerta)
            coll.SetActive(true);
        }
    }
}
