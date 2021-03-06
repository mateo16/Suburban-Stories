using UnityEngine;
using TMPro;

public class GunSystem : MonoBehaviour
{
    private KeyCode reloadingKey = KeyCode.R;

    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    public int bulletsLeft, bulletsShot;
    public Ammo Scriptammo;

    bool shooting, readyToShoot, reloading;

    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    public GameObject muzzleFlash;
    public GameObject muzzleFlashSchool;

    public GameObject bulletHoleGraphic;
    public GameObject bulletHoleGraphicSchool;

    public GameObject enemyImpact;

    public AudioClip reloadClip;

    public GameObject enemyImpactSchool;


    //public TextMeshProUGUI text;

    private void Start()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;

        fpsCam = (Camera)FindObjectOfType(typeof(Camera));
        Scriptammo = GameObject.Find("Hud").GetComponent<Ammo>();

    }

    private void Update()
    {
        MyInput();

        //text.SetText(bulletsLeft + " / " + magazineSize);
    }

    private void MyInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(reloadingKey) && bulletsLeft < magazineSize && !reloading) Reload();

        if(readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Scriptammo.ReduceAmmo();
            Shoot();
        }
    }

    private void Shoot()
    {
        readyToShoot = false;

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector3 direction = fpsCam.transform.forward + new Vector3(x,y,0);

        if (Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range, whatIsEnemy)){
            if (rayHit.collider.CompareTag("Enemy"))
            {
                rayHit.collider.GetComponent<EnemyDamage>().TakeDamage(damage);
                if (PauseMenu.schoolMode)
                {
                    Instantiate(enemyImpactSchool, rayHit.point, Quaternion.LookRotation(rayHit.normal));
                }
                else
                {
                    Instantiate(enemyImpact, rayHit.point, Quaternion.LookRotation(rayHit.normal));
                }
                
            }
            else
            {
                if (PauseMenu.schoolMode)
                {
                    Instantiate(bulletHoleGraphicSchool, rayHit.point, Quaternion.LookRotation(rayHit.normal));
                }
                else
                {
                    Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.LookRotation(rayHit.normal));
                }

                
            }

        }

        if (PauseMenu.schoolMode)
        {
            Instantiate(muzzleFlashSchool, attackPoint.position, Quaternion.identity);
        }
        else {
            Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);
        }

        

        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", timeBetweenShooting);

        if(bulletsShot > 0 && bulletsLeft > 0)
        {
            Invoke("Shoot", timeBetweenShots);
        }
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }

    private void Reload()
    {
        reloading = true;
        
        Invoke("ReloadFinished", reloadTime);
    }
    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        Scriptammo.RestartAmmo(magazineSize);
        reloading = false;
    }
}
