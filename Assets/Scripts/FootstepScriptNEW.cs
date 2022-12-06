using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepScriptNEW : MonoBehaviour
{
    [Header("FMOD Settings")]
    [SerializeField] [FMODUnity.EventRef] private string FootStepsEventPath;

    [SerializeField] private string MaterialParameterName;

    [Header("Playback Settings")]
    [SerializeField] private float StepDistance = 2.0f;
    [SerializeField] private float RayDistance = 1.0f;

    [HideInInspector] public int DefulatMaterialValue = 0;

    public string[] MaterialTypes;

    private float StepRandom;
    private Vector3 PrevPos;
    private float DistanceTravelled;

    private RaycastHit hit;
    private int F_MaterialValue;
    private bool PlayerTouchingGround;

    private float TimeTakenSinceStep;




    void Start()
    {
        StepRandom = Random.Range(0f, 0.5f);
        PrevPos = transform.position;
    }

    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.down * RayDistance, Color.red);

        GroundedCheck();

        TimeTakenSinceStep += Time.deltaTime;
        DistanceTravelled += (transform.position - PrevPos).magnitude;
        if (DistanceTravelled >= StepDistance + StepRandom)
        {
            MaterialCheck();
            PlayFootstep();
            StepRandom = Random.Range(0f, 0.5f);
            DistanceTravelled = 0f;
        }
        PrevPos = transform.position;
    }

    void GroundedCheck ()
    {
        Physics.Raycast(transform.position, Vector3.down, out hit, RayDistance);
        if (hit.collider)
            PlayerTouchingGround = true;
        else
            PlayerTouchingGround = false;    
    }

    void MaterialCheck()
    {
        if (Physics.Raycast(transform.position, Vector3.down, out hit, RayDistance))
        {
            if (hit.collider.gameObject.GetComponent<FMODStudioMaterialSetter>())
            {
                F_MaterialValue = (int)hit.collider.gameObject.GetComponent<FMODStudioMaterialSetter>().MaterialValue;
            }
            else
                F_MaterialValue = DefulatMaterialValue;
        }
    }


    void PlayFootstep() 
    {
        if (PlayerTouchingGround)                                                                                  
        {
            FMOD.Studio.EventInstance Footstep = FMODUnity.RuntimeManager.CreateInstance(FootStepsEventPath); 
            FMODUnity.RuntimeManager.AttachInstanceToGameObject(Footstep, transform, GetComponent<Rigidbody>());
            Footstep.setParameterByName(MaterialParameterName, F_MaterialValue);
          
            Footstep.start();                                   
            Footstep.release();
        }
    }

}



