using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class joystick : MonoBehaviour
{

    // 공개
    public Transform Stick;         // 조이스틱.

    // 비공개
    private Vector3 StickFirstPos;  // 조이스틱의 처음 위치.
    private Vector3 JoyVec;         // 조이스틱의 벡터(방향)
    private float Radius;           // 조이스틱 배경의 반 지름.
    public move_player Player;
    bool isDrag;
    Vector3 Pos;
    public player_anime player_Anime;
    move_player player;
    void Start()
    {
        Radius = GetComponent<RectTransform>().sizeDelta.y * 0.4f;
        StickFirstPos = Stick.transform.position;

        // 캔버스 크기에대한 반지름 조절.
        float Can = transform.parent.GetComponent<RectTransform>().localScale.x;
        Radius *= Can;
        player = monster_manager.Instance.player.GetComponent<move_player>();
    }
    void FixedUpdate()
    {
        if (Player != null)
            Player.transform.Translate(JoyVec * (Player.speed+player.GetComponent<player_stats>().speed));

        player.plusVec = JoyVec;
    }

    // 드래그
    public void Drag(BaseEventData _Data)
    {
        PointerEventData Data = _Data as PointerEventData;
        Pos = Data.position;

        // 조이스틱을 이동시킬 방향을 구함.(오른쪽,왼쪽,위,아래)
        JoyVec = (Pos - StickFirstPos).normalized;

        // 조이스틱의 처음 위치와 현재 내가 터치하고있는 위치의 거리를 구한다.
        float Dis = Vector3.Distance(Pos, StickFirstPos);

        // 거리가 반지름보다 작으면 조이스틱을 현재 터치하고 있는곳으로 이동. 
        if (Dis < Radius)
        {
             monster_manager.Instance.disJump();
            Stick.position = StickFirstPos + JoyVec * Dis;
        }
        // 거리가 반지름보다 커지면 조이스틱을 반지름의 크기만큼만 이동.
        else
        {
            monster_manager.Instance.Jump();
            Stick.position = StickFirstPos + JoyVec * Radius;

        }
        player_Anime.orRun = true;
    }

    // 드래그 끝.
    public void DragEnd()
    {
        player_Anime.orRun = false;
        Stick.position = StickFirstPos; // 스틱을 원래의 위치로.
        JoyVec = Vector3.zero;          // 방향을 0으로.
    }
}