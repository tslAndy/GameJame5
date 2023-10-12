using UnityEngine;

public class CollisionAnimator: MonoBehaviour
{
    [SerializeField] private EnemyAnimationController animationController;

    private void Start()
    {
        animationController = GetComponent<EnemyAnimationController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collision is with the player or another object you want to chase
        if (other.CompareTag("Player")) // Adjust the tag or criteria as needed
        {
            // Trigger the "chase" animation
            animationController.SetChaseAnimation();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the collision is with the player or another object you want to chase
        if (other.CompareTag("Player")) // Adjust the tag or criteria as needed
        {
            // Trigger the "chase" animation
            animationController.SetSearchAnimation();
        }
    }
}
