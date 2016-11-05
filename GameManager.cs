using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	[SerializeField]
	private int money;
	public int Money { 
		get {
			return money;
		}
		set {
			money = value;
		}
	}


}
