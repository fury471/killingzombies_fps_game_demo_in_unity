using UnityEngine;
using TMPro;

public class SimpleUI : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public WeaponManager weaponManager;
    public GameManager gameManager;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI ammoText;
    public TextMeshProUGUI medkitText;
    public TextMeshProUGUI objectiveText;
    public TextMeshProUGUI missionText;

    void Update()
    {
        healthText.text = "HP: " + playerHealth.currentHealth;
        medkitText.text = "Medkits: " + playerHealth.medkitCount;

        GunShoot activeGun = weaponManager.GetActiveGun();

        if (activeGun != null)
        {
            ammoText.text = "Ammo: " + activeGun.currentAmmo + " / " + activeGun.reserveAmmo;
        }
        else
        {
            ammoText.text = "Weapon: " + weaponManager.GetActiveWeaponName();
        }

        if (gameManager != null && objectiveText != null)
        {
            objectiveText.text =
                "Medicine: " + gameManager.collectedMedicines + "/" + gameManager.requiredMedicines +
                " | Files: " + gameManager.collectedFiles + "/" + gameManager.requiredFiles;
        }

        if (gameManager != null && missionText != null)
        {
            if (gameManager.HasAllObjectives())
            {
                missionText.text = "Objectives complete.\r\n Find the exit.\r\n(The door facing the statue.)";
            }
            else
            {
                missionText.text = "Search the Asylum for all medicines and files, then find the exit.\r\nThere are zombies you need to clean and no clue for you. \r\nBe cautious!\r\n";
            }
        }
    }
}
