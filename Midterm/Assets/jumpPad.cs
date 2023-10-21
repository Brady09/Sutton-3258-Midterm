using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpPad : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 verticalVelocity;

    public void ModifyVerticalVelocity(Vector3 velocity)
    {
        verticalVelocity += velocity;
    }

    
  
   
    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CharacterController controller))
        {
            Vector3 velocity = Vector3.up * 10f;
            ModifyVerticalVelocity(velocity);
        }
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
