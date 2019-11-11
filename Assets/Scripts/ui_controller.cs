using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ModuloKart.Controls;
using ModuloKart.CustomVehiclePhysics;

public class ui_controller : MonoBehaviour
{
   public GameObject[] ui_item;
   public int item_selected;

    public bool has_door_1 = true;
     public bool has_door_2 = true;
    public bool has_tire_1 = true;
    public bool has_tire_2 = true;
    public bool has_tire_3 = true;
    public bool has_tire_4 = true;
    public bool has_hood = true;
    public int playerNum;
    public GameObject vechicle;
    public GameObject wheeldetacher;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "Player1")
            playerNum = 1;
        else if (gameObject.tag == "Player2")
            playerNum = 2;
        else if (gameObject.tag == "Player3")
            playerNum = 3;
        else if (gameObject.tag == "Player4")
            playerNum = 4;

        item_selected = 0;
        ui_item = new GameObject[7];
        int i = 0;
        
        while (i < 7)
        {
            ui_item[i] = gameObject.transform.GetChild(i).gameObject;
            if (ui_item[i] == null)
                throw new System.Exception("ui_item " + i + " not set");
            i++;
        }







    }

    // Update is called once per frame
    void Update()
    {
        Player_Wheel_Detach wheels = wheeldetacher.GetComponentInChildren<Player_Wheel_Detach>();

        if (!vechicle.GetComponent<VehicleBehavior>().isControllerInitialized) return;

        if (Input.GetButtonDown(vechicle.GetComponent<VehicleBehavior>().input_ItemNext))
        {
            Debug.Log("TEST NEXT INPUT");
            // Debug.Log("before" + item_selected);
            ui_item[item_selected].transform.localScale -= new Vector3(0.5f, 0.5f);


            item_selected -= 1;
            if (item_selected < 0)
            {
                item_selected = 6;
            }

            
            ui_item[item_selected].transform.localScale += new Vector3(0.5f, 0.5f);
            if (ui_item[item_selected].gameObject.active == false)
            {
                Debug.Log("Item not there");
                
            }

            //Debug.Log("after" + item_selected);

        }
        else if (Input.GetButtonDown(vechicle.GetComponent<VehicleBehavior>().input_ItemPrev))
        {
            Debug.Log("TEST PREV INPUT");
            ui_item[item_selected].transform.localScale -= new Vector3(0.5f, 0.5f);


            item_selected += 1;
          
            if (item_selected >= 7)
                item_selected = 0;
  
            ui_item[item_selected].transform.localScale += new Vector3(0.5f, 0.5f);
          if (ui_item[item_selected].gameObject.active == false)
            {
                Debug.Log("Item not there");

            }

        }

        if (Input.GetButtonDown(vechicle.GetComponent<VehicleBehavior>().input_projectile))
        {
            Debug.Log("TEST SHOOT INPUT");


            if (ui_item[item_selected].gameObject.tag == "Tire")
            {
                if (item_selected == 0)
                {
                    if (has_tire_1)
                    {
                        vechicle.GetComponentInChildren<Player_Wheel_Detach>().Throw_Wheel(1);
                        Debug.Log("used front left tire");
                        has_tire_1 = false;
                        ui_item[item_selected].gameObject.SetActive(false);
                    }
                    else
                        Debug.Log("tire already used");
                }

                if (item_selected == 2)
                {
                    if (has_tire_2)
                    {
                        vechicle.GetComponentInChildren<Player_Wheel_Detach>().Throw_Wheel(2);
                        Debug.Log("used front right tire");
                        has_tire_2 = false;
                        ui_item[item_selected].gameObject.SetActive(false);
                    }
                    else
                        Debug.Log("tire already used");
                }

                if (item_selected == 5)
                {
                    if (has_tire_3)
                    {
                        vechicle.GetComponentInChildren<Player_Wheel_Detach>().Throw_Wheel(3);
                        Debug.Log("used back left tire");
                        has_tire_3 = false;
                        ui_item[item_selected].gameObject.SetActive(false);
                    }
                    else
                        Debug.Log("tire already used");
                }

                if (item_selected == 6)
                {
                    if (has_tire_4)
                    {
                        vechicle.GetComponentInChildren<Player_Wheel_Detach>().Throw_Wheel(4);
                        Debug.Log("used back right tire");
                        has_tire_4 = false;
                        ui_item[item_selected].gameObject.SetActive(false);
                    }
                    else
                        Debug.Log("tire already used");
                }


            }
            else if (ui_item[item_selected].gameObject.tag == "Door")
            {

                if (item_selected == 3)
                {
                    if (has_door_1)
                    {

                        Debug.Log("used left door");
                        has_door_1 = false;
                    }
                    else
                        Debug.Log("door already used");
                }

                if (item_selected == 4)
                {
                    if (has_door_2)
                    {
                        Debug.Log("used right door");
                        has_door_2 = false;
                    }
                    else
                        Debug.Log("door already used");
                }
            }
            else if (ui_item[item_selected].gameObject.tag == "Hood")
            {
                if (has_hood)
                {
                    vechicle.GetComponentInChildren<Player_Projectile>().Throw_Hood();
                    Debug.Log("used hood");
                    has_hood = false;
                    ui_item[item_selected].gameObject.SetActive(false);
                    //call hood item function use here
                }
                else if (!has_hood)
                {
                    Debug.Log("No hood left fool");
                    //play sound? or other notification
                }
            }
        }

       /* if (Input.GetButtonDown(vechicle.GetComponent<VehicleBehavior>().input_ItemNext))
        {
            // Debug.Log("before" + item_selected);
            ui_item[item_selected].transform.localScale -= new Vector3(0.5f, 0.5f);


            item_selected += 1;
            if (item_selected >= 7)
                item_selected = 0;

            ui_item[item_selected].transform.localScale += new Vector3(0.5f, 0.5f);


            //Debug.Log("after" + item_selected);

        }
        else if (Input.GetButtonDown(vechicle.GetComponent<VehicleBehavior>().input_ItemPrev))
        {
            ui_item[item_selected].transform.localScale -= new Vector3(0.5f, 0.5f);


            item_selected -= 1;
            if (item_selected < 0)
                item_selected = 6;

            ui_item[item_selected].transform.localScale += new Vector3(0.5f, 0.5f);


        }*/

        if (Input.GetButtonDown(vechicle.GetComponent<VehicleBehavior>().input_projectile))
        {
            Debug.Log("I am player" + playerNum);

            if (ui_item[item_selected].gameObject.tag == "Tire")
            {
                if (item_selected == 0)
                {
                    if (has_tire_1)
                    {
                        Debug.Log("used front left tire");
                        has_tire_1 = false;
                    }
                    else
                        Debug.Log("tire already used");
                }

                if (item_selected == 2)
                {
                    if (has_tire_2)
                    {
                        Debug.Log("used front right tire");
                        has_tire_2 = false;
                    }
                    else
                        Debug.Log("tire already used");
                }

                if (item_selected == 5)
                {
                    if (has_tire_3)
                    {
                        Debug.Log("used back left tire");
                        has_tire_3 = false;
                    }
                    else
                        Debug.Log("tire already used");
                }

                if (item_selected == 6)
                {
                    if (has_tire_4)
                    {
                        Debug.Log("used back right tire");
                        has_tire_4 = false;
                    }
                    else
                        Debug.Log("tire already used");
                }


            }
            else if (ui_item[item_selected].gameObject.tag == "Door")
            {

                if (item_selected == 3)
                {
                    if (has_door_1)
                    {
                        Debug.Log("used left door");
                        has_door_1 = false;
                    }
                    else
                        Debug.Log("door already used");
                }

                if (item_selected == 4)
                {
                    if (has_door_2)
                    {
                        Debug.Log("used right door");
                        has_door_2 = false;
                    }
                    else
                        Debug.Log("door already used");
                }
            }
            else if (ui_item[item_selected].gameObject.tag == "Hood")
            {
                if (has_hood)
                {
                    Debug.Log("used hood");
                    has_hood = false;
                    //call hood item function use here
                }
                else if (!has_hood)
                {
                    Debug.Log("No hood left fool");
                    //play sound? or other notification
                }
            }
        }

        if (Input.GetButtonDown(vechicle.GetComponent<VehicleBehavior>().input_ItemNext))
        {
            // Debug.Log("before" + item_selected);
            ui_item[item_selected].transform.localScale -= new Vector3(0.5f, 0.5f);


            item_selected += 1;
            if (item_selected >= 7)
                item_selected = 0;

            ui_item[item_selected].transform.localScale += new Vector3(0.5f, 0.5f);


            //Debug.Log("after" + item_selected);

        }
        else if (Input.GetButtonDown(vechicle.GetComponent<VehicleBehavior>().input_ItemPrev))
        {
            Debug.Log("I am player" + playerNum);

            ui_item[item_selected].transform.localScale -= new Vector3(0.5f, 0.5f);


            item_selected -= 1;
            if (item_selected < 0)
                item_selected = 6;

            ui_item[item_selected].transform.localScale += new Vector3(0.5f, 0.5f);


        }

        if (Input.GetButtonDown(vechicle.GetComponent<VehicleBehavior>().input_projectile))
        {
            if (ui_item[item_selected].gameObject.tag == "Tire")
            {
                if (item_selected == 0)
                {
                    if (has_tire_1)
                    {
                        Debug.Log("used front left tire");
                        has_tire_1 = false;
                    }
                    else
                        Debug.Log("tire already used");
                }

                if (item_selected == 2)
                {
                    if (has_tire_2)
                    {
                        Debug.Log("used front right tire");
                        has_tire_2 = false;
                    }
                    else
                        Debug.Log("tire already used");
                }

                if (item_selected == 5)
                {
                    if (has_tire_3)
                    {
                        Debug.Log("used back left tire");
                        has_tire_3 = false;
                    }
                    else
                        Debug.Log("tire already used");
                }

                if (item_selected == 6)
                {
                    if (has_tire_4)
                    {
                        Debug.Log("used back right tire");
                        has_tire_4 = false;
                    }
                    else
                        Debug.Log("tire already used");
                }


            }
            else if (ui_item[item_selected].gameObject.tag == "Door")
            {

                if (item_selected == 3)
                {
                    if (has_door_1)
                    {
                        Debug.Log("used left door");
                        has_door_1 = false;
                    }
                    else
                        Debug.Log("door already used");
                }

                if (item_selected == 4)
                {
                    if (has_door_2)
                    {
                        Debug.Log("used right door");
                        has_door_2 = false;
                    }
                    else
                        Debug.Log("door already used");
                }
            }
            else if (ui_item[item_selected].gameObject.tag == "Hood")
            {
                if (has_hood)
                {
                    Debug.Log("used hood");
                    has_hood = false;
                    //call hood item function use here
                }
                else if (!has_hood)
                {
                    Debug.Log("No hood left fool");
                    //play sound? or other notification
                }
            }
        }

        if (Input.GetButtonDown(vechicle.GetComponent<VehicleBehavior>().input_ItemNext))
        {
            // Debug.Log("before" + item_selected);
            ui_item[item_selected].transform.localScale -= new Vector3(0.5f, 0.5f);


            item_selected += 1;
            if (item_selected >= 7)
                item_selected = 0;

            ui_item[item_selected].transform.localScale += new Vector3(0.5f, 0.5f);


            //Debug.Log("after" + item_selected);

        }
        else if (Input.GetButtonDown(vechicle.GetComponent<VehicleBehavior>().input_ItemPrev))
        {
            Debug.Log("I am player" + playerNum);

            ui_item[item_selected].transform.localScale -= new Vector3(0.5f, 0.5f);


            item_selected -= 1;
            if (item_selected < 0)
                item_selected = 6;

            ui_item[item_selected].transform.localScale += new Vector3(0.5f, 0.5f);


        }

        if (Input.GetButtonDown(vechicle.GetComponent<VehicleBehavior>().input_projectile))
        {
            if (ui_item[item_selected].gameObject.tag == "Tire")
            {
                if (item_selected == 0)
                {
                    if (has_tire_1)
                    {
                        Debug.Log("used front left tire");
                        has_tire_1 = false;
                    }
                    else
                        Debug.Log("tire already used");
                }

                if (item_selected == 2)
                {
                    if (has_tire_2)
                    {
                        Debug.Log("used front right tire");
                        has_tire_2 = false;
                    }
                    else
                        Debug.Log("tire already used");
                }

                if (item_selected == 5)
                {
                    if (has_tire_3)
                    {
                        Debug.Log("used back left tire");
                        has_tire_3 = false;
                    }
                    else
                        Debug.Log("tire already used");
                }

                if (item_selected == 6)
                {
                    if (has_tire_4)
                    {
                        Debug.Log("used back right tire");
                        has_tire_4 = false;
                    }
                    else
                        Debug.Log("tire already used");
                }


            }
            else if (ui_item[item_selected].gameObject.tag == "Door")
            {

                if (item_selected == 3)
                {
                    if (has_door_1)
                    {
                        Debug.Log("used left door");
                        has_door_1 = false;
                    }
                    else
                        Debug.Log("door already used");
                }

                if (item_selected == 4)
                {
                    if (has_door_2)
                    {
                        Debug.Log("used right door");
                        has_door_2 = false;
                    }
                    else
                        Debug.Log("door already used");
                }
            }
            else if (ui_item[item_selected].gameObject.tag == "Hood")
            {
                if (has_hood)
                {
                    Debug.Log("used hood");
                    has_hood = false;
                    //call hood item function use here
                }
                else if (!has_hood)
                {
                    Debug.Log("No hood left fool");
                    //play sound? or other notification
                }
            }
        }

    }

}
