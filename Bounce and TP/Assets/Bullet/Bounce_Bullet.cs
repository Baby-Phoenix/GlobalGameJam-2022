using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce_Bullet : MonoBehaviour
{
    public int countBonune = 0;
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag != "Player")
        {
            countBonune = countBonune + 1;
            if (col.gameObject.tag == "Interactable")
            {
                Vector3 t = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().GetTPPos();
                col.gameObject.GetComponent<TPObject>().TP(t);
            }
            if (countBonune == 3)
            {
                Destroy(gameObject);
            }
        }
    }
}
