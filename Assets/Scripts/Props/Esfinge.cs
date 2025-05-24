using UnityEngine;

public class Esfinge : MonoBehaviour
{
    Animation animation;

    private void Start()
    {
        animation = GetComponentInParent<Animation>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(other.GetComponent<Inventarioimprovisado>().pataEsfinge == true && Input.GetKeyDown(KeyCode.E))
            {
                if (animation != null) animation.Play();
                else Debug.Log("no hay animacion de esfinge");

            }
        }
    }
}
