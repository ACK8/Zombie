using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour
{
    [SerializeField]
    private CapsuleCollider capsuleCol;
    [SerializeField]
    private float zombieChangeTime = 2.5f;    //注射時、ゾンビに変化する時間
    [SerializeField]
    private float attackAnimRate; //攻撃が有効になるアニメーション時間

    private NavMeshAgent navMesh;
    private Animator anim;
    private Vector3 targetPos = Vector3.zero;
    private GameObject destructionTarget = null;
    private float injectionVolume = 0f;   //ゾンビ薬の注入量
    private float navSpeed = 0f;
    private bool _isMove = false;
    [SerializeField]
    private bool _isZombie = false;
    private bool isChange = false;

    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
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

            anim.Play("GetUp", -1, 0.0f);
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
        navMesh.speed = navSpeed;
        navMesh.SetDestination(target);

        //目的地に到着
        if (Vector3.Distance(this.transform.position, target) <= 0.9f)
        {
            _isMove = false;
        }
    }

    //プレイヤーに追従
    public void Following(ref Transform playerPos)
    {
        navMesh.speed = navSpeed;
        navMesh.SetDestination(playerPos.position);

        //目的地に到着
        if (Vector3.Distance(this.transform.position, playerPos.position) <= 2.0f)
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
        //起き上がる
        if (!isChange)
        {
            isChange = true;
            anim.SetBool("GetUp", false);
        }

        anim.Update(0);
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.IsName("Base Layer.Attack"))
        {
            if (attackAnimRate <= stateInfo.normalizedTime && stateInfo.normalizedTime < (attackAnimRate + 0.1f))
            {
                capsuleCol.enabled = true;
            }
            else
            {
                capsuleCol.enabled = false;
            }
        }
    }

    //注射処理
    void Injection()
    {
        if (zombieChangeTime <= injectionVolume)
        {
            _isZombie = true;
            anim.SetBool("GetUp", true);
        }
    }

    void OnTriggerEnter(Collider hit)
    {
        //障害物破壊
        if (hit.tag == "DestructionObject" && hit.gameObject == destructionTarget)
        {
            hit.gameObject.GetComponent<DestructionObject>().DecreaseEnduranceValue();
        }
    }

    void OnTriggerStay(Collider hit)
    {
        //注射
        if (hit.tag == "Injection" && !_isZombie)
        {
            injectionVolume += Time.deltaTime;
        }
    }

    //ボーンについているスクリプトから呼ばれる
    public void HitCollider(Collision hit)
    {
        print(hit.collider.name);
    }

    //ボーンについているスクリプトから呼ばれる
    public void HitTrigger(Collider hit)
    {
        print(hit.name);
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
