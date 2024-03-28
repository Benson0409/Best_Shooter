using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using RhythmGame;
public class Weapon : MonoBehaviour
{
    PlayerController playerController;
    //武器射擊控制
    public Camera mainCamera;

    [Header("子彈資訊")]
    //一發彈夾有幾發子彈
    public int ammoCount;
    private int currentBulletCount = 0;
    //裝彈時間
    public float reloadTime;
    private float delayReloadTime;

    [Header("射擊距離")]
    public float shootRange = math.INFINITY;

    [Header("射擊效果")]
    public ParticleSystem gunFireEffect;
    public GameObject hitEffect;

    [Header("槍枝連射設定")]
    bool canShoot = true;
    //每發子彈間隔時常
    public float shootTime = 0.15f;

    void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        delayReloadTime = reloadTime;
        mainCamera = Camera.main;
        currentBulletCount = ammoCount;
    }

    void Update()
    {
        //子彈數量
        BulletCount();
        GetWeaponInformation();
        if (Input.GetMouseButtonUp(0))
        {
            canShoot = true;
            return;
        }

        if (Input.GetMouseButton(0) && canShoot)
        {
            StartCoroutine(Shooting());
        }
    }

    private void BulletCount()
    {
        //填充子彈
        if (currentBulletCount == 0)
        {
            if (delayReloadTime < 0.01f)
            {
                currentBulletCount += ammoCount;
                delayReloadTime = reloadTime;
                print("補充子彈");
            }
            else
            {
                delayReloadTime -= Time.deltaTime;
            }
        }
    }

    IEnumerator Shooting()
    {
        canShoot = false;
        if (currentBulletCount > 0)
        {
            ShootingEffect();
            ShootingRaycast();
            currentBulletCount--;
        }
        yield return new WaitForSeconds(shootTime);
        canShoot = true;
    }

    //射擊時的槍枝特效
    private void ShootingEffect()
    {
        gunFireEffect.Play();
    }

    //射擊判斷
    private void ShootingRaycast()
    {
        RaycastHit hit;
        //判斷是否有回傳值,這樣就不會因為照射到空物件而出現錯誤
        if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit, shootRange))
        {
            //HitEffect(hit);
            if (hit.transform.tag == "Note")
            {
                playerController.HitNote(hit.transform.gameObject);
            }
        }
    }

    //擊中物體後的特效
    private void HitEffect(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        //生成特效在時間過後被催毀
        Destroy(impact, 0.1f);
    }


    public void GetWeaponInformation()
    {
        WeaponUIDisplay weaponUI = FindObjectOfType<WeaponUIDisplay>();
        weaponUI.GetCurrentWeaponInformation(currentBulletCount);
    }
}
