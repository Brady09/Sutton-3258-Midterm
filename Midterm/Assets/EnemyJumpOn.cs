using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJumpOn : MonoBehaviour
{
    public Transform cube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy") 
        {
            Destroy(other.transform.parent.gameObject);
        }
    }

}
