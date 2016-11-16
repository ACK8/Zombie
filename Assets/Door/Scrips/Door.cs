using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    [SerializeField]
    private GameObject checkObstacleObj;
    [SerializeField]
    private float movingSpeed = 0f;
    [SerializeField]
    private bool isRotate90D = false;   //ドアが90度回転しているか

    private Vector3 initalPos;
    private float movingDistance = 1f;
    private bool isOpen = false;    //現在ドアが開いているか
    private bool isCloseing = false;    //ドアが閉じているときtrue
    private bool isNotClose = false;    //ドアが閉まらないときにtrue

    void Start()
    {
        initalPos = this.transform.position;

        GameObject check = Instantiate(checkObstacleObj) as GameObject;
        check.transform.position = this.transform.position;
        check.transform.rotation = this.transform.rotation;
        check.GetComponent<BoxCollider>().size = transform.localScale;
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

        if (isNotClose)
        {
            Reopen();
        }

        print("isCloseing: " + isCloseing);
    }

    void OpenDoor()
    {
        Vector3 currentPos = transform.position;

        if (isRotate90D)
        {
            //90度回転しているときX座標を移動
            currentPos += new Vector3(-movingSpeed * Time.deltaTime, 0f, 0f);
            currentPos.x = Mathf.Clamp(currentPos.x, initalPos.x + -movingDistance, initalPos.x);
        }
        else
        {
            //0°のときはZ座標を移動
            currentPos += new Vector3(0f, 0f, -movingSpeed * Time.deltaTime);
            currentPos.z = Mathf.Clamp(currentPos.z, initalPos.z + -movingDistance, initalPos.z);
        }

        transform.position = currentPos;
    }

    void CloseDoor()
    {
        Vector3 currentPos = transform.position;

        if (isRotate90D)
        {
            //90度回転しているときX座標を移動
            currentPos += new Vector3(movingSpeed * Time.deltaTime, 0f);
            currentPos.x = Mathf.Clamp(currentPos.x, initalPos.x + -movingDistance, initalPos.x);
        }
        else
        {
            //0°のときはZ座標を移動
            currentPos += new Vector3(0f, 0f, movingSpeed * Time.deltaTime);
            currentPos.z = Mathf.Clamp(currentPos.z, initalPos.z + -movingDistance, initalPos.z);
        }


        if (transform.position.z == currentPos.z)
        {
            isCloseing = false;
        }
        else
        {
            isCloseing = true;
        }

        transform.position = currentPos;
    }

    void Reopen()
    {
        Vector3 currentPos = transform.position;

        if (isRotate90D)
        {
            //90度回転しているときX座標を移動
            currentPos += new Vector3(-movingSpeed * Time.deltaTime, 0f);
            currentPos.x = Mathf.Clamp(currentPos.x, initalPos.x + -movingDistance, initalPos.x);
        }
        else
        {
            //0°のときはZ座標を移動
            currentPos += new Vector3(0f, 0f, -movingSpeed * Time.deltaTime);
            currentPos.z = Mathf.Clamp(currentPos.z, initalPos.z + -movingDistance, initalPos.z);
        }

        if (currentPos.z == (initalPos.z + movingDistance))
        {
            isNotClose = false;
        }

        transform.position = currentPos;
    }

    void OnCollisionEnter(Collision hit)
    {
        if (hit.collider.tag != "Wall" || hit.collider.tag != "Key" || hit.collider.tag != "CardKey")
        {
            if (isCloseing)
            {
                print("OnCollisionEnter if  " + hit.collider.name);
                isNotClose = true;
            }
        }
    }
}
