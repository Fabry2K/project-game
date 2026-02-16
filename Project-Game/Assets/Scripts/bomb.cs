using UnityEngine;

public class bomb : MonoBehaviour
{

    Animator animator;
    public DetectionZone bombDetectionZone;

    public bool _hasTarget = false;

    Rigidbody2D rb;

    public bool HasTarget
    {
        get
        {
            return _hasTarget;
        }

        private set
        {
            _hasTarget = value;
            animator.SetBool(AnimationStrings.hasTarget, value);
        }
    }

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        BombCooldown -= Time.deltaTime;
        HasTarget = bombDetectionZone.detectedColliders.Count > 0;

        if (BombCooldown == 0 || HasTarget)
        {
            rb.linearVelocity = new Vector2(0, 0);
        }
    }

    public float BombCooldown
    {
        get
        {
            return animator.GetFloat(AnimationStrings.bombCooldown);
        }

        private set
        {
            animator.SetFloat(AnimationStrings.bombCooldown, Mathf.Max(value, 0));
        }
    }
}
