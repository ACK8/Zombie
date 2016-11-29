using UnityEngine;
using System.Collections;

public class DestructionObject : MonoBehaviour {
    
    [SerializeField]
    private int Hp;
    [SerializeField]
    private int decrease;
	// Use this for initialization
	void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    public void EnduranceVaule()
    {
        if (Hp != 0)
        {
            Hp -= decrease;
        }else if(Hp<=0)
        {
            Hp = 0;
        }
    }
}
