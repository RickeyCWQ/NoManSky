using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallTyperEffect : MonoBehaviour {
    public TyperTest typerTest;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.T)){
            if(typerTest == null){

                return;
            }

            typerTest.StartEffect();
        }
	}
}
