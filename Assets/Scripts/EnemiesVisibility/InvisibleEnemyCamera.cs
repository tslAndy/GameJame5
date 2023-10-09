using System;
using UnityEngine;

namespace EnemiesVisibility
{
    public class InvisibleEnemyCamera : MonoBehaviour
    {
        [SerializeField] private LayerMask layerMaskWithEnemy;
        [SerializeField] private LayerMask layerMaskWithoutEnemy;

        private Camera _cam;

        private void Awake() => _cam = GetComponent<Camera>();

        public void TurnOnEnemiesVisibility() => _cam.cullingMask = layerMaskWithEnemy;
        public void TurnOffEnemiesVisibility() => _cam.cullingMask = layerMaskWithoutEnemy;
    }
}
