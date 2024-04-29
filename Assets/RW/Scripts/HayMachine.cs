using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayMachine : MonoBehaviour
{
    public float movementSpeed;
    public GameObject hayMachinePrefab;
    public GameObject hayBalePrefab; //Reference to the Hay Bale prefab.
    public Transform haySpawnpoint; //The point from which the hay will to be shot.
    public float shootInterval; //The smallest amount of time between shots
    private float shootTimer;

    public Transform modelParent; 

    
    public GameObject blueModelPrefab;
    public GameObject yellowModelPrefab;
    public GameObject redModelPrefab;

    // Start is called before the first frame update
    void Start()
    {
        LoadModel();

    }

    private void LoadModel()
    {
        Destroy(modelParent.GetChild(0).gameObject); // 1

        switch (GameSettings.hayMachineColor) // 2
        {
            case HayMachineColor.Blue:
                Instantiate(blueModelPrefab, modelParent);
                break;

            case HayMachineColor.Yellow:
                Instantiate(yellowModelPrefab, modelParent);
                break;

            case HayMachineColor.Red:
                Instantiate(redModelPrefab, modelParent);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
        Shooting();
        UpdateShooting();
    }

    private void UpdateMovement() //
    {
       float horizontalInput = Input.GetAxisRaw("Horizontal");
        //print(horizontalInput);

        if(horizontalInput < 0) //moving to the left
        {
            transform.Translate(transform.right *( -1 )* Time.deltaTime*movementSpeed);
        }

        else if(horizontalInput>0) //moving to the right
        {
            transform.Translate(transform.right * (1) * Time.deltaTime*movementSpeed);
        }
    }

    void Shooting()
    {
        //detect the input (space press)
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //instantiate a new object
            Instantiate(hayMachinePrefab, transform.position, Quaternion.identity);
            SoundManager.Instance.PlayShootClip();
        }

    }

    private void UpdateShooting()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0 && Input.GetKey(KeyCode.Space))
        {
            shootTimer = shootInterval;
            Shooting();
        }
        

    }

}
