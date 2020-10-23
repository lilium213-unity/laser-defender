using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [field: SerializeField] public int Damage { get; set; } = 100;

    public void Hit()
    {
        Destroy(gameObject);
    }
}
