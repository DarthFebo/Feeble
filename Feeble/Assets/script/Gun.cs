using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform spawn;
    public float _reloadTime = 2;
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private float bulletModifier;
    //public AudioSource bulletImpact;
    void Start()
    {
        bulletSpeed *= bulletModifier;
    }

    // Update is called once per frame
    void Update()
    {
        _reloadTime = Reload(_reloadTime);

        if (Reload(_reloadTime) < 0)
            StartCoroutine(Shoot());
    }

    /// <summary>
    /// Shoots this weapon;
    /// </summary>
    /// <returns></returns>
    private IEnumerator Shoot()
    {
        //bulletImpact.Play();
        GameObject go = (GameObject)Instantiate(bullet, spawn.position, spawn.rotation);
        go.GetComponent<Rigidbody>().AddForce(go.transform.forward * bulletSpeed * Time.deltaTime);
        _reloadTime = 2f;
        yield return new WaitForSeconds(5);
     //   Destroy(go);
    }

    /// <summary>
    /// Reloads the specified time.
    /// </summary>
    /// <param name="time">The time.</param>
    /// <returns></returns>
    private float Reload(float time)
    {
        return time - Time.deltaTime;
    }
}
