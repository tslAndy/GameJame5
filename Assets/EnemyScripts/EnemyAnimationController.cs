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
        // Play the chase animation without looping
        enemyAnimator.Play(chaseAnimationName);
    }

    public void SetSearchAnimation()
    {
        // Play the search animation and set it to loop
        enemyAnimator.Play(searchAnimationName);
        enemyAnimator.SetBool("IsSearching", true); // Assuming you have a parameter to control looping in your Animator
    }

    public void StopSearchAnimation()
    {
        // Stop looping the search animation
        enemyAnimator.SetBool("IsSearching", false);
    }
}
