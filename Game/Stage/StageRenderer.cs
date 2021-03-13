using System;
using UnityEngine;

//-------------------------------------------------------
//-------------------------------------------------------
// ScreenRenderer
//-------------------------------------------------------
//-------------------------------------------------------

namespace Pebble
{
    public abstract class StageRenderer
    {
        //----------------------------------------------
        // Variables
        private Stage m_stage;

        //----------------------------------------------
        // Properties

        public Stage Stage
        {
            /* You can override this property in your base class for easy access : 

            public new MyScreen Stage
            {
                get 
                { 
                    return base.Stage as MyScreen;
                }
            } */
            get
            {
                return m_stage;
            }
        }

        //----------------------------------------------
        // Methods
        //-------------------------------------------------------
        public StageRenderer()
        {

        }

        //-------------------------------------------------------
        public void SetStage(Stage stage)
        {
            m_stage = stage;
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

}
