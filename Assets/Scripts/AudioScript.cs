using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public static AudioScript instance;

    [SerializeField] private AudioSource ammo, enemyDeath, enemyShot, gunshot, noAmmo, health, playerHurt;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayAmmoPickup()
    {
        ammo.Stop();
        ammo.Play();
    }
    public void PlayEnemyDeath()
    {
        enemyDeath.Stop();
        enemyDeath.Play();
    }

    public void PlayEnemyShot()
    {
        enemyShot.Stop();
        enemyShot.Play();
    }

    public void PlayGunShot()
    {
        gunshot.Stop();
        gunshot.Play();
    }

    public void PlayNoAmmo()
    {
        noAmmo.Stop();
        noAmmo.Play();
    }

    public void PlayHealthPickup()
    {
        health.Stop();
        health.Play();
    }

    public void PlayPlayerHurt()
    {
        playerHurt.Stop();
        playerHurt.Play();
    }
}
