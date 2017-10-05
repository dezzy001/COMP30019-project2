using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashScript : MonoBehaviour {

	private Material currentMat;
	public Material flashMat;

	private MeshRenderer thisMeshRend;

	private float FLASH_WAIT = 0.1f;

	void Start(){
		thisMeshRend = this.gameObject.GetComponent<MeshRenderer> ();
		currentMat = thisMeshRend.sharedMaterial;
	}
		

	public void enemyFlash(){

		thisMeshRend.material = flashMat;
		StartCoroutine (flash());
	}

	IEnumerator flash(){
		yield return new WaitForSeconds (FLASH_WAIT);
		thisMeshRend.material = currentMat;

	}
}
