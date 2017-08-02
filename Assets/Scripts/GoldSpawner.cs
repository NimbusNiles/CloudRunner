using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldSpawner : MonoBehaviour {

    public GameObject goldPrefab;

    private GameObject goldParent;

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }

    private void Start() {
        goldParent = GameObject.Find("Gold");
        if (goldParent == null) {
            goldParent = new GameObject("Gold");
        }
    }
    
    public void SpawnGold(float goldSpeed, Color coinColor, float height) {
        Vector3 spawnPosition = transform.position;
        spawnPosition.y += height;

        GameObject gold = Instantiate(goldPrefab, spawnPosition, Quaternion.identity);
        gold.transform.parent = goldParent.transform;

        gold.GetComponent<Rigidbody2D>().velocity = Vector2.left * goldSpeed;
        gold.GetComponent<SpriteRenderer>().color = coinColor;
        gold.tag = "Gold";

        gold.GetComponent<GoldCoin>().coinValue = GoldManager.CurrentGoldValue;
        gold.GetComponent<SpriteRenderer>().color = GoldManager.CurrentGoldColor;
    }

}
