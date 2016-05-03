using UnityEngine;
using System.Collections;

public class CharacterBase : MonoBehaviour {

	private string type;
	private int force;
	private int inteligence;
	private int life;
	private int speed;
	private int jump;
	private int manna;
	private int stamina;
	private int magicPower;

	public string Type {
		get { return type; }
		set { type = value; }
	}

	public int Force {
		get { return force; }
		set { force = value; }
	}

	public int Inteligence {
		get { return inteligence; }
		set { inteligence = value; }
	}

	public int Life {
		get { return life; }
		set { life = value; }
	}

	public int Speed {
		get { return speed; }
		set { speed = value; }
	}

	public int Jump {
		get { return jump; }
		set { jump = value; }
	}

	public int Manna {
		get { return manna; }
		set { manna = value; }
	}

	public int Stamina {
		get { return stamina; }
		set { stamina = value; }
	}

	public int MagicPower {
		get { return magicPower; }
		set { magicPower = value; }
	}
}
