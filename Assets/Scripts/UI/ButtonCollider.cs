using UnityEngine;

public class ButtonCollider : MonoBehaviour
{
    Keypad kp;
    [SerializeField] int num;
    [SerializeField] bool clear;
    [SerializeField] bool enter;

    private void Start()
    {
        kp = GetComponentInParent<Keypad>();
    }

    private void OnMouseUpAsButton()
    {
        if (enter)
        {
            kp.Execute();
        } else if (clear)
        {
            kp.Clear();
        } else
        {
            kp.setNum(num);
        }
       
    }
}
