using UnityEngine;

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
    }

    void OpenDoor()
    {
        Vector3 targetPos = transform.position;

        if (isRotate90D)
        {
            //90度回転しているときX座標を移動
            targetPos += new Vector3(-movingSpeed * Time.deltaTime, 0f, 0f);
            targetPos.x = Mathf.Clamp(targetPos.x, initalPos.x + -movingDistance, initalPos.x);
        }
        else
        {
            //0°のときはZ座標を移動
            targetPos += new Vector3(0f, 0f, -movingSpeed * Time.deltaTime);
            targetPos.z = Mathf.Clamp(targetPos.z, initalPos.z + -movingDistance, initalPos.z);
        }

        transform.position = targetPos;
    }

    void CloseDoor()
    {
        Vector3 targetPos = transform.position;

        if (isRotate90D)
        {
            //90度回転しているときX座標を移動
            targetPos += new Vector3(movingSpeed * Time.deltaTime, 0f);
            targetPos.x = Mathf.Clamp(targetPos.x, initalPos.x + -movingDistance, initalPos.x);


            if (transform.position.x == targetPos.x)
            {
                isCloseing = false;
            }
            else
            {
                isCloseing = true;
            }
        }
        else
        {
            //0°のときはZ座標を移動
            targetPos += new Vector3(0f, 0f, movingSpeed * Time.deltaTime);
            targetPos.z = Mathf.Clamp(targetPos.z, initalPos.z + -movingDistance, initalPos.z);

            if (transform.position.z == targetPos.z)
            {
                isCloseing = false;
            }
            else
            {
                isCloseing = true;
            }
        }


        transform.position = targetPos;
    }

    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag != "Wall" && hit.gameObject.tag != "Key" && hit.gameObject.tag != "CardKey")
        {
            if (isCloseing)
            {
                isOpen = true;
            }
        }
    }
}
