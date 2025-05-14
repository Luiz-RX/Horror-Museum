using UnityEngine;

public class AcivateAttackCollider : MonoBehaviour
{
    [SerializeField] private GameObject attackColl;
    public void ActivateCollider()
    {
        attackColl.SetActive(true);
    }

    public void DeactivateCollider()
    {
        attackColl.SetActive(false);
    }
}
