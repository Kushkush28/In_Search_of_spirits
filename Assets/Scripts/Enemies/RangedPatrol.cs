using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedPatrol : MonoBehaviour
{
    public float walkSpeed,range;
    private bool mustTurn;
    public Rigidbody2D rb;
    public Transform groundCheckPos;
    public LayerMask groundLayer;
    public Collider2D bodycollider;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
