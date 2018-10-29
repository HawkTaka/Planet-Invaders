using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] public int HitPoints = 5;
    [SerializeField] ParticleSystem HitParticle;
    [SerializeField] ParticleSystem DeathParticle;

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        HitPoints--;
        HitParticle.Play();
        if (HitPoints <= 0)
        {
            DeathEffects();
            Destroy(gameObject);
        }
    }

    private void DeathEffects()
    {
        var deathFX = Instantiate(DeathParticle, transform.position, Quaternion.identity);
        deathFX.Play();
        float playtime = deathFX.main.duration;
        Destroy(deathFX.gameObject, playtime);
    }
}
