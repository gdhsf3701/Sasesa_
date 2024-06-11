using UnityEngine;

public class CharacterSwitch : MonoBehaviour
{
    public GameObject character1;
    public GameObject character2;
    [SerializeField]
    private GameObject bulga_effect;
    [SerializeField]
    private GameObject gumi_effect;
    private float effectLive = 0.5f;
    private bool isCharacter1Active = true;
    private float lastSwitchTime = 0f;
    private float switchCooldown = 1f;

    void Start()
    {
        // 초기 상태 설정
        character1.SetActive(true);
        character2.SetActive(false);
    }

    void Update()
    {
        // E키 입력 감지 및 쿨다운이 끝났을 때 전환 실행
        if (Input.GetKeyDown(KeyCode.E))
        {
           // lastSwitchTime = Time.time;  // 마지막 전환 시간 업데이트
            SwitchCharacter();
            
        }
    }

    void SwitchCharacter()
    {

        print(isCharacter1Active);
        // 상태에 따라 활성화/비활성화 설정
        if (isCharacter1Active)
        {
            character1.SetActive(true);
            character2.SetActive(false);
            Debug.Log("1");
            ToBulga();
        }
        else
        {
            character1.SetActive(false);
            character2.SetActive(true);
            Debug.Log("2");
            ToGumi();
        }  
        // 캐릭터 활성화 상태 전환
        isCharacter1Active = !isCharacter1Active;
    }

    void ToGumi()
    {
        // 효과 생성 및 위치 설정
        GameObject effectG = Instantiate(gumi_effect, new Vector3(character2.transform.position.x,character2.transform.position.y+1,character2.transform.position.z), Quaternion.identity);
        Destroy(effectG, effectLive);
    }

    void ToBulga()
    {
        // 효과 생성 및 위치 설정
        GameObject effectB = Instantiate(bulga_effect, new Vector3(character1.transform.position.x, character1.transform.position.y + 1, character1.transform.position.z), Quaternion.identity);
        Destroy(effectB, effectLive);
    }
}
