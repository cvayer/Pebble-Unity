using System;

//----------------------------------------------
//----------------------------------------------
// Screen
//----------------------------------------------
//----------------------------------------------
public abstract class Screen<RendererType> : IScreen where RendererType : IScreenRenderer, new()
{
    //----------------------------------------------
    // Variables
    private RendererType m_renderer;
    //----------------------------------------------
    // Properties

    public RendererType Renderer
    {
        get
        {
            return m_renderer;
        }
    }

    //----------------------------------------------
    // Methods

    public void Init()
    {
        m_renderer = new RendererType();
        OnInit();

        if (m_renderer != null)
        {
            m_renderer.Init();
        }
    }


    public void Start()
    {
        OnStart();

        if(m_renderer != null)
        {
            m_renderer.Start();
        }
    }

    public void Stop()
    {
        OnStop();

        if (m_renderer != null)
        {
            m_renderer.Stop();
        }
    }

    public void Shutdown()
    {
        if (m_renderer != null)
        {
            m_renderer.Shutdown();
        }

        OnShutdown();
    }

    // Update is called once per frame
    public void Update()
    {
        OnUpdate();

        if (m_renderer != null)
        {
            m_renderer.Update();
        }
    }

    public void UpdateGUI()
    {
        if (m_renderer != null)
        {
            m_renderer.UpdateGUI();
        }
    }

    protected abstract void OnInit();
    protected abstract void OnStart();
    protected abstract void OnStop();
    protected abstract void OnShutdown();
    protected abstract void OnUpdate();

}

