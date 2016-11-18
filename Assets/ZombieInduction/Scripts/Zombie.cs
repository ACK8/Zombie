using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour
{
    //****誘導用****//
    private NavMeshAgent navMesh;
    private Vector3 targetPos = Vector3.zero;
	private bool _isMove = false;

    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Induction();
    }

    //誘導処理
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

    //目的座標(誘導用)
    public Vector3 target 
	{
		get{return targetPos; }
		set{ targetPos = value; }
	}

    //NavMeshで移動しているか(誘導用)
    public bool isMove 
	{
		get{return _isMove; }
		set{ _isMove = value; }
	}
}
