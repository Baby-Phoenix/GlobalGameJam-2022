using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce_Bullet : MonoBehaviour
{
    private Rigidbody rb;
    Vector3 lastVelocity;
    public int countBonune = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (countBonune == 3)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionExit(Collision other)
    {
        countBonune = countBonune + 1;
    }
}
