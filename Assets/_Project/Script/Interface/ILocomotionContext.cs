using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILocomotionContext
{
    void SetState(ILocomotionState newState);
}
