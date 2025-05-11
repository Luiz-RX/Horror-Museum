using UnityEngine;

public class MamutProp : MonoBehaviour
{
    [SerializeField] private Animation mamut;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            mamut.Play();
            this.gameObject.SetActive(false);
        }
    }
}
