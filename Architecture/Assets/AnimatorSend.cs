using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AnimatorSend : MonoBehaviour {
    public Transform camera;
    public Slider slider;

    public void CameraMove(int move)
    {
        camera.position = new Vector3(camera.position.x,camera.position.y,move);


    }
    void Update(){
        CameraHorizontalMove(slider.value);

    }
    public void CameraHorizontalMove(float move)
    {
        camera.position = new Vector3(move,camera.position.y,camera.position.z);


    }
}
