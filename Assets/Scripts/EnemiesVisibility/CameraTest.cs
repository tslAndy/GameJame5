using System;
using UnityEngine;

namespace EnemiesVisibility
{
    public class CameraTest : MonoBehaviour
    {
        [SerializeField] private InvisibleEnemyCamera invisibleEnemyCamera;

        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
                invisibleEnemyCamera.TurnOnEnemiesVisibility();
            else if (Input.GetButtonDown("Fire2"))
                invisibleEnemyCamera.TurnOffEnemiesVisibility();
        }
    }
}
