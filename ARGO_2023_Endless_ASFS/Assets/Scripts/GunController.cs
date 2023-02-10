using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    /// <summary>
    /// Gun properties to make the gun unique 
    /// </summary>
    [Header("ObjectToPushBack")]
    public GameObject pushbackObj;
    [Header("GunProperties")]
    public float bulletSpeed;
    public float spread;
    public float reloadTime;
    public float timeBetweenShots;
    public float timeBetweenShooting;
    public int magazineSize;
    public int availableAmmo;
    private int ammoTakenToReload;
    public int bulletsPerTap;
    public bool allowButtonHold;
    public int bulletsLeft;
    int bulletsShot;
    Touch touch;
    //bools 
    //bool shooting;                
    bool readyToShoot;
    bool reloading;
    bool isRight;
    /// <summary>
    /// Firepots to make the gun not 100% accurate
    /// </summary>
    [Header("FirePoints")]
    public Transform fp1;
    /// <summary>
    /// Projectile of the weapon (bullet)
    /// </summary>
    [Header("Projectile")]
    public GameObject Projectile;
    [Header("Casings")]
    public GameObject muzzleFlash;
    public GameObject castings;
    public Transform castingPos;

    [Header("Audio")]
    public AudioSource audio;
    public AudioClip clip;

    [Header("Reload")]
    public GameObject rev6;
    public GameObject rev5;
    public GameObject rev4;
    public GameObject rev3;
    public GameObject rev2;
    public GameObject rev1;
    public GameObject rev0;






    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            //Debug.Log("Touching");

            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(touch.position);

            if (worldPosition.x > transform.position.x)
            {
                //  Debug.Log("right");
                isRight = true;
            }
            if (worldPosition.x < transform.position.x)
            {
                //Debug.Log("left");
                isRight = false;
            }

            MyInput();
        }



    }

    /// <summary>
    /// here we allow user of the gun to shoot, first it checks if we can hold the button of tap continiesly or not, we also check if the player reloaded or not
    /// we also are telling the gun how much bullets to spawn per tap
    /// </summary>
    private void MyInput()
    {
        //  if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        //  else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (bulletsLeft == 0 && !reloading && availableAmmo > 0)
        {
            Reload();
        }

        if (readyToShoot && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }
    }

    /// <summary>
    /// in this function we change the spread of the weapon, check for bullet amount and how many bullets are going out of the weapon, also we allow some time to pass between shots 
    /// </summary>
    private void Shoot()
    {
        readyToShoot = false;

        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        touchPosition.z = 0;

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector2 direction = new Vector3(x, y);
        GameObject bulletspawn = Instantiate(Projectile, fp1.position, fp1.rotation);
        Rigidbody2D rbBullet = bulletspawn.GetComponent<Rigidbody2D>();
        Vector2 shootDirection = (touchPosition - transform.position).normalized;
        shootDirection = shootDirection + direction;
        rbBullet.AddForce(shootDirection * bulletSpeed, ForceMode2D.Impulse);
        Destroy(bulletspawn, 2.0f);

        GameObject castingBullet = Instantiate(castings, castingPos.position, castingPos.rotation);
        Rigidbody2D rbCasting = castingBullet.GetComponent<Rigidbody2D>();
        rbCasting.AddForce(castingPos.up * -5, ForceMode2D.Impulse);
        Destroy(castingBullet, 20.0f);

        bulletsLeft--;
        bulletsShot--;
        muzzleBox();
        pushBack();
        Invoke("ResetShot", timeBetweenShooting);
        if (bulletsShot > 0 && bulletsLeft > 0)
        {
            Invoke("Shoot", timeBetweenShots);
            audio.PlayOneShot(clip, 1.5f);
        }

        clipUpdate();

    }

    /// <summary>
    /// just a reset of the function to be able to shoot 
    /// </summary>
    private void ResetShot() 
    {
        readyToShoot = true;
    }
    /// <summary>
    /// reloading with all the calculations necessary for the ammo
    /// </summary>
    private void Reload()
    {
        ammoTakenToReload = bulletsLeft - magazineSize;
        availableAmmo += ammoTakenToReload;
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }
    /// <summary>
    /// the realod making sure its taking correct amount of ammo to magazie when reloading
    /// </summary>
    private void ReloadFinished()
    {
        bulletsLeft -= ammoTakenToReload;
        reloading = false;
        rev6.SetActive(true);
        rev5.SetActive(false);
        rev4.SetActive(false);
        rev3.SetActive(false);
        rev2.SetActive(false);
        rev1.SetActive(false);
        rev0.SetActive(false);
    }
    private void muzzleBox()
    {
        GameObject particlespawn = Instantiate(muzzleFlash, fp1.position, fp1.rotation);
        Destroy(particlespawn, 0.1f);

    }

    private void pushBack()
    {
        if (isRight == true)
        {
            pushbackObj.transform.position -= new Vector3(0.07f, 0, 0);
            //  lookQuaternion = muzzleFlash.transform.rotation * Quaternion.AngleAxis(0, Vector2.up);
        }
        if (isRight == false)
        {
            pushbackObj.transform.position += new Vector3(0.07f, 0, 0);
            //lookQuaternion = muzzleFlash.transform.rotation * Quaternion.AngleAxis(0, Vector2.up);
        }
    }

    private void clipUpdate()
    {
        if (bulletsLeft == 6)
        { 
            rev6.SetActive(true);
            rev5.SetActive(false);
            rev4.SetActive(false);
            rev3.SetActive(false);
            rev2.SetActive(false);
            rev1.SetActive(false);
            rev0.SetActive(false);
        }
        if (bulletsLeft == 5)
        {
            rev6.SetActive(false);
            rev5.SetActive(true);
            rev4.SetActive(false);
            rev3.SetActive(false);
            rev2.SetActive(false);
            rev1.SetActive(false);
            rev0.SetActive(false);
        }
        if (bulletsLeft == 4)
        {
            rev6.SetActive(false);
            rev5.SetActive(false);
            rev4.SetActive(true);
            rev3.SetActive(false);
            rev2.SetActive(false);
            rev1.SetActive(false);
            rev0.SetActive(false);
        }
        if (bulletsLeft == 3)
        {
            rev6.SetActive(false);
            rev5.SetActive(false);
            rev4.SetActive(false);
            rev3.SetActive(true);
            rev2.SetActive(false);
            rev1.SetActive(false);
            rev0.SetActive(false);
        }
        if (bulletsLeft == 2)
        {
            rev6.SetActive(false);
            rev5.SetActive(false);
            rev4.SetActive(false);
            rev3.SetActive(false);
            rev2.SetActive(true);
            rev1.SetActive(false);
            rev0.SetActive(false);
        }
        if (bulletsLeft == 1)
        {
            rev6.SetActive(false);
            rev5.SetActive(false);
            rev4.SetActive(false);
            rev3.SetActive(false);
            rev2.SetActive(false);
            rev1.SetActive(true);
            rev0.SetActive(false);
        }
        if (bulletsLeft == 0)
        {
            rev6.SetActive(false);
            rev5.SetActive(false);
            rev4.SetActive(false);
            rev3.SetActive(false);
            rev2.SetActive(false);
            rev1.SetActive(false);
            rev0.SetActive(true);
        }
    }
}
