using UnityEngine;
using UnityEngine.UI;

public class FallBarController : MonoBehaviour
{
    [SerializeField] private Image fallBar;
    [SerializeField] private float maxFallTime = 10f; // seconds to fill bar

    private float fallTimer = 0f;
    private bool isFalling = false;

    void Update()
    {
        if (isFalling)
        {
            fallTimer += Time.deltaTime;
            float fill = Mathf.Clamp01(fallTimer / maxFallTime);
            fallBar.fillAmount = fill;
        }
    }

    public void StartFalling()
    {
        isFalling = true;
    }

    public void StopFalling()
    {
        isFalling = false;
    }

    public void ResetFallBar()
    {
        fallTimer = 0f;
        fallBar.fillAmount = 0f;
    }
}