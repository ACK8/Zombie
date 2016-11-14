using UnityEngine;
using System.Collections;

public class CameraFade : MonoBehaviour
{
    public string areaName;
    public Transform playerTransform;

    private Transform targetTransform;

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
            line.SetPosition(0, targetTransform.transform.position);
            
            Vector3 pos = new Vector3(transform.position.x, targetTransform.transform.position.y, transform.position.z);
            line.SetPosition(1, pos);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        //エリアごとの処理
        if (isArea)
        {
            //自分がいるエリアを取得
            if (collider.transform.tag == "Area")
            {
                areaName = collider.transform.name;
                Debug.Log(areaName);

                targetTransform = collider.gameObject.transform.FindChild("Return");
            }

            //カメラが壁にめり込んだ
            if (collider.transform.tag == "Wall")
            {
                Debug.Log(collider.transform.tag);

                line.enabled = true;
                isArea = false;
            }
        }
        else
        {
            //カメラが指定の場所に戻った
            if (collider.transform.name == "Return")
            {
                Debug.Log(collider.transform.name);

                line.enabled = false;
                isArea = true;
            }
        }
    }
}