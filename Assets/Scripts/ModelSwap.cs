using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class ModelSwap : MonoBehaviour
{
	public GameObject[] model;
	public Button[] button;
	private Rigidbody rb;
	public int n=-1;
	public float speed=5.0f;
	private float rotx=0.0f;
	private float roty=0.0f;
	private TrackableBehaviour image;

	void Start () 
	{	
		button = this.GetComponentsInChildren<Button> ();
		rb = GetComponent<Rigidbody> ();
	}

	public void swapper(int k)
	{
		for (int i = 0; i <= 4; i++)
		{
			if (i == k)
				{	
					model [i].SetActive (true);	
					model [i+5].SetActive (true);
					n = i;
					Reset ();	
				} 
			else
				{
					model [i].SetActive (false);
					model [i+5].SetActive (false);
					Reset ();	
				}
			}	
	}

	public void Reset()
	{
		rotx = roty = 0f;
		switch (n) 
		{
			case 0:	model[n].transform.localPosition=new Vector3(0f,0.029f,0f);
					model[n].transform.localScale=new Vector3(1f,1f,1f);
					model[n].transform.eulerAngles=new Vector3(roty,rotx,0f);
					model[n+5].transform.localPosition=new Vector3(0f,0.029f,0f);
					model[n+5].transform.localScale=new Vector3(1f,1f,1f);
					model[n+5].transform.eulerAngles=new Vector3(roty,rotx,0f);
					break;
			case 1:	rotx = 180f;
					model[n].transform.localPosition=new Vector3(0f,0.0271f,0f);
					model[n].transform.localScale=new Vector3(0.3f,0.3f,0.3f);
					model[n].transform.eulerAngles=new Vector3(roty,rotx,0f);
					model[n+5].transform.localPosition=new Vector3(0f,0.0271f,0f);
					model[n+5].transform.localScale=new Vector3(0.3f,0.3f,0.3f);
					model[n+5].transform.eulerAngles=new Vector3(roty,rotx,0f);
					break;
			case 2:	rotx = 180f;
					model[n].transform.localPosition=new Vector3(0f,0.183f,0f);
					model[n].transform.localScale=new Vector3(0.3f,0.3f,0.3f);
					model[n].transform.eulerAngles=new Vector3(roty,rotx,0f);
					model[n+5].transform.localPosition=new Vector3(0f,0.183f,0f);
					model[n+5].transform.localScale=new Vector3(0.3f,0.3f,0.3f);
					model[n+5].transform.eulerAngles=new Vector3(roty,rotx,0f);
					break;
			case 3:	model[n].transform.localPosition=new Vector3(0f,0.033f,0f);
					model[n].transform.localScale= new Vector3(0.4f,0.4f,0.4f);
					model[n].transform.eulerAngles=new Vector3(roty,rotx,0f);
					model[n+5].transform.localPosition=new Vector3(0f,0.033f,0f);
					model[n+5].transform.localScale= new Vector3(0.4f,0.4f,0.4f);
					model[n+5].transform.eulerAngles=new Vector3(roty,rotx,0f);
					break;
			case 4:	model[n].transform.localPosition=new Vector3(0f,0.165f,0f);
					model[n].transform.localScale=new Vector3(.5f,.5f,.5f);
					model[n].transform.eulerAngles=new Vector3(roty,rotx,0f);
					model[n+5].transform.localPosition=new Vector3(0f,0.165f,0f);
					model[n+5].transform.localScale=new Vector3(.5f,.5f,.5f);
					model[n+5].transform.eulerAngles=new Vector3(roty,rotx,0f);
					break;
		}
	}

	public void ChangeScene(string scenename)
	{
		SceneManager.LoadSceneAsync(scenename);
	}
	public void BackButton()
	{
		if (Application.platform == RuntimePlatform.Android)
		{
			if (Input.GetKey (KeyCode.Escape)) {				
				Application.Quit ();
			}
		}
	}
	public void Joystick()
	{
		rotx-=CrossPlatformInputManager.GetAxis("Horizontal")*speed;
		roty+=CrossPlatformInputManager.GetAxis("Vertical")*speed;
		model[n].transform.eulerAngles = new Vector3 (roty,rotx,0f);
		model[n+5].transform.eulerAngles = new Vector3 (roty,rotx,0f);
	}
	public void Update()
	{
		Joystick ();
		BackButton ();
	}
}
