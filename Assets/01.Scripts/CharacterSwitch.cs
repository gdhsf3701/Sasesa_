using Cinemachine;
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
    [SerializeField] private Camera mainCam;
    private CinemachineVirtualCamera CVcam;
    private bool isJinHwa = false;

    void Start()
    {
        // �ʱ� ���� ����
        character1.SetActive(true);
        character2.SetActive(false);

        // CinemachineVirtualCamera �ʱ�ȭ
        CVcam = FindObjectOfType<CinemachineVirtualCamera>();
        if (CVcam != null)
        {
            CVcam.Follow = character1.transform;
        }
    }

    void Update()
    {
        // EŰ �Է� ���� �� ��ٿ��� ������ �� ��ȯ ����
        if (Input.GetKeyDown(KeyCode.E) && Time.time - lastSwitchTime >= switchCooldown)
        {
            lastSwitchTime = Time.time;  // ������ ��ȯ �ð� ������Ʈ
            SwitchCharacter();
        }
    }

    void SwitchCharacter()
    {
        // ���¿� ���� Ȱ��ȭ/��Ȱ��ȭ ����
        if (isCharacter1Active)
        {
            if(isJinHwa == false)
            {
                character1.SetActive(false);
                character2.SetActive(true);
                Debug.Log("2");
                ToGumi();
            }
            else
            {
                character1.SetActive(false);
                character2.SetActive(true);
                Debug.Log("2");
                ToGumi();
            }
            
        }
        else
        {
            if(isJinHwa == false)
            {
                character1.SetActive(true);
                character2.SetActive(false);
                Debug.Log("1");
                ToBulga();
            }
            else
            {
                character1.SetActive(true);
                character2.SetActive(false);
                Debug.Log("1");
                ToBulga();
            }
        }

        // ĳ���� Ȱ��ȭ ���� ��ȯ
        isCharacter1Active = !isCharacter1Active;
    }

    void ToGumi()
    {
        // CinemachineVirtualCamera�� character2�� ���󰡵��� ����
        if (CVcam != null)
        {
            CVcam.Follow = character2.transform;
            CVcam.LookAt = character2.transform;
        }

        // ȿ�� ���� �� ��ġ ����
        GameObject effectG = Instantiate(gumi_effect, new Vector3(character2.transform.position.x, character2.transform.position.y + 1, character2.transform.position.z), Quaternion.identity);
        Destroy(effectG, effectLive);
    }

    void ToBulga()
    {
        // CinemachineVirtualCamera�� character1�� ���󰡵��� ����
        if (CVcam != null)
        {
            CVcam.Follow = character1.transform;
            CVcam.LookAt = character1.transform;
        }

        // ȿ�� ���� �� ��ġ ����
        GameObject effectB = Instantiate(bulga_effect, new Vector3(character1.transform.position.x, character1.transform.position.y + 1, character1.transform.position.z), Quaternion.identity);
        Destroy(effectB, effectLive);
    }
}
