
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Jump Force
    [SerializeField]
    private float force;

    private Rigidbody rigidBody;

    //Initial weght
    [SerializeField]
    private float weight;

    //Additional weight add on every second
    [SerializeField]
    private float additionalWeight;

    //Timer variable
    private float timer;
    private float initialWeight;
    [SerializeField]
    private float maxWeight;

    private void Awake()
    {
        rigidBody = gameObject.GetComponent<Rigidbody>();
        rigidBody.mass = weight;
        initialWeight = weight;
    }

    private void Update()
    {
        //Timer to add Additional mass to rigidbody
        timer += Time.deltaTime;
        if (timer < 1)
            return;
        timer = 0;


#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            weight = weight + additionalWeight;

        }
        else
        {
            weight = weight - additionalWeight;

        }

#elif UNITY_ANDROID 
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Stationary)
            {
                weight = weight + additionalWeight;
            }
        }
        else
        {
            weight = weight - additionalWeight;
        }
#endif

        //add mass to rigidbody
        if (weight < initialWeight)
            weight = initialWeight;
        else if (weight > maxWeight)
            weight = maxWeight;

        rigidBody.mass = weight;

    }


    
    private void OnTriggerEnter(Collider other)
    {

        //Check Against trampolin layer
        if (other.gameObject.layer == 9)
        {
            //add force to upwards
            rigidBody.velocity = Vector3.up*weight;
        }
    }


}
