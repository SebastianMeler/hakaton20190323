using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int pointsCoin;
    public ParticleSystem coinParticle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);

            var newcoinParticle = Instantiate(coinParticle,
                                              new Vector3(transform.position.x, transform.position.y, transform.position.z),
                                              Quaternion.identity);
        }
    }
}
