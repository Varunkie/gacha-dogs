using System;
using UnityEngine;

/// <summary>
/// Suspends the coroutine execution until currently triggered animation clip in the supplied animator evaluates to true.
/// </summary>
public sealed class WaitForCondition : CustomYieldInstruction
{
    private const float TIMEOUT = 10000f;

    private Func<bool> _property;
    private float _duration;
    private float _start;

    public override bool keepWaiting
    {
        get
        {
            if (_property() && Time.time - _start < _duration)
            {
                return true;
            }
            return false;
        }
    }

    /// <summary>
    /// Creates a yield instruction to wait until currently property is false or the time is out.
    /// </summary>
    /// <param name="property">Property to listen.</param>
    /// <param name="timeout">Duration in seconds.</param>
    public WaitForCondition(Func<bool> property, float timeout)
    {
        _property = property;
        _duration = timeout;
        _start = Time.time;
    }

    /// <summary>
    /// Creates a yield instruction to wait until currently property is true or the duration is finished.
    /// </summary>
    /// <param name="property">Property to listen.</param>
    public WaitForCondition(Func<bool> property)
        : this (property, TIMEOUT)
    { }
}