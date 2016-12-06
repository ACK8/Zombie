using UnityEngine;
using System.Collections;

public class ChildeCollider : MonoBehaviour
{
    [SerializeField]
    private Zombie zombie;

    void OnCollisionEnter(Collision hit)
    {
        zombie.HitCollider(hit);
    }
}
