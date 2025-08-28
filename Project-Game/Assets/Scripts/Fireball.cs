using UnityEngine;

public class Fireball : MonoBehaviour
{

    Animator animator;
    public DetectionZone fireballDetectionZone;

    public bool _hasTarget = false;

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
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        FireballCooldown -= Time.deltaTime;
        HasTarget = fireballDetectionZone.detectedColliders.Count > 0;
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
