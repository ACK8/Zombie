using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour
{
    private NavMeshAgent navMesh;
    private Vector3 targetPos = Vector3.zero;
    private float injectionVolume = 0f;   //ゾンビ薬の注入量
    private bool _isMove = false;
    private bool _isZombie = false;

    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //ゾンビ誘導処理
        Induction();

        //注射処理
        Injection();
    }

    //ゾンビ誘導処理
    void Induction()
    {
        if (isMove)
        {
            navMesh.SetDestination(targetPos);
        }

        //目的地に到着
        if (Vector3.Distance(this.transform.position, targetPos) <= 0.9f)
        {
            _isMove = false;
        }
    }

    void OnTriggerStay(Collider hit)
    {
        if (hit.tag == "Injection")
        {
            injectionVolume += Time.deltaTime;
            print("injection" + injectionVolume);
        }
    }

    //注射処理
    void Injection()
    {
        if (3f <= injectionVolume)
        {
            _isZombie = true;
        }
    }


    //目的座標(誘導用)
    public Vector3 target
    {
        get { return targetPos; }
        set { targetPos = value; }
    }

    //NavMeshで移動しているか(誘導用)
    public bool isMove
    {
        get { return _isMove; }
        set { _isMove = value; }
    }

    //死体かゾンビかの状態
    public bool isZombie
    {
        get { return _isZombie; }
        set { _isZombie = value; }
    }
}
