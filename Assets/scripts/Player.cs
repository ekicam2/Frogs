using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    [Range (0, 999)]
    public float health;
    public GameObject[] weapons;
    public uint[] magazines;
    public uint money;

    private Weapon currWeapon;
    private Vector3 startMousePosition, deltaMousePosition;
    private Slider healthBar;

    void Start () {
        setCurrentWeapon(0);
        Cursor.lockState         = CursorLockMode.Confined;
        Cursor.visible           = false;
        health                   = 100.0f;
        money                    = 0;
        healthBar                = GodObject.HealthBar;
        startMousePosition       = Input.mousePosition;
        healthBar                = GodObject.HealthBar;
        healthBar.maxValue       = health;
        healthBar.value          = healthBar.maxValue;

        GodObject.MoneyText.text = money.ToString() + "$";
    }
	
	void Update () {
        if (health <= 0)
            die();

        if (currWeapon.type == Weapon.WeaponType.automatic)
        {
            if (Input.GetButton("Fire1"))
                currWeapon.shoot();
        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
                currWeapon.shoot();
        }


        checkForWeaponChange();
        moveWeapon();
	}

    void die()
    {
        //TOOD: camera nim and so
        Debug.Log("ur dead");
    }

    void moveWeapon()
    {
        if (!startMousePosition.Equals(Input.mousePosition))
        {
            deltaMousePosition = Input.mousePosition - startMousePosition;
        }

        currWeapon.transform.LookAt(new Vector3(deltaMousePosition.x
                                                , deltaMousePosition.y
                                                , 800.0f));
        deltaMousePosition = new Vector3();
    }

    void setCurrentWeapon(int index)
    {
        if(currWeapon != null)
            Destroy(currWeapon.gameObject);

        var instance = Instantiate<Weapon>(weapons[index].GetComponent<Weapon>());
        instance.transform.SetParent(GetComponent<Transform>());
        instance.transform.localPosition = new Vector3();
        currWeapon = instance;
    }

    void checkForWeaponChange()
    {
        int index = -1;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("1");
            index = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
            index = 1;

        if (Input.GetKeyDown(KeyCode.Alpha3))
            index = 2;

        if (index < weapons.Length && index > -1)
            setCurrentWeapon(index);
    }

    public void takeDamage(float damage)
    {
        var cameraAnimator = GetComponentInChildren<Camera>().GetComponent<Animator>();
        cameraAnimator.SetTrigger("gotHit");

        health -= damage;
        healthBar.value = health;
    }

    public void increaseMoney(uint amount)
    {
        money += amount;
        GodObject.MoneyText.text = money.ToString() + "$";
    }
}
