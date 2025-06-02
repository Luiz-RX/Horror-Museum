using System.Collections;
using UnityEngine;

public class RotateStatue : MonoBehaviour
{
    public bool canRotate;
    float rotateAmmount = 60f;

    private Vector3 currentAngle;
    private Vector3 targetAngle;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentAngle = transform.eulerAngles;
        targetAngle = currentAngle;
    }

    // Update is called once per frame
    void Update()
    {
        currentAngle = new Vector3(
            currentAngle.x, 
            currentAngle.y,
            Mathf.LerpAngle(currentAngle.z, targetAngle.z, Time.deltaTime * 2.5f)
            );

        this.transform.eulerAngles = currentAngle;

        if(Input.GetKeyDown(KeyCode.E)) {
            Rotate();
        }
    }

    public void Rotate()
    {
        if (canRotate)
        {
            canRotate = false;
            targetAngle = currentAngle + new Vector3 (0, 0, 60f);
            StartCoroutine(RotateCooldown());
        }
    }

    IEnumerator RotateCooldown()
    {
        yield return new WaitForSeconds(2.5f);
        canRotate = true;
    }
}
