using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GametypeChanger : MonoBehaviour
{
    public GameObject UsernameinputsGameObject;
    public GameObject PlayGameObject;

    public static int current_mode = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnClick(int num) {
        if (GametypeChanger.current_mode != num && num == 0) {
            UsernameinputsGameObject.transform.GetChild(1).gameObject.SetActive(false);
            PlayGameObject.transform.localPosition = new Vector3(0, -68.3f, 0);

            PlayGameObject.transform.GetComponent<LoadScene>().sceneOverride = "SinglePlayer";
        } else if (GametypeChanger.current_mode != num && num == 1) {
            UsernameinputsGameObject.transform.GetChild(1).gameObject.SetActive(true);
            PlayGameObject.transform.localPosition = new Vector3(0, -103.3f, 0);

            PlayGameObject.transform.GetComponent<LoadScene>().sceneOverride = "Multiplayer";
        } else {
            Debug.Log("GametypeChanger.OnClick unneccessarily called... ");
        }

        GametypeChanger.current_mode = num;
    }
}
