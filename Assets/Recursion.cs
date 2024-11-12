using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recursion : MonoBehaviour
{

    public string names;
    public Transform bestNode;
    public int depth = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        RecurseNames(transform);
        
    }

    void RecurseNames(Transform node)
    {
        depth++;  // add to how deep I am

        //go deeper for each child node that this node has
        foreach(Transform childNode in node)
        {
            RecurseNames(childNode);            
        }

        //is it a goal node?
        Goal trygoal = node.GetComponent <Goal>(); 
        if(trygoal)
        {
            //it is so, tell it it's cost
            trygoal.cost = depth;            
        }
        //concatonate the node names
        names = names + node.name;

        //back out of the recursion
        depth--;
    }
    
}
