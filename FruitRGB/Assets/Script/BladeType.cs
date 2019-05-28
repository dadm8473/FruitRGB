using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BladeType : MonoBehaviour {

    public Image color_state;
    public Material red;
    public Material blue;
    public Material orange;
    public Material green;

    // 패널을 눌렀을 때 블레이드 타일 변경

    public void RO_Panel()
    {
        //Debug.Log("RO");
        Blade.getInstance().type = 1;
        // 노크 사운드 출력
        SoundManager.instance.PlaySound(2);
        // 상태 색깔 변경
        color_state.color = red.color;
    }

    public void RD_Panel()
    {
        //Debug.Log("R_");
        Blade.getInstance().type = 2;
        // 노크 사운드 출력
        SoundManager.instance.PlaySound(2);
        // 상태 색깔 변경
        color_state.color = green.color;
    }

    public void LO_Panel()
    {
        //Debug.Log("LO");
        Blade.getInstance().type = 3;
        // 노크 사운드 출력
        SoundManager.instance.PlaySound(2);
        // 상태 색깔 변경
        color_state.color = orange.color;
    }

    public void LD_Panel()
    {
        //Debug.Log("L_");
        Blade.getInstance().type = 4;
        // 노크 사운드 출력
        SoundManager.instance.PlaySound(2);
        // 상태 색깔 변경
        color_state.color = blue.color;
    }
}
