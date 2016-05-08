/*using UnityEngine;
using System.Collections;

public class pistol_controller : MonoBehaviour
{
    Animator anim;
    int reloadHash = Animator.StringToHash("Reload");
    AudioSource audio;
    public int ammo = 60;
    public int maxBullets = 30;
    public int bullets;
    float nextShot;
    public Transform bulletSpawn;
    public Transform projectile;
    public Transform bulletHole;
    public float bulletSpeed = 50.0f;
    public float nextShotTime = 0.15f;
    float nextReload;
    float reloadTime = 2.0f;
    // Use this for initialization
    void Start()
    {
        //Get animator for reloading
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        //Set nextshot and nextreload timers
        nextShot = Time.fixedTime + nextShotTime;
        nextReload = Time.fixedTime;
        bullets = maxBullets;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);
        if (Input.GetKey(KeyCode.Mouse0) && Time.fixedTime >= nextShot && bullets > 0 && Time.fixedTime >= nextReload)
        {
            shoot();
        }
        //If clip has less than maxBullets then reload
        if (Input.GetKey(KeyCode.R) && bullets < maxBullets && ammo > 0 && Time.fixedTime >= nextReload)
        {
            reload();
        }
    }

    void reload()
    {
        //Delay nextReload so player can't continue firing or initiate another reload
        nextReload = Time.fixedTime + reloadTime;
        anim.SetBool(reloadHash, true);
        if (ammo + bullets < maxBullets)
        {
            bullets += ammo;
            ammo = 0;
        }
        else
        {
            ammo -= maxBullets - bullets;
            bullets = maxBullets;
        }
    }

    void shoot()
    {
        //Create bullet game object
        GameObject obj = Instantiate(projectile.gameObject, bulletSpawn.position, bulletSpawn.rotation) as GameObject;
        //Get rigidbody from bullet so we can apply force/move it around realistically
        Rigidbody clone = obj.GetComponent<Rigidbody>();
        //Play shooting sound
        audio.Play();
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 1000.0f))
        {
            Debug.DrawLine(ray.origin, hit.point);
            Quaternion bulletHoleRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
            Instantiate(bulletHole, hit.point, bulletHoleRotation);
        }
        //Apply force up y-axis (green axis)
        clone.AddForce(clone.transform.up * bulletSpeed);
        bullets--;
        nextShot = Time.fixedTime + nextShotTime;
    }
}
*/