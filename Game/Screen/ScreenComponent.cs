using System;
using UnityEngine;

public class ScreenComponent<ScreenType, RendererType, DefinitionType> : MonoBehaviour
                                                                            where ScreenType : Screen, new()
                                                                            where RendererType : ScreenRenderer, new()
                                                                            where DefinitionType : ScreenDefinition
{
    public DefinitionType ScreenDefinition;

    ScreenType screen = null;

    // Use this for initialization
    void Start()
    {
        screen = new ScreenType();
        if(screen != null)
        {
            screen.Init(ScreenDefinition, new RendererType());
            screen.Start();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (screen != null)
        {
            screen.Update();
        }
    }

    void OnGUI()
    {
        if (screen != null)
        {
            screen.UpdateGUI();
        }
    }

    public virtual void OnDestroy()
    {
        if (screen != null)
        {
            screen.Stop();
            screen.Shutdown();
        }
    }
}
