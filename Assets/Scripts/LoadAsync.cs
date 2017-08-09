using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadAsync : MonoBehaviour { 

	public Text progressText;
	public string scene;
	// Use this for initialization
	void Start () {
		StartCoroutine(loadScene());		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator loadScene(){
		AsyncOperation async = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
		async.allowSceneActivation = false;
		while(async.progress <= 0.89f){
			progressText.text = async.progress.ToString();		
			yield return null;
		}
		async.allowSceneActivation = true;
	}
}
