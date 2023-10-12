using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

/// <summary>
/// The script that activates screen noise when an object tagged Enemy is nearby
/// </summary>
public class EnemyNoise : MonoBehaviour
{
    public float detectionRadius = 10f;
    [SerializeField]
    private VolumeProfile _globalVolumeProfile;
    private FilmGrain _grain;
    private int _layerMask;

    private void Start()
    {
        if (!_globalVolumeProfile.TryGet(out _grain)) throw new System.NullReferenceException(nameof(_grain));
        _layerMask = LayerMask.GetMask("Ghost");
    }

    private void FixedUpdate()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius, _layerMask);
        if (hitColliders.Length > 0)
        {
            _grain.active = true;
        }
        else
        {
            _grain.active = false;
        }
    }
}
