using UnityEngine;
using System.Collections;

public class CameraFade : MonoBehaviour
{
    public Transform playerTransform;

    private bool isArea = true;
    private string currentArea;
    private LineRenderer line;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.SetVertexCount(2);
    }

    void Update()
    {
        if (!isArea)
        {
            line.SetPosition(0, playerTransform.position);

            Vector3 pos = new Vector3(transform.position.x, playerTransform.position.y, transform.position.z);
            line.SetPosition(1, pos);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("OnTriggerEnter");

        if (collider.transform.tag == "Wall")
        {
            Debug.Log(collider.transform.tag);

            line.enabled = true;
            isArea = false;
        }

        if (collider.transform.tag == "Return")
        {
            Debug.Log(collider.transform.tag);

            line.enabled = false;
            isArea = true;
        }
    }
}