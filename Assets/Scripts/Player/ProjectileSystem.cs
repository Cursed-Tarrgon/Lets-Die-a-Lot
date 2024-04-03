using System.Collections;
using UnityEngine;

public class ProjectileSystem : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject Player;
    [SerializeField] private FirstPersonController firstPersonController;
    [SerializeField] private GameObject cameraHolder;
    [SerializeField] private Camera cameraComp;
    [SerializeField] private Transform attackPoint;

    [Header("Gun Stats")]
    public string weaponName;
    [SerializeField] private GameObject projectile;
    [SerializeField] public float forwardForce;
    [SerializeField] public float upwardForce;
    [SerializeField] public float damage;
    [SerializeField] public float firerate;
    [SerializeField] private float range;
    [SerializeField] public float spread;
    [SerializeField] public float reloadTime;
    [SerializeField] public int currentClipSize;
    [SerializeField] public int maxClipSize;
    [SerializeField] public int currentAmmoSize;
    [SerializeField] public int maxAmmoSize;
    [SerializeField] public int bulletsPerTap;
    private Coroutine reloadRoutine;
    public int bulletsShot;
    public bool shooting;
    public bool readyToShoot;
    public bool shouldReload;
    public bool reloading;
    public bool cancelReload;
    public bool isGun;

    private void Start()
    {
        if (GameStateManager.Instance.fpcGun == null)
        {
            GameStateManager.Instance.fpcGun = this;
        }

        readyToShoot = true;
        currentAmmoSize = maxAmmoSize;
        currentClipSize = maxClipSize;
    }

    private void Update()
    {
        if (shooting)
        {
            Shooting();
        }

        if (shouldReload)
        {
            if (reloadRoutine == null && (currentClipSize < maxClipSize || currentAmmoSize != 0))
            {
                cancelReload = false;
                reloading = true;

                reloadRoutine = StartCoroutine(ToggelReload());
            }
            else if (reloadRoutine != null)
            {
                return;
            }
        }
        else if (reloadRoutine == null && currentClipSize == 0 && currentAmmoSize != 0)
        {
            cancelReload = false;
            reloading = true;

            reloadRoutine = StartCoroutine(ToggelReload());
        }

        if (cancelReload)
        {
            ReloadCancel();
        }
    }

    private void Shooting()
    {
        if (isGun)
        {
            if (readyToShoot && (!shouldReload || !reloading))
            {
                if (currentClipSize > 0 && (!shouldReload || !reloading))
                {
                    Ray ray = cameraComp.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
                    RaycastHit hit;
                    Vector3 targetPoint;

                    if (Physics.Raycast(ray, out hit, range))
                    {
                        targetPoint = hit.point;
                    }
                    else
                    {
                        targetPoint = ray.GetPoint(range);
                    }

                    for (int i = 0; i < bulletsPerTap; i++)
                    {
                        bulletsShot++;

                        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

                        float x = Random.Range(-spread, spread);
                        float y = Random.Range(-spread, spread);

                        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);

                        GameObject currentProjectile = Instantiate(projectile, attackPoint.position, cameraHolder.transform.rotation);

                        currentProjectile.transform.forward = directionWithSpread;

                        currentProjectile.GetComponent<Projectiles>().damage = damage;

                        currentProjectile.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * forwardForce, ForceMode.Impulse);
                        currentProjectile.GetComponent<Rigidbody>().AddForce(transform.up * upwardForce, ForceMode.Impulse);
                    }

                    readyToShoot = false;

                    if (shooting)
                    {
                        Invoke(nameof(ResetShot), firerate);
                    }

                    currentClipSize -= bulletsPerTap;
                }
                else if (currentClipSize == 0)
                {
                    shouldReload = true;
                }
            }
        }
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }

    private void ReloadFinished()
    {
        int reloadAmount = maxClipSize - currentClipSize;
        reloadAmount = (currentAmmoSize - reloadAmount) >= 0 ? reloadAmount : currentAmmoSize;
        currentClipSize += reloadAmount;
        currentAmmoSize -= reloadAmount;

        if (reloadRoutine != null)
        {
            StopCoroutine(reloadRoutine);

            reloadRoutine = null;

            reloading = false;
            shouldReload = false;
        }
    }

    public void ReloadCancel()
    {
        if (reloadRoutine != null)
        {
            reloading = false;
            shouldReload = false;

            StopCoroutine(reloadRoutine);

            reloadRoutine = null;

            cancelReload = false;
        }
    }

    public void PickUpAmmo()
    {
        currentAmmoSize = maxAmmoSize;
        currentClipSize = maxClipSize;
    }

    private IEnumerator ToggelReload()
    {
        yield return new WaitForSeconds(reloadTime);

        ReloadFinished();
    }
}
