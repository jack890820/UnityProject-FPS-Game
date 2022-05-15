using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotionStatePattern : MonoBehaviour, ILocomotionContext
{
    ILocomotionState currentState = new GroundedState();
    public void Crouch() => currentState.Crouch(this);

    public void Fall() => currentState.Fall(this);

    public void Jump()
    {
        currentState.Jump(this);
        Debug.Log("Jump");
    }

    public void Land() => currentState.Land(this);

    void ILocomotionContext.SetState(ILocomotionState newState)
    {
        currentState = newState;
    }    
}

public class GroundedState : ILocomotionState
{
    public void Crouch(ILocomotionContext context)
    {
        context.SetState(new CrouchingState());
    }
    public void Fall(ILocomotionContext context)
    {
        context.SetState(new InAirState());
    }
    public void Jump(ILocomotionContext context)
    {
        context.SetState(new InAirState());
        Debug.Log("GroundedState Jump");
    }
    public void Land(ILocomotionContext context)
    {
    }
}

public class CrouchingState : ILocomotionState
{
    public void Crouch(ILocomotionContext context)
    {
        context.SetState(new GroundedState());
    }
    public void Fall(ILocomotionContext context)
    {
        context.SetState(new InAirState());        
    }
    public void Jump(ILocomotionContext context)
    {
        context.SetState(new GroundedState());
    }
    public void Land(ILocomotionContext context)
    {
    }
}

public class InAirState : ILocomotionState
{
    public void Crouch(ILocomotionContext context)
    {
    }
    public void Fall(ILocomotionContext context)
    {
    }
    public void Jump(ILocomotionContext context)
    {
    }
    public void Land(ILocomotionContext context)
    {
        context.SetState(new GroundedState());
        Debug.Log("InAirState Land");
    }
}