using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GameDebug
{
    public class DebugLogPreview : MonoBehaviour
    {
        private void OnEnable()
        {
            InitLabels();
            Application.logMessageReceived += AddLogMessage;
        }

        private void OnDisable()
        {
            Application.logMessageReceived -= AddLogMessage;
        }

        private void Update()
        {
            TryHideMessage();
        }

        private void InitLabels()
        {
            _labels = new List<TMP_Text>();
            _labels.Add(_label);
            for (int i = 1; i < _maxMessageDisplayed; i++)
            {
                var newLabel = Instantiate<TMP_Text>(_label, this.transform);
                newLabel.transform.localPosition += Vector3.down * _messagesSpacing * i;
                _labels.Add(newLabel);
            }
        }

        private void TryHideMessage()
        {
            if (!_haveMassages)
            {
                return;
            }

            if (Time.time > _lastMessageTime + _disappearTime)
            {
                foreach (var label in _labels)
                {
                    label.text = "";
                }

                _haveMassages = false;
            }
        }

        private void AddLogMessage(string message, string strackTrace, LogType logType)
        {
            int ComplexMessageSeparator = message.IndexOf(']');
            var shortMessage = ComplexMessageSeparator == -1 ? message : message.Substring(ComplexMessageSeparator + 2);
            MoveMessagesUp();
            foreach (var label in _labels)
            {
                if (label.text == "")
                {
                    label.text = shortMessage;
                    break;
                }
            }

            _lastMessageTime = Time.time;
            _haveMassages = true;
        }

        private void MoveMessagesUp()
        {
            if (_labels[_labels.Count - 1].text == "")
            {
                return;
            }

            for (int i = 0; i < _labels.Count - 1; i++)
            {
                _labels[i].text = _labels[i + 1].text;
            }

            _labels[_labels.Count - 1].text = "";
        }

        [SerializeField]
        private TMP_Text _label;
        private List<TMP_Text> _labels;

        [SerializeField]
        private float _disappearTime = 1.0f;

        [SerializeField]
        private int _maxMessageDisplayed = 3;
        private bool _haveMassages = false;

        [SerializeField]
        private float _messagesSpacing = 50.0f;

        private float _lastMessageTime = 0.0f;
    }
}
