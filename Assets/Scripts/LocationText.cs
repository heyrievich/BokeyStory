using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAppear : MonoBehaviour
{
    public Animator anim;
    public TextMeshProUGUI text;
    public string locationName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // ��������� ��� �������
        {
            text.text = locationName;

            // ���������� �������� ����� ��������
            anim.Rebind();
            anim.Update(0);

            // ��������� ��������
            anim.Play("LocationText");
        }
    }
}
