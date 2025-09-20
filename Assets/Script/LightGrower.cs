using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightGrower : MonoBehaviour
{
    public Light2D playerLight;
    public float intensityPerOrb = 0.2f;
    public float falloffPerOrb = 0.3f;
    public float maxIntensity = 3f;
    public float maxFalloff = 5f;

    private void Awake()
    {
        if (playerLight == null)
            playerLight = GetComponent<Light2D>();
    }

    public void AbsorbLight()
    {
          // 밝기 증가
        playerLight.intensity = Mathf.Min(playerLight.intensity + intensityPerOrb, maxIntensity);

        // 범위 증가 (Falloff 값 줄수록 넓어짐)
        playerLight.shapeLightFalloffSize = Mathf.Min(playerLight.shapeLightFalloffSize + falloffPerOrb, maxFalloff);
    }


}
