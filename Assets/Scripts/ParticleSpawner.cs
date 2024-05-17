using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{

    [SerializeField] private GameObject _impactPointParticles;
    [SerializeField] private GameObject _sparyParticles;
    [SerializeField] private float _particleOffsetDistance = 0.0f;

    private CapsuleCollider2D _capsuleCollider;
    // Start is called before the first frame update
    private void Awake()
    {
        _capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    public void SpawnImpactParticles(Vector3 SpawnPoint, Vector3 dir)
    {
        Quaternion rot = Quaternion.FromToRotation(Vector3.right, -dir);
        Instantiate(_impactPointParticles, SpawnPoint, rot);
    }
}
