using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Assets.Scripts.Locations
{
    public class MemoryTrigger : MonoBehaviour
    {

        public static Action<string> Mem; 
    
        private static List<string> _memoris = new List<string>() { "������ ������ ����� � ���-�� ���, ����������.  ������� ������������ � ����� � �������� ��� ������.",
                                                             "������ ������� �������� �������. ������� �������, � �� ��������� �� �������� ������.",
                                                             "� ��� ���� �����? � ����? � ������? � ������ ������?",
                                                             "������ ����� �� ������� ���������. ����� ��� � ����.",
                                                             "� �����, ��� �� ������ ���������� � ������������ � �������� ��������. ��� ����� ������.",
                                                             "�������, ���-�� ����� ��� � �����. ��������, ������ ��� � ����!",
                                                             "������� ���������. ������, ��� ����� ������� ��� ���� �������� ������ ����.",
                                                             "���� �� ���� ���-�� ���� �����������. ���� �������� � ����� ��� �����!",
                                                            "� ������ ������ ���� � �� �� �������. ��� � � ������?",
                                                            "� ������ �����-�� �����. � ���, ����������. ��� �� ����������.",
                                                            "���� �� � ��� ������� �����, ���� �� � �� ���� ���������?",
                                                            "������ �� ���, ������� �� ����� �������������.",
                                                            "������ ����, ������ �����. ���� ����-��. ���� ����.",
                                                            "����� ��� ������? ��� ���� �������������. �� � ������ ���� ��������. �������� ��.",
                                                            "���� �� � �� ��� ����������, ���� �� ���������, ����� �� � ������ � ������� ������. � ����� ������� �� �� ���� �����." };
       
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                Mem?.Invoke(RandomMemory());
            }
            
        }
        private string RandomMemory()
        {
            int id = UnityEngine.Random.Range(0, _memoris.Count);
            Debug.Log($"{_memoris[id]}");
            string now = _memoris[id];
            _memoris.RemoveAt(id);
            return now;
        }
    }
}