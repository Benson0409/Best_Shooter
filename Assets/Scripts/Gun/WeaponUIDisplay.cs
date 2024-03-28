using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class WeaponUIDisplay : MonoBehaviour
{
    [Header("UI 顯示")]
    public GameObject weaponPanel;
    public Image weaponImage;
    public TMP_Text currentAmmoCountText;


    [Header("當前彈藥")]
    private int currentAmmo;

    void Update()
    {
        UIDisplay();
    }

    private void UIDisplay()
    {

        weaponPanel.SetActive(true);
        currentAmmoCountText.text = currentAmmo.ToString();
    }

    public void GetCurrentWeaponInformation(int ammoCount)
    {
        currentAmmo = ammoCount;
    }
}
