using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelRotate : MonoBehaviour {
	
	private bool _rotatelside;
	private bool _rotaterside;
	private bool _rotateup;
	private bool _rotatedown;
	public GameObject model;

	#region Leftsidee
	public void OnPressLS()
	{
		_rotatelside = true;
	}
	public void OnReleaseLS()
	{
		_rotatelside = false;
	}
	public void RotateLeftSide()
	{	
		if(_rotatelside)
		{
			model.transform.Rotate(Vector3.up, 1f, Space.World);
		}
	}
 	#endregion Leftside

	#region Rightside
	public void OnPressRS()
	{
		_rotaterside = true;
	}

	public void OnReleaseRS()
	{
		_rotaterside = false;
	}
	public void RotateRightSide()
	{	
		if(_rotaterside)
		{
			model.transform.Rotate(Vector3.down, 1f, Space.World);
		}
	}
	#endregion Rightside

	#region Up
	public void OnPressU()
	{
		_rotateup = true;
	}

	public void OnReleaseU()
	{
		_rotateup = false;
	}
	public void RotateUp()
	{	
		if(_rotateup)
		{
			model.transform.Rotate(Vector3.right, 1f, Space.World);
		}
	}
	#endregion Up

	#region Down
	public void OnPressD()
	{
		_rotatedown = true;
	}

	public void OnReleaseD()
	{
		_rotatedown = false;
	}
	public void RotateDown()
	{	
		if(_rotatedown)
		{
			model.transform.Rotate(Vector3.left, 1f, Space.World);
		}
	}
	#endregion Down

	void Update()
	{
		RotateLeftSide ();
		RotateUp ();
		RotateDown ();
		RotateRightSide ();
	}
}
