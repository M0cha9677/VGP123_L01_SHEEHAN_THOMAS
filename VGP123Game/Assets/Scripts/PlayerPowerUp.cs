using UnityEngine;
using System.Collections;

public class PlayerPowerUp : MonoBehaviour
{
    public bool isPoweredUp { get; private set;  }
    public float powerDuration = 5f;

    Coroutine routine;

    public void ActivatePowerUp()
    {
        if (routine != null) StopCoroutine(routine);
        routine = StartCoroutine(PowerRoutine());

    }

    IEnumerator PowerRoutine()
    {
        isPoweredUp = true;
        Debug.Log("Powered-Up ON");

        yield return new WaitForSeconds(powerDuration);

        isPoweredUp = false;
        Debug.Log("Powered_UP OFF");
        routine = null;
    }
}
