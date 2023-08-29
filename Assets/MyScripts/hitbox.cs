using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitbox : MonoBehaviour
{
    public CharacterStatus characterstatus;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "weapon")
        {
            characterstatus.GetHit(characterstatus.atk);
        }
    }
}
