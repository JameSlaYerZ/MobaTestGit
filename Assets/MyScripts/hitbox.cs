using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitbox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "weapon")
        {
            CharacterStatus status = other.gameObject.GetComponentInParent<CharacterStatus>();
            status.GetHit(status.atk);
        }
    }
}
