using UnityEngine;

public class CharacterSwitch : MonoBehaviour
{
    public GameObject character1;
    public GameObject character2;

    private bool isCharacter1Active = true;

    void Start()
    {
        // �ʱ� ���� ����
        character1.SetActive(true);
        character2.SetActive(false);
    }

    void Update()
    {
        // EŰ �Է� ����
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchCharacter();
        }
    }

    void SwitchCharacter()
    {
        // ĳ���� Ȱ��ȭ ���� ��ȯ
        isCharacter1Active = !isCharacter1Active;
        character1.SetActive(isCharacter1Active);
        character2.SetActive(!isCharacter1Active);
    }
}
