using System;

public interface IScreen
{
    void Init();
    void Start();
    void Stop();
    void Shutdown();
    void Update();
    void UpdateGUI();
}

