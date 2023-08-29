using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
   
    [SerializeField] private int hp;
    [SerializeField] public int atk;
    [SerializeField] public int range;
    [SerializeField] private float speed;

    public bool isdead;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetHit(int damage)
    {
        if (hp <= 0) return;

        hp -= damage;
    }

    void Isdead()
    {
        if(hp <= 0)
        {
            isdead = true;
        }
    }


}
