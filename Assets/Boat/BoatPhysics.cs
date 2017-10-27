using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatPhysics : MonoBehaviour {

    public Transform Water;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        float profondeur = transform.position.y - Water.position.y;
        //Debug.Log(profondeur);
        Vector3 forceUp = Vector3.up * Mathf.Pow(Mathf.Abs(profondeur), 3.0f) * 10;
        if (profondeur < 0)
        {
            GetComponent<Rigidbody>().AddForce(forceUp);
        }
        else
            if(profondeur < 1.0f)
                GetComponent<Rigidbody>().AddForce(-forceUp);
    }
}
