using System;
using UnityEngine;

//-------------------------------------------------------
//-------------------------------------------------------
// Turn
//-------------------------------------------------------
//-------------------------------------------------------
public class Turn
{
    public enum State
    {
        None,
        Started,
        Stopped
    }

    public class StateEvent : PooledEvent
    {
        private Turn m_turn = null;

        public override void Reset()
        {
            m_turn = null;
        }

        public void Init(Turn turn)
        {
            m_turn = turn;
        }

        public Turn Turn
        {
            get
            {
                return m_turn;
            }
        }
    }

    //----------------------------------------------
    // Variables
    State   m_state = State.None;
    Player  m_player;

    public Player Player
    {
        get
        {
            return m_player;
        }
    }

    public bool IsStopped
    {
        get
        {
            return m_state == State.Stopped;
        }
    }

    public bool IsStarted
    {
        get
        {
            return m_state == State.Started;
        }
    }

    //----------------------------------------------
    // Methods

    //--------------------------------------------------------------------
    public Turn()
    {

    }

    //--------------------------------------------------------------------
    public void Start()
    {
        ChangeState(State.Started);
    }

    //--------------------------------------------------------------------
    public void Stop()
    {
        ChangeState(State.Stopped);
    }

    //--------------------------------------------------------------------
    public void Init(Player player)
    {
        m_player = player;
        EventManager.Subscribe<EndTurnButtonClicked>(this.OnEndTurnButtonPressed);
    }

    //--------------------------------------------------------------------
    public void Shutdown()
    {
        m_state = State.None;
        EventManager.UnSubscribe<EndTurnButtonClicked>(this.OnEndTurnButtonPressed);
        OnShutdown();
    }

    //--------------------------------------------------------------------
    protected virtual void OnShutdown()
    {

    }

    //--------------------------------------------------------------------
    private void ChangeState(State newState)
    {
        if (newState != m_state)
        {
            m_state = newState;

            StateEvent evt = Pools.Claim<StateEvent>();
            evt.Init(this);
            EventManager.SendEvent(evt);
        }
    }

    private void OnEndTurnButtonPressed(EndTurnButtonClicked evt)
    {
        Stop();
    }
}
