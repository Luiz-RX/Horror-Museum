using UnityEngine;

public class RenderLine : MonoBehaviour
{
    public GameObject objective;
    LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, this.gameObject.transform.position);
        lineRenderer.SetPosition(1, objective.transform.position);

    }
}
