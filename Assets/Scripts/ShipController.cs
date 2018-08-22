﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

enum CommonAxis
{
    Horizontal,
    Vertical
}

public class ShipController : MonoBehaviour
{
    [Tooltip("In m/s")]
    [SerializeField]
    Vector2 Speed = new Vector2(4, 4);

    [SerializeField]
    Vector2 Range = new Vector2(5, 5);

    [SerializeField]
    float pitchFactor = -5f;

    [SerializeField]
    float controlPitchFactor = -25f;

    [SerializeField]
    float yawFactor = 5f;

    [SerializeField]
    float controlRollFactor = -25;

    public bool isControlEnabled = true;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
        }
    }

    private void ProcessTranslation()
    {
        float xRaw = CalculateOffset(CommonAxis.Horizontal, transform.localPosition.x, Speed.x, Range.x);
        float yRaw = CalculateOffset(CommonAxis.Vertical, transform.localPosition.y, Speed.y, Range.y);

        transform.localPosition = new Vector3(xRaw, yRaw, transform.localPosition.z);
    }

    private void ProcessRotation()
    {
        float xThrow = CrossPlatformInputManager.GetAxis(CommonAxis.Horizontal.ToString());
        float yThrow = CrossPlatformInputManager.GetAxis(CommonAxis.Vertical.ToString());

        float pitchDueToPosition = transform.localPosition.y * pitchFactor;
        float pitchDueToControlFlow = yThrow * controlPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlFlow;
   
        float yaw = (transform.localPosition.x * yawFactor);
        float roll = (xThrow * controlRollFactor);

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    float CalculateOffset(CommonAxis axis, float localPosition, float speed, float range)
    {
        float axisThrow = CrossPlatformInputManager.GetAxis(axis.ToString());
        float offset = axisThrow * Time.deltaTime * speed;
        float raw = Mathf.Clamp(localPosition + offset, -range, range);

        return raw;
    }

    public void OnPlayerDeath()
    {
        isControlEnabled = false;
    }
}