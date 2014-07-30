using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

	public CharacterStats characterTarget;
	public GameControlMode controlMode = GameControlMode.FirstPerson;
}

public enum GameControlMode {FirstPerson, ThirdPerson, Tactical}