using UnityEngine;

public class LockedBlockController : MonoBehaviour
{
    [SerializeField] private LockRelease lockRelease;
    [SerializeField] private SpriteRenderer lockedBlockSpriteRenderer;
    [SerializeField] private PlayerController playerController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        playerController.SetTargeted(true, lockedBlockSpriteRenderer);
        lockRelease.CheckLockRelease(lockedBlockSpriteRenderer);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        playerController.SetTargeted(false, lockedBlockSpriteRenderer);
        lockRelease.CheckLockRelease(lockedBlockSpriteRenderer);
    }
}
