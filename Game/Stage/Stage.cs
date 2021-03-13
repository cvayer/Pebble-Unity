using System;

//----------------------------------------------
//----------------------------------------------
// Stage
//----------------------------------------------
//----------------------------------------------

namespace Pebble
{
    public abstract class Stage
    {
        //----------------------------------------------
        // Variables

        private StageRenderer m_renderer;
        private StageDefinition m_definition;

        //----------------------------------------------
        // Properties

        public StageRenderer Renderer
        {
            /* You can override this property in your base class for easy access : 

           public new MyRenderer Renderer
           {
               get 
               { 
                   return base.Renderer as MyRenderer;
               }
           } */

            get { return m_renderer; }
        }

        public StageDefinition Definition
        {
            /* You can override this property in your base class for easy access : 

            public new MyDefinition Definition
            {
                get 
                { 
                    return base.Definition as MyDefinition;
                }
            } */
            get { return m_definition; }
        }

        //----------------------------------------------
        // Methods

        public void Init(StageDefinition definition, StageRenderer renderer)
        {
            m_renderer = renderer;
            m_definition = definition;

            OnInit();

            if (m_renderer != null)
            {
                m_renderer.SetStage(this);
                m_renderer.Init();
            }
        }


        public void Start()
        {
            OnStart();

            if (m_renderer != null)
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
}

