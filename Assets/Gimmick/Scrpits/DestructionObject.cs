using UnityEngine;
using System.Collections;

public class DestructionObject : MonoBehaviour {
    
    [SerializeField]
    private int Hp;
    [SerializeField]
    private int decrease;

	void Start ()
    {
    }

	void Update ()
    {
	
	}

    public void EnduranceValue()
    {
        if (Hp != 0)
        {
            Hp -= decrease;
        }else if(Hp<=0)
        {
            Hp = 0;
            Destroy(this.gameObject);
        }
    }
}
