using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class PixelatedEffect : MonoBehaviour
{
    public Shader pixelatedShader;
    private Material pixelatedMaterial;
    public int pixelationAmount = 100;

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (pixelatedShader != null)
        {
            if (pixelatedMaterial == null)
            {
                pixelatedMaterial = new Material(pixelatedShader);
                pixelatedMaterial.hideFlags = HideFlags.HideAndDontSave;
            }
            pixelatedMaterial.SetInt("_PixelationAmount", pixelationAmount);
            Graphics.Blit(source, destination, pixelatedMaterial);
        }
        else
        {
            Graphics.Blit(source, destination);
        }
    }
}
