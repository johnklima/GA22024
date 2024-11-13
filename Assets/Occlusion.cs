using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Occlusion : MonoBehaviour
{

    public Transform player;
    Vector3 defaultPos;
    bool isOccluding;
    Vector3 hitPoint;
    float hitDistance;

    Renderer renderer;
    Material material;
    Color color;
    Transform obj;

    public bool doCamera = false;
    public bool doTransparency = true;

    // Start is called before the first frame update
    void Start()
    {
        player = transform.parent;
        defaultPos = transform.localPosition;
        
       
    }

    // Update is called once per frame
    void Update()
    {

        if(doCamera)
        {
            doCamMove();
        }

        if(doTransparency)
        {
            doMaterialTransparency();
        }
        
    }

    void doMaterialTransparency()
    {
        if (obj && isOccluding)
        {

            renderer = obj.GetComponent<Renderer>();
            material = renderer.material;
            color = material.color;

            material.color = new UnityEngine.Color(color.r, color.g, color.b, 1.0f);
            isOccluding = false;

        }


        // Bit shift the index of the layer (6) to get a bit mask
        int layerMask = 1 << 6;

        Vector3 dir = (player.position - transform.position);
        float dist = Vector3.Magnitude(dir) - 0.5f;

        dir.Normalize();

        if (Physics.Raycast(transform.position, dir,
                            out RaycastHit hitInfo, dist, layerMask))
        {

            Debug.Log(hitInfo.collider.name + " occluding player");

            obj = hitInfo.collider.transform;
            renderer = obj.GetComponent<Renderer>();
            material = renderer.material;
            color = material.color;


            material.color = new UnityEngine.Color(color.r, color.g, color.b, 0.5f);

            isOccluding = true;
        }
        else
        {
            obj = null;
        }


    }

    void doCamMove()
    {
        transform.localPosition = defaultPos;

        // Bit shift the index of the layer (6) to get a bit mask
        int layerMask = 1 << 6;

        Vector3 dir = (player.position - transform.position);
        float dist = Vector3.Magnitude(dir) - 0.5f;

        dir.Normalize();

        if (Physics.Raycast(transform.position, dir,
                            out RaycastHit hitInfo, dist, layerMask))
        {

            Debug.Log(hitInfo.collider.name + " occluding player");
            hitPoint = hitInfo.point;
            hitDistance = hitInfo.distance;

            transform.localPosition = defaultPos + Vector3.forward * hitDistance;
            transform.localPosition -= Vector3.up * 2;



        }

    }
}
