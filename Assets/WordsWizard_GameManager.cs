using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WordsWizard_GameManager : MonoBehaviour
{
    public AudioClip[] audioClips;

    public void exitToHomeScreen()
    {
        playsound(audioClips[0]);
        SceneManager.LoadScene(0);
    }

    private void playsound(AudioClip audioClip)
    {
        source.PlayOneShot(audioClip);
    }

    public GameObject canvas;
    public void CanvasButtonClicked()
    {
        playsound(audioClips[0]);
        canvas.active = false;
    }
    private string[] lines;
    private string letters = "abcdefghijklmnopqrstuvwxyz";
    public Text LetterText;
    public Text ScoreText;
    public Text highScoreText;
    public Text inputTextField;

    private AudioSource source;
    void Start()
    {
        source = GetComponent<AudioSource>();
        lines = File.ReadAllLines("Assets/Resources/WordsWizard_Resources/wordData.txt");
        string[] highscrelines = File.ReadAllLines("Assets/Resources/WordsWizard_Resources/SaveData.txt");
        highScoreText.text = highscrelines[highscrelines.Length - 1].Split('$')[1];
    }
    char letter
    {
        get;    set;
    } 
    void chooseLetter()
    {
        letter = letters[Random.Range(0, 25)];
    }
    public void startGame()
    {
        playsound(audioClips[0]);
        chooseLetter();
        LetterText.text = "Enter word starting \n with letter " + letter;
    }
    public void takeInput(string _letter)
    {
        playsound(audioClips[0]);
        inputTextField.text = inputTextField.text + _letter;
    }
    public GameObject prefab;
    public GameObject parent;
    public void enter()
    {
        playsound(audioClips[0]);
        if (inputTextField.text[0] == letter && File.ReadAllText("Assets/Resources/WordsWizard_Resources/wordData.txt").Contains(inputTextField.text))
        {
            GameObject temp = Instantiate(prefab, parent.transform);
            temp.transform.GetChild(0).GetComponent<Text>().text = inputTextField.text;
            int score = int.Parse(ScoreText.text);
            ScoreText.text =  (inputTextField.text.Length + score).ToString();
            if(int.Parse(highScoreText.text) < int.Parse(ScoreText.text))
            {
                highScoreText.text = ScoreText.text;
                string newline = "WordsWizard$" + highScoreText.text;
                File.AppendAllText("Assets/Resources/WordsWizard_Resources/SaveData.txt", newline + System.Environment.NewLine);
            }
            inputTextField.text = null;
            source.PlayOneShot(audioClips[1]);
            startGame();
        }
        else
        {
            source.PlayOneShot(audioClips[2]);
        }
    }
    public void backSpace()
    {
        if(inputTextField.text.Length != 0)
        {
            source.PlayOneShot(audioClips[0]);
            string _word = inputTextField.text;
            string endword = _word.Substring(0, _word.Length - 1);
            inputTextField.text = endword;
        }
    }
}
