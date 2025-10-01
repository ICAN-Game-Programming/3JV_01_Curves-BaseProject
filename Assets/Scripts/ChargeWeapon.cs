using UnityEngine;

public class ChargeWeapon : MonoBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _launchTransform;
    [SerializeField] private float _launchForce = 10f;
    [SerializeField] private float _projectileLifetime = 5f;

    //➡️ todo : add charge properties
    //...

    private void Awake()
    {
        //Ignore self layer collision (Player projectiles and player)
        int playerLayer = LayerMask.NameToLayer("Player");
        Physics.IgnoreLayerCollision(playerLayer, playerLayer);
    }

    private void Update()
    {
        //➡️ todo : Charge instead
        //Display a charge feedback (feedback scaling up)
        //On release, instantiate the projectile at the correct size and launch it.
        //Size and speed are relatiuve to charge ratio.
        //Charge must clamp at a max amount.
        
        if (Input.GetButtonDown("Fire1"))
        {
            FireProjectile();
        }
    }

    private void FireProjectile()
    {
        GameObject newProj = Instantiate(_projectilePrefab, _launchTransform.position, _launchTransform.rotation);
        newProj.GetComponent<Rigidbody>().AddForce(_launchTransform.forward * _launchForce, ForceMode.Impulse);
        Destroy(newProj, _projectileLifetime);
    }
}
