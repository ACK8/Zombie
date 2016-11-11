using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    public enum openType
    {
        Right,
        Left
    }

    [SerializeField]
    private float movingDistance = 0f;
    [SerializeField]
    private float movingSpeed = 0f;
    [SerializeField]
    private openType type;

    private bool isOpen = false;

    void Start()
    {

    }

    //CardKeyから呼ばれる
    public void MoveDoor()
    {
        isOpen = !isOpen;
    }

    void Update()
    {
        if (isOpen)
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }
    }

    void OpenDoor()
    {
        Vector3 currentPos = transform.position;

        switch (type)
        {
            case openType.Left:
                currentPos += new Vector3(0f, 0f, -movingSpeed);
                currentPos.z = Mathf.Clamp(currentPos.z, -movingDistance, 0);
                
                break;

            case openType.Right:
                currentPos += new Vector3(0f, 0f, movingSpeed);
                currentPos.z = Mathf.Clamp(currentPos.z, 0, movingDistance);

                break;
        }

        transform.position = currentPos;
    }

    void CloseDoor()
    {
        Vector3 currentPos = transform.position;

        switch (type)
        {
            case openType.Left:
                currentPos += new Vector3(0f, 0f, movingSpeed);
                currentPos.z = Mathf.Clamp(currentPos.z, -movingDistance, 0);

                break;

            case openType.Right:
                currentPos += new Vector3(0f, 0f, -movingSpeed);
                currentPos.z = Mathf.Clamp(currentPos.z, 0, movingDistance);

                break;
        }

        transform.position = currentPos;
    }
}
