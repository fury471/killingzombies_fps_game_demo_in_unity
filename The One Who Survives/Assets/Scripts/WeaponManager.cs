using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject rifle;
    public GameObject pistol;
    public GameObject knife;

    public GunShoot rifleGun;
    public GunShoot pistolGun;

    void Start()
    {
        ShowRifle();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ShowRifle();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            ShowPistol();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ShowKnife();
        }
    }

    public GunShoot GetActiveGun()
    {
        if (rifle.activeSelf)
        {
            return rifleGun;
        }

        if (pistol.activeSelf)
        {
            return pistolGun;
        }

        return null;
    }

    public string GetActiveWeaponName()
    {
        if (rifle.activeSelf)
        {
            return "Rifle";
        }

        if (pistol.activeSelf)
        {
            return "Pistol";
        }

        return "Knife";
    }

    void ShowRifle()
    {
        rifle.SetActive(true);
        pistol.SetActive(false);
        knife.SetActive(false);
    }

    void ShowPistol()
    {
        rifle.SetActive(false);
        pistol.SetActive(true);
        knife.SetActive(false);
    }

    void ShowKnife()
    {
        rifle.SetActive(false);
        pistol.SetActive(false);
        knife.SetActive(true);
    }
}
