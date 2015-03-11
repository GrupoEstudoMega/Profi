using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	public int maxcoins;
	public GameObject coin;

	// Use this for initialization
	void Start () {
		InvokeRepeating("GeraCoins",1,3);
	}

	
	// Update is called once per frame
	void Update () {
	}

	void GeraCoins () {
		if (gameObject.transform.childCount < maxcoins) {
		    var obj = Instantiate(coin);
			obj.transform.position = new Vector2(Random.Range(-0.5f,3.2f),0.75f);
			obj.transform.SetParent(gameObject.transform);
		}
	}
	

}
