using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int HP;
    [SerializeField] int MaxHP = 100;
    public GameObject Destroyed;
    public GameObject DestroyWithThis;
    public void ReduceHP(int val, StarShip source) {
        if(val == 0) {
            Debug.Log(transform.name + "avoids damage by" + source.gameObject.transform.name);
        } else {
            if(HP - val < 0)
                HP = 0;
            else
                HP -= val;
            if(HP == 0) {
                if(Destroyed != null) {
                    var instanced = Instantiate(Destroyed,transform.position, transform.rotation);
                }
                Destroy(DestroyWithThis);
                if(transform.childCount > 0) {
                    for(int i = 0; i < transform.childCount; ++i) {
                        transform.GetChild(i).SetParent(transform.parent);
                    }
                }
                Destroy(gameObject);
            }
        }
    }
    public void IncreaseHP(int val,  StarShip source) {
        if(val == 0) {
            Debug.Log(transform.name + "misses heal" + source.gameObject.transform.name);
        } else {
            if(HP + val >= MaxHP) {
                HP = MaxHP;
            } else {
                HP += val;
            }
        }
    }
}
