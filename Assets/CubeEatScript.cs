using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEatScript : MonoBehaviour {

    public int size = 1;

    public float totalFood;

    public List<GameObject> foodInRange;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Trying to eat");
            Eat();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<FoodScript>())
        {
            Eat(collision.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<FoodScript>())
        {
            foodInRange.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (foodInRange.Contains(other.gameObject))
        {
            foodInRange.Remove(other.gameObject);
        }
    }


    public void Eat()
    {

        while(foodInRange.Count > 0)
        {
            GameObject objectEaten = foodInRange[0];
            int amountOfFood = objectEaten.GetComponent<FoodScript>().foodAmount;

            totalFood += amountOfFood;
            foodInRange.Remove(objectEaten);
            Destroy(objectEaten);
        }

        size = Mathf.FloorToInt(totalFood / 10) + 1;

        transform.localScale = new Vector3(size, size, size);

    }

    public void Eat(GameObject objectEaten)
    {
        int amountOfFood = objectEaten.GetComponent<FoodScript>().foodAmount;

        totalFood += amountOfFood;
        foodInRange.Remove(objectEaten);
        Destroy(objectEaten);

        size = Mathf.FloorToInt(totalFood / 10) + 1;

        transform.localScale = new Vector3(size, size, size);
    }

}
