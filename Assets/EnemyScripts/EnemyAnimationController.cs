using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    [SerializeField] private Animator enemyAnimator;
    [SerializeField] private string chaseAnimationName;
    [SerializeField] private string searchAnimationName;

    private void Start()
    {
        // Initialize the animator reference
        enemyAnimator = GetComponent<Animator>();
    }

    public void SetChaseAnimation()
    {
        // Play the chase animation
        enemyAnimator.Play(chaseAnimationName);
    }

    public void SetSearchAnimation()
    {
        // Play the search animation
        enemyAnimator.Play(searchAnimationName);
    }
}