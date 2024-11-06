using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VizCode : MonoBehaviour
{

    public Transform lookingFor;

    private Transform owner;

    private NPCmovement movement;

    // Start is called before the first frame update
    void Start()
    {
        owner = transform.parent;
        movement = owner.GetComponent<NPCmovement>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawLine(owner.position, lookingFor.position, Color.yellow);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform == lookingFor )
        {
            Debug.Log("Found what I am looking for");


            //now do the raycast
            Vector3 direction = lookingFor.position - owner.position;
            float distance = direction.magnitude;

            direction.Normalize();                        
            
            if (Physics.Raycast(owner.position, direction , out RaycastHit hitInfo, distance))
            {

                Debug.Log("I can see " + lookingFor.name);
                Debug.DrawLine(owner.position, lookingFor.position, Color.red);

                //Do something
                movement.target = lookingFor;
                movement.isFollowPlayer = true;
                movement.isPatrolling = false;


            }

        }


    }

}
