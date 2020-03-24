using System;
using UnityEngine;

//-------------------------------------------------------
//-------------------------------------------------------
// ScreenRenderer
//-------------------------------------------------------
//-------------------------------------------------------
public abstract class ScreenRenderer<ScreenType> : IScreenRenderer where ScreenType : IScreen
{
    //----------------------------------------------
    // Variables
    private ScreenType m_screen;

    //----------------------------------------------
    // Properties

    public ScreenType Screen
    {
        get
        {
            return m_screen;
        }
    }

    //----------------------------------------------
    // Methods
    //-------------------------------------------------------
    public ScreenRenderer()
    {

    }

    //-------------------------------------------------------
    public void SetScreen(ScreenType screen)
    {
        m_screen = screen;
    }

    public void Init()
    {
        OnInit();
    }

    public void Start()
    {
        OnStart();
    }

    public void Stop()
    {
        OnStop();
    }

    public void Shutdown()
    {
        OnShutdown();
    }

    public void Update()
    {
        OnUpdate();
    }

    public void UpdateGUI()
    {
        OnUpdateGUI();
    }

    protected abstract void OnInit();
    protected abstract void OnStart();
    protected abstract void OnStop();
    protected abstract void OnShutdown();
    protected abstract void OnUpdate();
    protected abstract void OnUpdateGUI();
}

