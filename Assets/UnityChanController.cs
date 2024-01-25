using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnityChanController : MonoBehaviour
{

    //アニメーションするためのコード入れろ！
    private Animator myAnimator;

    //移動するためのコードを入れろ！
    private Rigidbody myRigidbody;
    //前方向の速度
    private float velocityZ = 16f;
    //横方向の速度（追加）
    private float velocityX = 10f;
    //左右の移動できる範囲（追加）
    private float movableRange = 3.4f;

    //上方向の速度
    private float velocityY = 10f;
    //動き減速
    private float coefficient = 0.99f;

    //ゲーム終了の判定
    private bool isEnd = false;

    //ゲーム終了時に表示するテキスト
    private GameObject stateText;

    //スコアを表示するテキスト
    private GameObject scoreText;

    //得点
    private int score = 0;

    //左ボタン押下の判定
    private bool isLButtonDown = false;

    //右ボタン押下の判定
    private bool isRButtonDown = false;

    //ジャンプボタン押下の判定
    private bool isJButtonDown = false;





    // Start is called before the first frame update
    void Start()
    {
        //コンポートを取得しろ！
        this.myAnimator = GetComponent<Animator>();

        //走るアニメーション↓
        this.myAnimator.SetFloat("Speed", 1);
        //Rigidbody取得
        this.myRigidbody = GetComponent<Rigidbody>();

        //シーン中のstateTextオブジェクトを取得
        this.stateText = GameObject.Find("GameResultText");

//シーン中のscoreTextオブジェクトを取得（追加）
        this.scoreText = GameObject.Find("ScoreText");
;
    }

    // Update is called once per frame
    void Update()
    {
        //ゲーム終了unityちゃんの動き減速
        if(this.isEnd)
        {
            this.velocityZ *= this.coefficient;
            this.velocityX *= this.coefficient;
            this.velocityY *= this.coefficient;
            this.myAnimator.speed *= this.coefficient;

        }
        //横方向の入力による速度（追加）
        float inputVelocityX = 0;

        float inputVelocityY = 0;

        //Unityちゃんを矢印キーまたはボタンに応じて左右に移動させる（追加）
        if ((Input.GetKey(KeyCode.LeftArrow)|| this.isLButtonDown) && -this.movableRange < this.transform.position.x)
        {
            //左へ移動
            inputVelocityX = -this.velocityX;
        }

        else if ((Input.GetKey(KeyCode.RightArrow)|| this.isRButtonDown) && this.transform.position.x < this.movableRange)
        {
            //右方向への速度を代入（追加）
            inputVelocityX = this.velocityX;
        }

        //ジャンプしてないときにスペースが押されたらジャンプする
        if((Input.GetKeyDown(KeyCode.Space)|| this.isJButtonDown) && this.transform.position.y < 0.5f)
        {
            //ジャンプアニメを再生
            this.myAnimator.SetBool("Jump", true);
            //上方向への速度代入
            inputVelocityY = this.velocityY;
        }

        else 
        {
            //現在のY軸の速度を代入
            inputVelocityY = this.myRigidbody.velocity.y;
        }

        if(this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            this.myAnimator.SetBool("Jump", false);
        }




        //ユニティちゃんに速度与える
        this.myRigidbody.velocity = new Vector3(inputVelocityX, inputVelocityY, this.velocityZ);
    }

   
    //トリガーモードで他のオブジェクトと接触した場合の処理（追加）
    void OnTriggerEnter(Collider other)
    {
        //障害物に衝突した場合（追加）
        if (other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag")
        {
            this.isEnd = true;
            //stateTextにGAME OVERを表示
            this.stateText.GetComponent<Text>().text = "GAME OVER";
        }

        //ゴール地点に到達した場合（追加）
        if (other.gameObject.tag == "GoalTag")
        {
            this.isEnd = true;
            //stateTextにGAME CLEARを表示
            this.stateText.GetComponent<Text>().text = "CLEAR!!";
        }
        //コインに衝突した場合
        if (other.gameObject.tag == "CoinTag")
        {
            // スコアを加算
            this.score += 10;

            //ScoreTextに獲得した点数を表示
            this.scoreText.GetComponent<Text>().text = "Score " + this.score + "pt";
            //パーティクルを再生（追加）
            GetComponent<ParticleSystem>().Play();
            //接触したコインのオブジェクトを破棄
            Destroy(other.gameObject);
        }




    }

    //ジャンプボタンを押した場合の処理
    public void GetMyJumpButtonDown()
    {
        this.isJButtonDown = true;
    }

    //ジャンプボタンを離した場合の処理（追加）
    public void GetMyJumpButtonUp()
    {
        this.isJButtonDown = false;
    }


    //左ボタンを押し続けた場合の処理（追加）
    public void GetMyLeftButtonDown()
    {
        this.isLButtonDown = true;
    }


    //左ボタンを離した場合の処理（追加）
    public void GetMyLeftButtonUp()
    {
        this.isLButtonDown = false;
    }


    //右ボタンを押し続けた場合の処理（追加）
    public void GetMyRightButtonDown()
    {
        this.isRButtonDown = true;
    }

    //右ボタンを離した場合の処理（追加）
    public void GetMyRightButtonUp()
    {
        this.isRButtonDown = false;
    }


}
