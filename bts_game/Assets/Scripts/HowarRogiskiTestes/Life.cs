using UnityEngine;
using System.Collections;

public class Life : MonoBehaviour {

    private int minPower = 0;
    private int maxPower = 10;
    private int power = 10;

    public int GetPower() { return power; }

    public void SetDamage(int damage)
    {
        if ((power - damage) > minPower)
        { power -= damage; }
        else { power = minPower; }
    }

    public void SetLife(int life)
    {
        if ((power + life) < maxPower)
        { power += life; }
        else { power = maxPower; }
    }
}
