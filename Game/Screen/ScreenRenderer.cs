using System;
using UnityEngine;

//-------------------------------------------------------
//-------------------------------------------------------
// ScreenRenderer
//-------------------------------------------------------
//-------------------------------------------------------
public abstract class ScreenRenderer
{
    //----------------------------------------------
    // Variables
    private Screen m_screen;
 
    //----------------------------------------------
    // Properties

    public Screen Screen
    { 
        /* You can override this property in your base class for easy access : 

        public new MyScreen Screen
        {
            get 
            { 
                return base.Screen as MyScreen;
            }
        } */
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
    public void SetScreen(Screen screen)
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

