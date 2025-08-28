using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{

    public GameObject projectilePrefab;
    public Transform launchPoint;

    public void FireProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, launchPoint.position, projectilePrefab.transform.rotation);
        Vector3 origScale = projectile.transform.localScale;

        // Flip projectile based on player direction
        projectile.transform.localScale = new Vector3(
            origScale.x * (transform.localScale.x > 0 ? 1 : -1),
            origScale.y,
            origScale.z
            );
    }
}
