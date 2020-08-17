using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*When Contact with player, Deplete player HP */
public class EnemyPlayerContact : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag != "Boundary" )
		{
			if (other.gameObject.tag == "Player")
            {
				Player playerScript = other.gameObject.GetComponent<Player>();
				if (!playerScript.CheckInvin()) {

					playerScript.DecreaseHp();

				}
            }
		}
	}
}
