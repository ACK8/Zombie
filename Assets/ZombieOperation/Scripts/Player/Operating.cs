using UnityEngine;
using System.Collections;

public enum OperatingType
{
    None,
    Wait,
    Move,
    Following,
    Attack,
}

public class Operating : MonoBehaviour
{
    public GameObject movePointObject;
    public GameObject rayPointObject;
    public Circle circlePoint; //円を表示するシェーダー
    public GameObject selectionTarget; //レイの先の当たり判定用
    public Transform playerTransform;

    private OperatingType operatingType;
    private GameObject selectedZombie = null;
    private GameObject selectedObject = null;
    private LineRenderer line;
    private RaycastHit hit;
    private Ray ray;

    void Start ()
    {
        line = GetComponent<LineRenderer>();
    }
	
	void Update ()
    {
        ray.direction = rayPointObject.transform.forward;
        ray.origin = rayPointObject.transform.position;

        line.SetPosition(0, ray.origin);
        line.SetPosition(1, ray.GetPoint(200));
        line.enabled = true;

        if (Physics.Raycast(ray, out hit, 200.0f))
        {
            circlePoint.SetPoint(hit.point);
        }
        else
        {
            //selectionTarget.SetActive(false);
        }
    }

    public void Decision()
    {
        //ゾンビのGameObjectを取得
        if (hit.transform.tag == "Zombie")
        {
            //ゾンビ化状態を取得
            if(hit.transform.gameObject.GetComponent<Zombie>().isZombie)
            {
                selectedZombie = hit.transform.gameObject;
            }
        }

        if (selectedZombie != null)
        {
            //選択対象のGameObject取得
            if (hit.transform.tag == "Object")
            {
                selectedObject = hit.transform.gameObject;
            }

            if(hit.transform.tag == "Map")
            {
                movePointObject.SetActive(true);
                movePointObject.transform.position = hit.point;
            }
            else
            {
                movePointObject.SetActive(false);
            }
        }
    }

    //待機
    public void OperatingWait()
    {
        //ゾンビの命令を実行
        if ((selectedZombie != null))
        {
            operatingType = OperatingType.Wait;
            selectedZombie.GetComponent<Zombie>().Wait();
            Debug.Log(operatingType + "実行");
        }
    }

    //移動
    public void OperatingMove()
    {
        //ゾンビの命令を実行
        if ((selectedZombie != null) && movePointObject.activeSelf)
        {
            operatingType = OperatingType.Move;
            selectedZombie.GetComponent<Zombie>().Move(movePointObject.transform.position);
            Debug.Log(operatingType + "実行");
        }
    }

    //追従
    public void OperatingFollowing()
    {
        //ゾンビの命令を実行
        if ((selectedZombie != null))
        {
            operatingType = OperatingType.Following;
            selectedZombie.GetComponent<Zombie>().Following(ref playerTransform);
            Debug.Log(operatingType + "実行");
        }
    }

    //攻撃
    public void OperatingAttack()
    {
        //ゾンビの命令を実行
        if ((selectedZombie != null) && (selectedObject != null))
        {
            if (selectedObject.tag != "DestructionObject") return;

            operatingType = OperatingType.Attack;
            selectedZombie.GetComponent<Zombie>().Destruction(selectedObject);
            Debug.Log(operatingType + "実行");
        }
    }
}
