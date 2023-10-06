using System.Collections;
using UnityEngine;

public class ClockSound : MonoBehaviour
{
    int oldHour;
    int cont;

    [Header("Sounds")]
    public AudioSource bell;

    void Update()
    {
        cont = oldHour;

        int hoursInt = int.Parse(System.DateTime.UtcNow.ToLocalTime().ToString("hh"));

        if (hoursInt != oldHour)
        {
            StartCoroutine("TickingBell");
        }
        oldHour = hoursInt;

    }

    IEnumerator TickingBell()
    {
        for (int i = 0; i < cont; i++)
        {
            bell.PlayOneShot(bell.clip);
            yield return new WaitForSeconds(4f);
        }
    }
}
