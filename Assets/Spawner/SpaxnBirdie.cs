using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaxnBirdie : MonoBehaviour {

    public Transform Birdie;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "Player")
        {
            for(int i = -10; i < 10; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    Birdie.gameObject.SetActive(true);
                    Vector3 position = Camera.main.transform.position;
                    position += -Vector3.right * 100;
                    position += -Vector3.right * j * 20;
                    position += Vector3.forward * i * 20;
                    Instantiate(Birdie, position, Quaternion.identity);
                }
            }
            
        }
    }


}
