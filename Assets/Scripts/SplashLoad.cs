using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Invoke("LoadFirstScene", 2f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }
}
