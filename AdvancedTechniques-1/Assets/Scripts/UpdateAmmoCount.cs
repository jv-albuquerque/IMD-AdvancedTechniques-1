using UnityEngine;
using TMPro;

public class UpdateAmmoCount : MonoBehaviour
{
    private TextMeshProUGUI ammoTxt;

    public delegate void SetAmmoCount(int ammo);
    public SetAmmoCount setAmmoCount;

    public static UpdateAmmoCount instance;

    private void Awake()
    {
        if (instance)
            Destroy(gameObject);
        instance = this;

        ammoTxt = GetComponent<TextMeshProUGUI>();

        setAmmoCount = SetAmmo;
    }

    public void SetAmmo(int ammo)
    {
        ammoTxt.text = ammo.ToString();
    }

}
