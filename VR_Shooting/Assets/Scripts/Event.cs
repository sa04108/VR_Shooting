using UnityEngine;

class DelegateEventClass {
    public delegate void DelegateMethod(string message);
    public event DelegateMethod EventMethod;

    public void MultipleOf5(int number) {
        if (number % 5 == 0 && number != 0) {
            EventMethod(string.Format($"{number}는 5의 배수"));
        }
    }
}

public class Event : MonoBehaviour {
    void Start() {
        DelegateEventClass delegateEventClass = new DelegateEventClass();
        delegateEventClass.EventMethod += DebugLog;
        delegateEventClass.EventMethod += LogYellow;

        for (int i = 0; i < 30; i++)
            delegateEventClass.MultipleOf5(i);
    }

    void DebugLog(string message) {
        Debug.Log(message);
    }

    void LogYellow(string message) {
        Debug.Log("<color=yellow>" + message + "</color>");
    }
}