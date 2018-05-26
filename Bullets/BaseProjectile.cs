using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Code by Kaj loevesijn 2018
// hi!
public class BaseProjectile : MonoBehaviour
{
    //initializers
    [Header("Forward speed modifiers")]
    [SerializeField]
    protected float forwardVelocity;
    [SerializeField]
    protected float forwardVelocityModifier,
                    forwardProjectileSpeedMultiplier,
                    slowdownStrength,
                    speedUpStrength,
                    negativeForwardSpeedCap,
                    positiveForwardSpeedCap;

    [Header("Strafe speed modifiers")]
    [SerializeField]
    protected float sidewardsVelocity;
    [SerializeField]
    protected float sidewardsVelocityModifier,
                    sidewwardsMultiplier;

    [Header("Rotation modifiers")]
    [SerializeField]
    protected float rotationOverLifetime;
    [SerializeField]
    protected float rotationOverLifetimeMultiplier, maxRotationOverLifetime;

    [Header("Enable/disable Modifiers")]
    [SerializeField]
    protected bool sidewards;
    [SerializeField]
    protected bool forwards, slowdown, speedUp, rotation;



    //protecteds
    protected float _currentForwardsVelocity, _currentSidewardsVelocity;
    protected Vector2 _sidewardsVector;

    protected Vector3 _currentAngle;

    //modified during runtime, needs to be reset to the publics on awake
    protected float _forwardVelocity,
                    _forwardVelocityModifier,
                    _forwardProjectileSpeedMultiplier,
                    _slowdownStrength, _speedUpStrength,
                    _negativeForwardSpeedCap,
                    _positiveForwardSpeedCap;

    protected float _sidewardsVelocity,
                    _sidewardsVelocityModifier,
                    _sidewwardsMultiplier;

    protected bool _sidewards,
                    _forwards,
                    _slowdown,
                    _speedUp,
                    _rotation;

    protected float _rotationOverLifetime,
                    _rotationOverLifetimeMultiplier,
                    _maxRotationOverLifetime,
                    _rotationAddedOverLifetime;

    protected Vector2 _combinedVector;

    protected float deltaTime;

    protected virtual  void Start()
    {

    }

    protected virtual void Update()
    {
        deltaTime = Time.deltaTime;
        LFO();
        SimpleTranslate();
        UpdateProjectileVelocity();
        UpdateRotationOverLifetime();

    }

    // MOVES THE PROJECTILE FORWARD
    protected virtual void SimpleTranslate()
    {
        _combinedVector = (Vector2.up * deltaTime * _currentForwardsVelocity) + (Vector2.left * deltaTime * _currentSidewardsVelocity);
        transform.Translate(_combinedVector);
    }

    protected virtual void LFO()
    {
        if (_sidewards)
        {
            if (_currentSidewardsVelocity > _sidewardsVelocity)
            {
                _currentSidewardsVelocity = _sidewardsVelocity;
                _sidewardsVelocityModifier = -_sidewardsVelocityModifier;
            }
            else if (_currentSidewardsVelocity < -_sidewardsVelocity)
            {
                _currentSidewardsVelocity = -_sidewardsVelocity;
                _sidewardsVelocityModifier = -_sidewardsVelocityModifier;
            }
            _currentSidewardsVelocity += _sidewardsVelocityModifier * deltaTime;
            _sidewardsVelocity *= 1 + (_sidewwardsMultiplier * deltaTime);
        }
        if (_forwards)
        {
            if (_currentForwardsVelocity > _forwardVelocity)
            {
                _currentForwardsVelocity = _forwardVelocity;
                _forwardVelocityModifier = -_forwardVelocityModifier;
            }
            else if (_currentForwardsVelocity < _negativeForwardSpeedCap)
            {
                _currentForwardsVelocity = _negativeForwardSpeedCap;
                _forwardVelocityModifier = -_forwardVelocityModifier;

            }
            _currentForwardsVelocity += _forwardVelocityModifier * deltaTime;
        }
        else
        {
            _currentForwardsVelocity = _forwardVelocity;
        }
    }

    // MODIFIES THE PROJECTILE SPEED OVER TIME
    protected virtual void UpdateProjectileVelocity()
    {
        _forwardVelocity = _forwardVelocity * (1 + _forwardProjectileSpeedMultiplier * deltaTime);
        if (slowdown)
        {
            if (_forwardVelocity >= _negativeForwardSpeedCap && _slowdownStrength > 0)
            {
                _forwardVelocity -= deltaTime * -_slowdownStrength;
            }
        }
        if (_speedUp)
        {
            if (_forwardVelocity <= _positiveForwardSpeedCap && _speedUpStrength > 0)
            {
                _forwardVelocity += deltaTime * _speedUpStrength;
            }
        }
    }

    // SETS NEW ROTATION
    protected virtual void UpdateRotation()
    {
            transform.localRotation = Quaternion.Euler(_currentAngle);
    }

    // ROTATES OVER TIME
    protected virtual void UpdateRotationOverLifetime()
    {
        if (_rotationAddedOverLifetime < maxRotationOverLifetime && rotation)
        {
            float addedAngle = _rotationOverLifetime * deltaTime;
            _currentAngle.z += addedAngle;
            _rotationAddedOverLifetime += addedAngle;
            _rotationOverLifetime = _rotationOverLifetime * (1 + _rotationOverLifetimeMultiplier * deltaTime);
            UpdateRotation();
        }
    }

    public virtual void ResetProjectileVariables(Transform newPosition)
    {
        _currentSidewardsVelocity = 0;
        _sidewardsVector = new Vector2();
        _currentForwardsVelocity = 0;
        _forwardVelocity = forwardVelocity;
        _forwardVelocityModifier = forwardVelocityModifier;
        _forwardProjectileSpeedMultiplier = forwardProjectileSpeedMultiplier;
        _slowdownStrength = slowdownStrength;
        _speedUpStrength = speedUpStrength;
        _negativeForwardSpeedCap = negativeForwardSpeedCap;
        _positiveForwardSpeedCap = positiveForwardSpeedCap;
        _sidewardsVelocity = sidewardsVelocity;
        _sidewardsVelocityModifier = sidewardsVelocityModifier;
        _sidewwardsMultiplier = sidewwardsMultiplier;
        _sidewards = sidewards;
        _forwards = forwards;
        _rotation = rotation;
        _speedUp = speedUp;
        _slowdown = slowdown;
        _rotationOverLifetime = rotationOverLifetime;
        _rotationOverLifetimeMultiplier = rotationOverLifetimeMultiplier;
        _rotationAddedOverLifetime = 0;
        transform.rotation = newPosition.rotation;
        transform.position = newPosition.position;
        _currentAngle = transform.localRotation.eulerAngles;
        //Debug.Log(transform.position + " | " + gameObject.name);
    }
}
