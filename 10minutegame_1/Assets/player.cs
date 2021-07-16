using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour {

    Rigidbody rigid;

	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
                                            // z  x  y
        transform.rotation  *= Quaternion.Euler(0, 0, 7 * Time.deltaTime);
        rigid.velocity      += transform.rotation * (Vector3.right * Input.GetAxisRaw("Horizontal") * 10f * Time.deltaTime);
        rigid.velocity      += transform.rotation * (Vector3.up    * Input.GetAxisRaw("Vertical")   * 10f * Time.deltaTime);

        Time.timeScale += Time.fixedDeltaTime * 0.01f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
