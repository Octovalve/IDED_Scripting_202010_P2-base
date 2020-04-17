using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    float speed = 20f;
    float TimeV = 5f;
    // Start is called before the first frame update
    void OnEnable()
    {
        StartCoroutine(Return());
    }
    IEnumerator Return()
    {
        yield return new WaitForSeconds(TimeV);
        Pool.Instance.Return(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
