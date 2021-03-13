using System;
using UnityEngine;

namespace Pebble
{
    public class StageComponent<StageType, RendererType, DefinitionType> : MonoBehaviour
                                                                            where StageType : Stage, new()
                                                                            where RendererType : StageRenderer, new()
                                                                            where DefinitionType : StageDefinition
    {
        public DefinitionType ScreenDefinition;

        StageType stage = null;

        // Use this for initialization
        void Start()
        {
            stage = new StageType();
            if (stage != null)
            {
                stage.Init(ScreenDefinition, new RendererType());
                stage.Start();
            }

        }

        // Update is called once per frame
        void Update()
        {
            if (stage != null)
            {
                stage.Update();
            }
        }

        void OnGUI()
        {
            if (stage != null)
            {
                stage.UpdateGUI();
            }
        }

        public virtual void OnDestroy()
        {
            if (stage != null)
            {
                stage.Stop();
                stage.Shutdown();
            }
        }
    }
}
