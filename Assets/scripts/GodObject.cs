using UnityEngine;
using UnityEngine.UI;

public class GodObject : MonoBehaviour {
    private static Player player;
    private static Slider healthBar;
    private static Text   moneyText;
    private static Text   bulletsText;

    public static Player Player      { get { return player;      }}
    public static Slider HealthBar   { get { return healthBar;   }}
    public static Text   MoneyText   { get { return moneyText;   }}
    public static Text   BulletsText { get { return bulletsText; }}

    void Awake()
    {
        player       = GameObject.Find("Player Object").GetComponent<Player>();
        healthBar    = GameObject.Find("Health Bar").GetComponent<Slider>();
        moneyText    = GameObject.Find("Money Text").GetComponent<Text>();
        bulletsText  = GameObject.Find("Bullets Text").GetComponent<Text>();
    }
}
