using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallParticle : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        if(other.name == "Wall")
        {
            Debug.Log("Hit Wal");
        }
    }
}
