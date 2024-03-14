using System;
using System.Collections;
using System.Collections.Generic;
using GameTool;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Car : BaseUI
{
    [Header("Bools")] public bool drifting;
    public Transform kartModel;
    public Transform kartNormal;
    float speed, currentSpeed;
    float rotate, currentRotate;
    public Rigidbody sphere;
    public float gravity = 10f;
    [Header("Parameters")] public float acceleration = 100f;
    public float steering = 80f;
    [Header("Model Parts")] public Transform frontWheels;
    public Transform backWheels;
    int driftDirection;
    float driftPower;
    int driftMode = 0;
    public LayerMask layerMask;
    public List<ParticleSystem> primaryParticles = new List<ParticleSystem>();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Follow Collider
        transform.position = sphere.transform.position - new Vector3(0, 2.33f, 0);
        if (Input.GetButton("Fire1"))
            speed = acceleration;
        currentSpeed = Mathf.SmoothStep(currentSpeed, speed, Time.deltaTime * 10f);
        speed = 0f;
        if (Input.GetAxis("Horizontal") != 0)
        {
            int dir = Input.GetAxis("Horizontal") > 0 ? 1 : -1;
            float amount = Mathf.Abs((Input.GetAxis("Horizontal")));
            Steer(dir, amount);
        }

        currentRotate = Mathf.Lerp(currentRotate, rotate, Time.deltaTime * 4f);
        rotate = 0f;
        
        if (Input.GetButtonDown("Jump") && !drifting && Input.GetAxis("Horizontal") != 0)
        {
            drifting = true;
            driftDirection = Input.GetAxis("Horizontal") > 0 ? 1 : -1;

            // foreach (ParticleSystem p in primaryParticles)
            // {
            //     p.startColor = Color.clear;
            //     p.Play();
            // }
            
            kartModel.parent.DOComplete();
           // kartModel.parent.DOPunchPosition(transform.up * .2f, .3f, 5, 1);
        }

        if (drifting)
        {
            float control = (driftDirection == 1)
                ? ExtensionMethods.Remap(Input.GetAxis("Horizontal"), -1, 1, 0, 2)
                : ExtensionMethods.Remap(Input.GetAxis("Horizontal"), -1, 1, 2, 0);
            float powerControl = (driftDirection == 1)
                ? ExtensionMethods.Remap(Input.GetAxis("Horizontal"), -1, 1, .2f, 1)
                : ExtensionMethods.Remap(Input.GetAxis("Horizontal"), -1, 1, 1, .2f);
            Steer(driftDirection, control);
            driftPower += powerControl;

           // ColorDrift();
        }

        if (Input.GetButtonUp("Jump") && drifting)
        {
            Boost();
        }

        currentSpeed = Mathf.SmoothStep(currentSpeed, speed, Time.deltaTime * 12f);
        speed = 0f;
        currentRotate = Mathf.Lerp(currentRotate, rotate, Time.deltaTime * 4f);
        rotate = 0f;
        
        // private void OnTriggerEnter(Collider other)
        // {
        //     if (other.CompareTag("Win"))
        //     {
        //         CanvasManager.Instance.Push(eUIName.Winpopup);
        //     }
        //     if (other.CompareTag("Lose"))
        //     {
        //         CanvasManager.Instance.Push(eUIName.Losepopup);
        //     }
        // }
        // if (!drifting)
        // {
        //     kartModel.localEulerAngles = Vector3.Lerp(kartModel.localEulerAngles,
        //         new Vector3(0, 90 + (Input.GetAxis("Horizontal") * 15), kartModel.localEulerAngles.z), .2f);
        // }
        // else
        if (drifting)
        {
            float control = (driftDirection == 1)
                ? ExtensionMethods.Remap(Input.GetAxis("Horizontal"), -1, 1, .5f, 2)
                : ExtensionMethods.Remap(Input.GetAxis("Horizontal"), -1, 1, 2, .5f);
            kartModel.parent.localRotation = Quaternion.Euler(0,
                Mathf.LerpAngle(kartModel.parent.localEulerAngles.y, (control * 15) * driftDirection, .2f), 0);
        }
    }

    private void FixedUpdate()
    {
        //Forward Acceleration
         if (!drifting)
             sphere.AddForce(kartModel.transform.right * currentSpeed, ForceMode.Acceleration);
         else
             sphere.AddForce(transform.forward * currentSpeed, ForceMode.Acceleration);
         transform.eulerAngles = Vector3.Lerp(transform.eulerAngles,
             new Vector3(0, transform.eulerAngles.y + currentRotate, 0), Time.deltaTime);
       
    }

    public void Steer(int direction, float amount)
    {
        rotate = (steering * direction) * amount;
    }

    private void Speed(float x)
    {
        currentSpeed = x;
    }
    public void Boost()
    {
        drifting = false;

        if (driftMode > 0)
        {
            DOVirtual.Float(currentSpeed * 3, currentSpeed, .3f * driftMode, Speed);
            //DOVirtual.Float(0, 1, .5f, ChromaticAmount).OnComplete(() => DOVirtual.Float(1, 0, .5f, ChromaticAmount));
            // kartModel.Find("Tube001").GetComponentInChildren<ParticleSystem>().Play();
            // kartModel.Find("Tube002").GetComponentInChildren<ParticleSystem>().Play();
        }

        driftPower = 0;
        driftMode = 0;
        // first = false;
        // second = false;
        // third = false;

        // foreach (ParticleSystem p in primaryParticles)
        // {
        //     p.startColor = Color.clear;
        //     p.Stop();
        // }

        kartModel.parent.DOLocalRotate(Vector3.zero, .5f).SetEase(Ease.OutBack);
    }
    // void ChromaticAmount(float x)
    // {
    //     postProfile.GetSetting<ChromaticAberration>().intensity.value = x;
    // }
}

    public static class ExtensionMethods
    {
        public static float Remap(this float value, float from1, float to1, float from2, float to2)
        {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        }
    }   
// void ChromaticAmount(float x)
// {
//     //postProfile.GetSetting<ChromaticAberration>().intensity.value = x;
// }