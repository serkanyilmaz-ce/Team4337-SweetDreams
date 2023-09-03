using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EyeBlink : MonoBehaviour
{
    public RectTransform upperBox;
    public RectTransform lowerBox;
    public float speed = 1.0f;
    public int blinkTimes = 2;
    public bool endClosing;

    private Vector3 _originalUpperPosition;
    private Vector3 _originalLowerPosition;
    private Vector3 _endUpper;
    private Vector3 _endLower;

    private int _currentBlink = 1;
    private Image _lowerBox;
    private Image _upperBox;

    private enum Action {
        Open,
        Close
    };

    private void Start()
    {
        _lowerBox = lowerBox.GetComponent<Image>();
        _upperBox = upperBox.GetComponent<Image>();
        _lowerBox.enabled = false;
        _upperBox.enabled = false;
    }

    private void Awake()
    {
        _originalUpperPosition = upperBox.position;
        _originalLowerPosition = lowerBox.position;
        
    }

    private void OnEnable()
    {
        StartCoroutine(Blink());
    }

    private IEnumerator Blink()
    {
        while (_currentBlink <= blinkTimes)
        {
            _endUpper = _originalUpperPosition;
            _endLower = _originalLowerPosition;

            _endUpper.y += (50 * _currentBlink);
            _endLower.y -= (50 * _currentBlink);

            // open eyelids
            yield return MoveEyelids(_endUpper, _endLower, Action.Open);
            _lowerBox.enabled = true;
            _upperBox.enabled = true;
            
            // check if we want to end the blink closing the eyes
            if (_currentBlink == blinkTimes && !endClosing) {
                _originalUpperPosition.y = Screen.height * 2;
                _originalLowerPosition.y = -Screen.height;
            }

            // close eyelids
            yield return MoveEyelids(_originalUpperPosition, _originalLowerPosition, Action.Close);

            _currentBlink++;
        }
    }

    private IEnumerator MoveEyelids(Vector3 upperLid, Vector3 lowerLid, Action action)
    {
        float elapsedTime = 0;

        while (elapsedTime < speed)
        {
            var duration = (elapsedTime / speed);

            if (action == Action.Open) {
                upperBox.position = Vector3.Lerp(_originalUpperPosition, upperLid, duration);
                lowerBox.position = Vector3.Lerp(_originalLowerPosition, lowerLid, duration);
            } else {
                upperBox.position = Vector3.Lerp(_endUpper, upperLid, duration);
                lowerBox.position = Vector3.Lerp(_endLower, lowerLid, duration);
            }

            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
