using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestSubjectCode
{
    public interface ILocomotionContext
    {
        void SetState(ILocomotionState newState);
    }
}