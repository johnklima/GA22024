using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightObject : MonoBehaviour
{

    new Renderer renderer; // new hides the parent <renderer> property. i need to know why
    Material material;
    Color emissionColor;

    // Start is called before the first frame update
    void Start()
    {
        // Gets access to the renderer and material components as we need to
        // modify them during runtime.
        renderer = GetComponent<Renderer>();
        material = renderer.material;

        // Gets the initial emission colour of the material, as we have to store
        // the information before turning off the light.
        emissionColor = material.GetColor("_EmissionColor");


    }


    public void Highlight(bool enable, float intensity)
    {
        if (enable)
        {
            // Enables emission for the material, and make the material use
            // realtime emission.
            material.EnableKeyword("_EMISSION");
            material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;

            // Update the emission color and intensity of the material.
            material.SetColor("_EmissionColor", emissionColor * intensity);

            // Makes the renderer update the emission and albedo maps of our material.
            RendererExtensions.UpdateGIMaterials(renderer);

            // Inform Unity's GI system to recalculate GI based on the new emission map.
            DynamicGI.SetEmissive(renderer, emissionColor * intensity);
            DynamicGI.UpdateEnvironment();
        }
        else
        {
            material.DisableKeyword("_EMISSION");
            material.globalIlluminationFlags = MaterialGlobalIlluminationFlags.EmissiveIsBlack;

            material.SetColor("_EmissionColor", Color.black);
            RendererExtensions.UpdateGIMaterials(renderer);

            DynamicGI.SetEmissive(renderer, Color.black);
            DynamicGI.UpdateEnvironment();
        }

    }

}
