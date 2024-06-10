using UnityEngine;

public class CharacterSwitch : MonoBehaviour
{
    public GameObject character1;
    public GameObject character2;

    private bool isCharacter1Active = true;

    void Start()
    {
        // 초기 상태 설정
        character1.SetActive(true);
        character2.SetActive(false);
    }

    void Update()
    {
        // E키 입력 감지
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchCharacter();
        }
    }

    void SwitchCharacter()
    {
        // 캐릭터 활성화 상태 전환
        isCharacter1Active = !isCharacter1Active;
        character1.SetActive(isCharacter1Active);
        character2.SetActive(!isCharacter1Active);
    }
}
