using UnityEngine;
using UnityEngine.InputSystem;

public class StageMove : MonoBehaviour
{
    //プレイヤーの入力（WASD,矢印キー）が入力されたらStageを回転させる
    private InputAction _playerInput;

    //回転させたい対称のオブジェクト
    [SerializeField]
    private GameObject _Stage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //InputSystemのアクションマップから”Move”という名前のアクションを探して取得
        _playerInput = InputSystem.actions.FindAction("Move");
    }

    //1fごとにこの関数が呼ばれる
    // Update is called once per frame
    void Update()
    {
        //playerInputの値によってステージを回転させる
        Debug.Log(_playerInput.ReadValue<Vector2>());
        //stageを回転させる処理
        //水平方向の入力の取得
        float horizontalInput = _playerInput.ReadValue<Vector2>().x;
        //垂直方向の入力の取得
        float verticalInput = _playerInput.ReadValue<Vector2>().y;

        //実際にオブジェクトを回転させる
        _Stage.transform.Rotate(horizontalInput, 0f, verticalInput);
    }
}
