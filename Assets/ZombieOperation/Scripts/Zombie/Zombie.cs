using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour
{
    [SerializeField]
    private float zombieChangeTime = 2.5f;    //注射時、ゾンビに変化する時間

    private NavMeshAgent navMesh;
    private CapsuleCollider capsuleCol;
    private Vector3 targetPos = Vector3.zero;
    private Vector3 _pushDistance = Vector3.zero;
    private GameObject destructionTarget = null;
    private float injectionVolume = 0f;   //ゾンビ薬の注入量
    private float navSpeed = 0f;
    private bool _isMove = false;
    private bool _isZombie = false;

    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        navSpeed = navMesh.speed;
        capsuleCol.enabled = false;
    }

    void Update()
    {
        if (_isZombie)
        {
            Animation();
        }
        else
        {
            //注射処理
            Injection();
        }
    }

    //待機
    public void Wait()
    {
        navMesh.speed = 0f;
    }

    //ゾンビ誘導処理
    public void Move(Vector3 target)
    {
        if (isMove)
        {
            navMesh.speed = navSpeed;
            navMesh.SetDestination(target);
        }

        //目的地に到着
        if (Vector3.Distance(this.transform.position, target) <= 0.9f)
        {
            _isMove = false;
        }
    }

    //障害物を破壊
    public void Destruction(GameObject target)
    {
        destructionTarget = target;
    }

    //アニメーション   
    void Animation()
    {

    }

    //注射処理
    void Injection()
    {
        if (zombieChangeTime <= injectionVolume)
        {
            _isZombie = true;
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        if (hit.tag == "Obstacle" && hit.gameObject == destructionTarget)
        {

        }
    }

    void OnTriggerStay(Collider hit)
    {
        if (hit.tag == "Injection" && !_isZombie)
        {
            injectionVolume += Time.deltaTime;
        }
    }


    //障害物を押した距離
    public Vector3 pushDistance
    {
        get { return _pushDistance; }
        set { _pushDistance = value; }
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
