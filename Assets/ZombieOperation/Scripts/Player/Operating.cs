using UnityEngine;
using System.Collections;

public enum OperatingType
{
    Wait,
    Move,
    Following,
    Attack,
}

public class Operating : MonoBehaviour
{
    public GameObject rayPointObject;
    public GameObject selectionTarget; //レイの先の当たり判定用
    public OperatingType operatingType;

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
    }

    public void Decision()
    {
        if (Physics.Raycast(ray, out hit, 200.0f))
        {
            selectionTarget.transform.position = hit.point;

            //ゾンビのGameObjectを取得
            if (hit.transform.tag == "Zombie")
            {
                selectedZombie = hit.transform.gameObject;
            }

            //選択対象のGameObject取得
            if (hit.transform.tag == "Object")
            {
                selectedObject = hit.transform.gameObject;
            }
        }
        else
        {
            selectionTarget.transform.position = Vector3.zero;
        }

        //ゾンビの命令を実行
        if (selectedZombie != null)
        {
            Zombie currentZombie = selectedZombie.GetComponent<Zombie>();

            //命令を実行
            switch (operatingType)
            {
                case OperatingType.Wait:

                    break;

                case OperatingType.Move:

                    break;

                case OperatingType.Following:

                    break;

                case OperatingType.Attack:

                    if (selectedObject != null)
                    {

                    }

                    break;
            }
        }
    }

    public void OperatingWait()
    {
        operatingType = OperatingType.Wait;
    }

    public void OperatingMove()
    {
        operatingType = OperatingType.Move;
    }

    public void OperatingFollowing()
    {
        operatingType = OperatingType.Following;
    }

    public void OperatingAttack()
    {
        operatingType = OperatingType.Attack;
    }
}
