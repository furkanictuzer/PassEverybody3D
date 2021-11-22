using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Canvas paintCanvas;
    [SerializeField] private Canvas inGameCanvas;
    [SerializeField] private Canvas EndCanvas;
    [SerializeField] private Slider paintSlider;
    [SerializeField] private Text percentage;
    [SerializeField] private Paint paint;

    [SerializeField] private FinishLine finishLine;
    [SerializeField] private AnimatorController animatorController;
    [SerializeField] private PlayerController playerController;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject runners;

    public bool isPaintStage = false;
    public bool isFinish = false;

    private void Awake()
    {
        finishLine.OnLinePass += OnLinePass;
    }

    void Update()
    {
        if (isPaintStage)
        {
            PaintingStage();
        }
        if (isFinish)
        {
            Finish();
        }
        if (player.transform.position.y < playerController.initialPos.z - 4f)
        {
            RestartGame();
        }
    }
    private void OnLinePass()
    {
        isPaintStage = true;
        paint.isPaint = true;
    }

    //Çizim aşamasına geçmek için
    void PaintingStage()
    {
        animatorController.RotatePlayer();
        playerController.enabled = false;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.transform.SetParent(null);
        runners.SetActive(false);

        PercentageUI();
    }

    void PercentageUI()
    {
        inGameCanvas.gameObject.SetActive(false);
        paintCanvas.gameObject.SetActive(true);
        //Yüzde kısmını yazdırıyoruz
        paintSlider.value = paint.percentagePainting / 100;
        percentage.text = "%" + paint.percentagePainting.ToString();

        if (paint.percentagePainting == 100)
        {
            isFinish = true;
            isPaintStage = false;
        }
    }

    void Finish()
    {
        animatorController.EndDance();
        EndCanvas.gameObject.SetActive(true);
        isFinish = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
