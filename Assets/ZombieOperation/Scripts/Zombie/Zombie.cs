using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour
{
    [SerializeField]
    private float zombieChangeTime = 3f;    //注射時、ゾンビに変化する時間

    private NavMeshAgent navMesh;
    private Vector3 _targetPos = Vector3.zero;
    private float injectionVolume = 0f;   //ゾンビ薬の注入量
    private bool _isMove = false;
    private bool _isZombie = false;

    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (_isZombie)
        {
            //ゾンビ誘導処理
            Induction();
        }
        else
        {
            //注射処理
            Injection();
        }
    }

    //ゾンビ誘導処理
    void Induction()
    {
        if (isMove)
        {
            navMesh.SetDestination(_targetPos);
        }

        //目的地に到着
        if (Vector3.Distance(this.transform.position, _targetPos) <= 0.9f)
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
    public Vector3 targetPos
    {
        get { return _targetPos; }
        set { _targetPos = value; }
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
