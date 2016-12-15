using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Weapon : MonoBehaviour {
    public enum WeaponType
    {
        semiAutomatic,
        automatic
    };

    public Transform bulletSpawn;
    public GameObject ammoPrefab;
    public WeaponType type;
    public int maxRoundsInMagazine;

    private int currentRoundsInMagazine;

    void Start()
    {
        currentRoundsInMagazine = maxRoundsInMagazine;
        GodObject.BulletsText.text = currentRoundsInMagazine.ToString();
    }

    public void shoot()
    {
        if (currentRoundsInMagazine > 0)
        {
            Instantiate(ammoPrefab, bulletSpawn.position, gameObject.transform.rotation);
            --currentRoundsInMagazine;
        }

        GodObject.BulletsText.text = currentRoundsInMagazine.ToString();
    }
}
