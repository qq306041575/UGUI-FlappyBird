using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainViewController : MonoBehaviour
{
    BackgroundComponent _skyBackground;
    BackgroundComponent _grassBackground;
    ColumnController _columnController;
    BirdController _birdController;
    Text _loseText;
    Text _playText;
    Text _scoreText;
    int _score;
    bool _isLose;

    void Awake()
    {
        _skyBackground = transform.Find("SkyBackground").GetComponent<BackgroundComponent>();
        _grassBackground = transform.Find("GrassBackground").GetComponent<BackgroundComponent>();
        _columnController = transform.Find("ColumnController").GetComponent<ColumnController>();
        _birdController = transform.Find("BirdController").GetComponent<BirdController>();
        _loseText = transform.Find("LoseText").GetComponent<Text>();
        _playText = transform.Find("PlayText").GetComponent<Text>();
        _scoreText = transform.Find("ScoreText").GetComponent<Text>();
    }

    void Update()
    {
        if (_isLose)
        {
            return;
        }
        var go = _birdController.GetColliderObject();
        if (go == null || "CeilCollider" == go.name)
        {
            return;
        }
        else if ("FloorCollider" == go.name || "ColumnCollider" == go.name)
        {
            LoseGame();
        }
        else if ("ScoreCollider" == go.name)
        {
            AddScore();
        }
    }

    void AddScore()
    {
        _score++;
        _scoreText.text = string.Format("SCORE: {0}", _score);
        if (0 == _score % 5)
        {
            _columnController.AddSpeed();
        }
    }

    void LoseGame()
    {
        _isLose = true;
        _birdController.Die();
        _columnController.Pause();
        _skyBackground.enabled = false;
        _grassBackground.enabled = false;
        _loseText.enabled = true;
        _playText.enabled = true;
    }

    public void OnMaskClick()
    {
        if (_isLose)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            _birdController.Flap();
        }
    }
}
