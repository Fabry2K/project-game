using UnityEngine;

public class Fireball : MonoBehaviour
{

    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Destroy(gameObject, 1.5f);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        FireballCooldown -= Time.deltaTime;
    }
    
    public float FireballCooldown
    {
        get
        {
            return animator.GetFloat(AnimationStrings.fireballCooldown);
        }

        private set
        {
            animator.SetFloat(AnimationStrings.fireballCooldown, Mathf.Max(value, 0));
        }
    }
}
