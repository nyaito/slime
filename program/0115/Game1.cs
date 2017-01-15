using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using SkinnedModel;

namespace SkinmanInsrt
{
    /// <summary>
    /// 基底 Game クラスから派生した、ゲームのメイン クラスです。
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        #region フィールド
        /// <summary>
        /// グラフィックスデバイスマネージャー
        /// </summary>
        public GraphicsDeviceManager graphics;

        ///<summary>
        /// コンポーネント
        ///</summary>
        MainComponent mainComponent;
        

        /// <summary>
        /// モデル
        /// </summary>
        const float modelesize = 100f;
        const float sikakuSize = 200f;

        ////光
        //BasicEffect basicEffect;
        ////Texture2D texture;
        //GraphicsDevice graphics;
        //BasicEffect effect;
        //VertexPositionNormalTexture[] vertices;

        

        //モデル移動制御
        Vector3 logVec = Vector3.Zero;
        private float gravity = -9.8f;
        Vector3 vec0 = Vector3.Zero;
        Vector3 veci;

        private bool air = false;
        private bool logBotton = false;
        private bool boxue = false;

        ///// <summary>
        ///// アニメーションデータ
        ///// </summary>
        private SkinningData skinningData;

        /// <summary>
        /// アニメーションプレーヤー
        /// </summary>
        private AnimationPlayer animationPlayer;

        /// <summary>
        /// クリップ名配列のインデックス
        /// </summary>
        int clipIndex;

        /// <summary>
        /// クリップ名配列
        /// これはこのサンプルで使用しているC_Skinman.fbxに組み込まれているものです。
        /// </summary>
        //string[] clipNames = { "idle", "walk", "jump", "run", "set", "ready", "winner", "appeal" };

        private enum ClipNames
        {
            idle,
            walk,
            jump,
            run,
            set,
            ready,
            winner,
            appeal
        };




        /// <summary>
        /// アニメーションのループ再生フラグ
        /// </summary>
        bool loopEnable;

        /// <summary>
        /// アニメーションの一時停止フラグ
        /// </summary>
        bool pauseEnable;

        /// <summary>
        /// アニメーションのスローモーション再生速度
        /// １より大きくなるにしたがって再生速度が遅くなります。
        /// </summary>
        int slowMotionOrder;
        int slowMotionCount;

        /// <summary>
        /// ワールド変換行列
        /// </summary>
        private Matrix worldMatrix;

        /// <summary>
        /// 位置
        /// </summary>
        private Vector3 position;
        private Vector3 oldposition;
        private Vector3 matrixPosition = new Vector3(10, 30, 0);
        private bool flg = true;
        private GamePadState oldGamePad;
        private GamePadState gamePad;

        /// <summary>
        /// 回転量
        /// </summary>
        private Vector3 rotation;

        /// <summary>
        /// スプライトバッチ
        /// </summary>
        private SpriteBatch spriteBatch;

        /// <summary>
        /// スプライトフォント
        /// </summary>
        private SpriteFont font;

        /////<summary>
        ///// アニメーションボーン系
        /////</summary> 
        public Matrix[] Bone;
        //private float stickCount = 2.0f;
        //private Vector3 stickMovePosition = new Vector3(0.0f);
        //private Vector3 vecCount = new Vector3(0.0f);
        //private Matrix moveMatrix;

        /// <summary>
        /// 各モデルデータの一時置き場
        /// </summary>
        public Model model;

        public Model sikaku;

        public Model ground;

        public Model renga;
        public Model renga2;

        public Model stage;
        public Model stage2;
        public Model stage3;

        public Model prince;

        public Model bridge;
        public Model dartClif;
        public Model backDartClif;
        public Model glassClif;
        public Model backGlassClif;
        public Model gRoad;
        public Model needle;
        public Model stone;
        public Model stoneRoad;

        public BoundingBox hitModel;
        public BoundingBox dropPoint;
        public BoundingBox drop2Point;
        public BoundingBox airBox;

        /// <summary>
        /// 各ボーンの一時置き場
        /// </summary>
        public Matrix[] sikakuTransform;
        public Matrix[] groundTransform;
        public Matrix[] rengaTransform;
        public Matrix[] renga2Transform;
        public Matrix[] stageTransform;
        public Matrix[] stage2Transform;
        public Matrix[] stage3Transform;
        public Matrix[] princeTransform;
        //最終的な奴
        public Matrix[] gRoadTransform;
        public Matrix[] gClifTransform;
        public Matrix[] dartClifTransform;
        public Matrix[] backDartClifTransform;
        public Matrix[] stoneTransform;
        public Matrix[] stoneRoadTransform;
        public Matrix[] needleTransform;
        public Matrix[] bridgeTransform;

        /// <summary>
        /// 各Positionの一時置き場
        /// </summary>
        public Vector3 princePosition;
        public Vector3 dropPosition;
        public Vector3 drop2Position;
        public Vector3 airBoxPosition;
        public Vector3 rengaPosition;
        public Vector3 renga2Position;
        public Vector3 stagePosition;
        public Vector3 stage2Position;
        public Vector3 stage3Position;
        //この下が最終てきな奴。
        public Vector3[] gRoadPosition = new Vector3[50];
        public Vector3[] gClifPosition = new Vector3[20];
        public Vector3[] backClifPosition = new Vector3[20];
        public Vector3[] dartClifPosition = new Vector3[50];
        public Vector3[] backDartCilfPosition = new Vector3[50];
        public Vector3[] stonePosition = new Vector3[25];
        public Vector3[] stoneRoadPosition = new Vector3[20];
        public Vector3[] needlePosition = new Vector3[30];
        public Vector3[] bridgePosition = new Vector3[5];

        /// <summary>
        /// 各行列の一時置き場
        /// </summary>
        public Matrix princeWorld;
        public Matrix sikakuWorld;
        public Matrix airBoxWorld;
        public Matrix rengaWorld;
        public Matrix renga2World;
        public Matrix stageWorld;
        public Matrix stage2World;
        public Matrix stage3World;
        //この下が最終的な奴。
        public Matrix[] gRoadWorld = new Matrix[50];
        public Matrix[] gClifWorld = new Matrix[20];
        public Matrix[] dartClifWorld = new Matrix[50];
        public Matrix[] backDartClifWorld = new Matrix[50];
        public Matrix[] stoneWorld = new Matrix[25];
        public Matrix[] stoneRoadWorld = new Matrix[20];
        public Matrix[] needleWorld = new Matrix[30];
        public Matrix[] bridgeWorld = new Matrix[5];
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Game1()
        {
            // デバイスマネージャの生成する
            graphics = new GraphicsDeviceManager(this);

            mainComponent = new MainComponent(this);
            // コンテントのディレクトリを"Content"に設定する
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 720;

            Components.Add(mainComponent);
        }
        #endregion

        #region 初期化
        /// <summary>
        /// 初期化のタイミングにフレームワークから呼び出されます
        /// </summary>
        protected override void Initialize()
        {
            // インプットマネージャーの初期化
            InputManager.Initialize();

            //// アニメーション用データを初期化
            InitializeAnimationValue();

            // 各種座標データを初期化
            InitializeCoordinateValue();
            
            base.Initialize();
        }

        /// <summary>
        /// アニメーション用の変数を初期化
        /// </summary>6
        private void InitializeAnimationValue()
        {
            // クリップ名配列インデックスを初期化
            clipIndex = 0;

            // ループ再生を有効
            loopEnable = true;

            // 一時停止フラグを無効
            pauseEnable = false;

            // スローモーション速度を等速
            slowMotionOrder = 0;
            slowMotionCount = 0;
        }

        /// <summary>0.
        /// 座標データの初期化
        /// </summary>
        private void InitializeCoordinateValue()
        {
            position = Vector3.Zero;
            rotation = Vector3.Zero;
            worldMatrix = Matrix.Identity;

            float scale = 0.5f;
            float rotation_float = 0.0f; //3.16
            float h = 0f;

            princePosition = new Vector3(0.0f, 180.0f, 0.0f);
            princeWorld = Matrix.CreateTranslation(princePosition);// *Matrix.CreateScale(scale);

            dropPosition = new Vector3(170.0f, -80.0f, 00.0f);
            sikakuWorld = Matrix.CreateTranslation(dropPosition);

            drop2Position = new Vector3(2335.0f, -200.0f, 00.0f);

            airBoxPosition = new Vector3(2705.0f, 150.0f, 00.0f); //2700
            airBoxWorld = Matrix.CreateTranslation(airBoxPosition);

            rengaPosition = new Vector3(-1550.0f, 000.0f, 00.0f);  //X:-1763.33 Y:-4.666978 Z:0
            rengaWorld = Matrix.CreateTranslation(rengaPosition);

            renga2Position = new Vector3(-200.0f, 00.0f, 000.0f);
            renga2World = Matrix.CreateTranslation(renga2Position);


            ////
            //////こっから新データ
            ////
            scale = 10.0f;
            rotation_float = 3.16f; //3.16
            
            //
            //道。
            //
            for (int i = 0; i < 6; i++) //-40 ... 60  //0 ... 5
            {
                gRoadPosition[i] = new Vector3(-40.0f + (20.0f * i), -10.0f, 0.0f);
            }
            

            for (int i = 0; i < 6; i++) //160 ... 220 //6 ... 10
            {
                gRoadPosition[i+6] = new Vector3(140.0f + (20.0f * i), -10.0f, 0.0f);
            }

            gRoadPosition[11] = new Vector3(240, 10.0f, 0.0f);

            for (int i = 0; i < 3; i++) //260 ... 340 //12 ... 14
            {
                gRoadPosition[i + 12] = new Vector3(260 + (20.0f * i ), 30.0f, 0.0f);
            }

            for (int i = 0; i < 7; i++) //480 ... 600 //15 ... 21
            {
                gRoadPosition[i + 15] = new Vector3(480.0f + (20.0f * i) , 30.0f, 0.0f);
            }

            gRoadPosition[22] = new Vector3(620.0f, 10.0f, 0.0f);
            gRoadPosition[23] = new Vector3(760.0f, -30.0f, 0.0f);

            for (int i = 0; i < 6; i++) //780 ... 880 //24 ... 29
            {
                gRoadPosition[i + 24] = new Vector3(780.0f + ( 20.0f * i), 70.0f, 0.0f);
            }

            gRoadPosition[30] = new Vector3(980.0f, 10.0f, 0.0f);

            for (int i = 0; i < 31; i++)
            {
                gRoadWorld[i] = Matrix.CreateTranslation(gRoadPosition[i]) * Matrix.CreateScale(scale);
            }


            //
            //崖の中身、間？
            //
            for (int i = 0; i < 5; i++) //0...4
            {
                dartClifPosition[i] = new Vector3(-40.0f, -10.0f+(20.0f * i), 0.0f);
            }

            for (int i = 0; i < 6; i++) //5...9
            {
                dartClifPosition[i + 5] = new Vector3(80.0f, -30.0f + (-20.0f * i), 0.0f);
            }
            for (int i = 0; i < 8; i++) //10...16
            {
                dartClifPosition[i + 10] = new Vector3(320.0f, 10.0f + (-20.0f * i), 0.0f);
            }

            for (int i = 0; i < 6; i++) //17...23
            {
                dartClifPosition[i + 17] = new Vector3(400.0f, -10.0f + (-20.0f * i), 0.0f);
            }

            for (int i = 0; i < 7; i++) //23...28
            {
                dartClifPosition[23 + i] = new Vector3(640.0f, -10.0f + (-20.0f*i), 0.0f);
            }
            for (int i = 0; i < 10; i++) //28 ... 37
            {
                dartClifPosition[29 + i] = new Vector3(900.0f, 50.0f + (-20.0f * i), 0.0f);
            }

            for (int i = 0; i < 38; i++)
            {
                dartClifWorld[i] = Matrix.CreateTranslation(dartClifPosition[i]) * Matrix.CreateScale(scale);
            }

            //反転崖の中身。
            for(int i = 0; i < 6; i++) //0...5
            {
                backDartCilfPosition[i] = new Vector3(120.0f, -30.0f + (-20.0f * i), 0.0f);
            }
            for (int i = 0; i < 6; i++) //5...10
            {
                backDartCilfPosition[i + 5] = new Vector3(380.0f, -10.0f + (-20.0f * i), 0.0f);
            }
            for (int i = 0; i < 8; i++) //11...17
            {
                backDartCilfPosition[i + 11] = new Vector3(460.0f, 10.0f + (-20.0f * i), 0.0f);
            }

            backDartCilfPosition[18] = new Vector3(740.0f, -50.0f, 0.0f);

            for(int i = 0; i < 4; i++) //19 ... 22
            {
                backDartCilfPosition[i + 19] = new Vector3(760.0f, 50.0f+(-20.0f * i), 0.0f);
            }

            for (int i = 0; i < 7; i++) //23 .. 29
            {
                backDartCilfPosition[i + 23] = new Vector3(960.0f, -10.0f + (-20.0f * i), 0.0f);
            }

            for (int i = 0; i < 29; i++)
            {
                backDartClifWorld[i] = Matrix.CreateRotationY(rotation_float) * Matrix.CreateTranslation(backDartCilfPosition[i]) * Matrix.CreateScale(scale);
            }

            
            //石壁
            for (int i = 0; i < 8; i++)  //-130 ... 270 //0 ... 7
            {
                stonePosition[i] = new Vector3(900.0f, -130.0f + (-20.0f*i), 0.0f);
            }
            for (int i = 0; i < 4; i++) //-130 ... 190 //8 ... 11 
            {
                stonePosition[i + 8] = new Vector3(960.0f, -130.0f + (-20.0f * i), 0.0f);
            }
            for (int i = 0; i < 6; i++) //980...1060 //12...17
            {
                stonePosition[i + 12] = new Vector3(980.0f + (20.0f * i), -190.0f, 0.0f);
            }
            for (int i = 0; i < 3; i++) //1180 ... 1220 //18 ...20
            {
                stonePosition[i + 18] = new Vector3(1160.0f + (20.0f * i), -190.0f, 0.0f);
            }

            for (int i = 0; i < 21; i++)
            {
                stoneWorld[i] = Matrix.CreateTranslation(stonePosition[i]) * Matrix.CreateScale(scale);
            }
            //石道
            for (int i = 0; i < 9; i++) //0 ... 8
            {
                stoneRoadPosition[i] = new Vector3(920.0f + (20.0f*i), -270.0f, 0.0f);
            }
            for (int i = 0; i < 3; i++) //9 .. 12
            {
                stoneRoadPosition[i + 9] = new Vector3(1160.0f + (20.0f*i), -270.0f, 0.0f);
            }
            for (int i = 0; i < 12; i++)
            {
                stoneRoadWorld[i] = Matrix.CreateTranslation(stoneRoadPosition[i]) * Matrix.CreateScale(scale);
            }
            //
            //崖自体。
            //
            gClifPosition[0] = new Vector3(-40.0f, 90.0f, 0.0f);
            gClifPosition[1] = new Vector3(80.0f, -10.21f, 0.0f);
            gClifPosition[2] = new Vector3(123.0f, -10.21f, 0.0f); //
            gClifPosition[3] = new Vector3(220.0f, 10.0f, 0.0f);//
            gClifPosition[4] = new Vector3(240.0f, 29.79f, 0.0f);//
            gClifPosition[5] = new Vector3(320.0f, 29.79f, 0.0f);
            gClifPosition[6] = new Vector3(380.0f, 10.0f, 0.0f); //
            gClifPosition[7] = new Vector3(400.0f, 10.0f, 0.0f);
            gClifPosition[8] = new Vector3(460.0f, 29.79f, 0.0f); //
            gClifPosition[9] = new Vector3(620.0f, 29.79f, 0.0f);
            gClifPosition[10] = new Vector3(640.0f, 09.81f, 0.0f);
            gClifPosition[11] = new Vector3(740.0f, -29.81f, 0.0f);//
            gClifPosition[12] = new Vector3(760.0f, 70.0f, 0.0f);//
            gClifPosition[13] = new Vector3(900.0f, 70.0f, 0.0f);
            gClifPosition[14] = new Vector3(960.0f, 10.0f, 0.0f);//

            gClifWorld[0] = Matrix.CreateTranslation(gClifPosition[0]) * Matrix.CreateScale(scale);
            gClifWorld[1] = Matrix.CreateTranslation(gClifPosition[1]) * Matrix.CreateScale(scale);
            gClifWorld[5] = Matrix.CreateTranslation(gClifPosition[5]) * Matrix.CreateScale(scale);
            gClifWorld[7] = Matrix.CreateTranslation(gClifPosition[7]) * Matrix.CreateScale(scale);
            gClifWorld[9] = Matrix.CreateTranslation(gClifPosition[9]) * Matrix.CreateScale(scale);
            gClifWorld[10] = Matrix.CreateTranslation(gClifPosition[10]) * Matrix.CreateScale(scale);
            gClifWorld[13] = Matrix.CreateTranslation(gClifPosition[13]) * Matrix.CreateScale(scale);
            //↓崖反対側
            gClifWorld[2] = Matrix.CreateRotationY(rotation_float) * Matrix.CreateTranslation(gClifPosition[2]) * Matrix.CreateScale(scale);
            gClifWorld[3] = Matrix.CreateRotationY(rotation_float) * Matrix.CreateTranslation(gClifPosition[3]) * Matrix.CreateScale(scale);
            gClifWorld[4] = Matrix.CreateRotationY(rotation_float) * Matrix.CreateTranslation(gClifPosition[4]) * Matrix.CreateScale(scale);
            gClifWorld[6] = Matrix.CreateRotationY(rotation_float) * Matrix.CreateTranslation(gClifPosition[6]) * Matrix.CreateScale(scale);
            gClifWorld[8] = Matrix.CreateRotationY(rotation_float) * Matrix.CreateTranslation(gClifPosition[8]) * Matrix.CreateScale(scale);
            gClifWorld[11] = Matrix.CreateRotationY(rotation_float) * Matrix.CreateTranslation(gClifPosition[11]) * Matrix.CreateScale(scale);
            gClifWorld[12] = Matrix.CreateRotationY(rotation_float) * Matrix.CreateTranslation(gClifPosition[12]) * Matrix.CreateScale(scale);
            gClifWorld[14] = Matrix.CreateRotationY(rotation_float) * Matrix.CreateTranslation(gClifPosition[14]) * Matrix.CreateScale(scale);

            //トゲ
            needlePosition[0] = new Vector3(100.0f, -50.0f, 0.0f);
            needlePosition[1] = new Vector3(340.0f, -30.0f, 0.0f);
            needlePosition[2] = new Vector3(360.0f, -30.0f, 0.0f);
            needlePosition[3] = new Vector3(420.0f, -30.0f, 0.0f);
            needlePosition[4] = new Vector3(440.0f, -30.0f, 0.0f);
            for (int i = 0; i < 5; i++) //5 ... 9 
            {
                needlePosition[i + 5] = new Vector3(660.0f + (20.0f*i), -50.0f, 0.0f);
            }
            for (int i = 0; i < 3; i++) //9 .. 11
            {
                needlePosition[i + 9] = new Vector3(1100.0f + (20.0f*i), -270.0f, 0.0f); 
            }
            for (int i = 0; i < 3; i++) //12 ... 14
            {
                needlePosition[i + 12] = new Vector3(1100.0f + (20.0f*i), -190.0f, 0.0f);
            }
            for (int i = 0; i < 11; i++)
            {
                needlePosition[i + 15] = new Vector3(1000.0f+(20.0f*i), 10.0f, 0.0f);
            }

            for (int i = 0; i < 12; i++)
            {
                needleWorld[i] = Matrix.CreateTranslation(needlePosition[i]) * Matrix.CreateScale(scale);
            }
            for (int i = 0; i < 3; i++) //12 ... 14
            {
                needleWorld[i + 12] = Matrix.CreateRotationZ(rotation_float) * Matrix.CreateTranslation(needlePosition[i + 12]) * Matrix.CreateScale(scale);
            }
            for (int i = 0; i < 11; i++) //15...26
            {
                needleWorld[i + 15] = Matrix.CreateTranslation(needlePosition[i + 15]) * Matrix.CreateScale(scale);
            }

            //bridgePosition[0] = new Vector3(80.0f, 50.0f, 0.0f);
            //bridgeWorld[0] = Matrix.CreateTranslation(bridgePosition[0]) * Matrix.CreateScale(scale);

            Vector3 vec = Vector3.Zero;

            dropPoint.Min = new Vector3(-sikakuSize * 0.47f) + dropPosition - vec;
            dropPoint.Max = new Vector3(sikakuSize * 0.47f) + dropPosition - vec;

            drop2Point.Min = new Vector3(-sikakuSize * 1.22f) + drop2Position - vec;
            drop2Point.Max = new Vector3(sikakuSize * 1.22f) + drop2Position - vec;

            airBox.Min = new Vector3(-sikakuSize * 0.37f) + airBoxPosition - vec;
            airBox.Max = new Vector3(sikakuSize * 0.37f) + airBoxPosition - vec;

            hitModel.Min = new Vector3(-10.0f, 0.0f, -10.0f) + mainComponent.boneComponent.position;
            hitModel.Max = new Vector3(10.0f, 0.0f, 10.0f) + mainComponent.boneComponent.position;
        }

        #endregion

        #region コンテンツの読み込み処理
        /// <summary>
        /// コンテンツ読み込みのタイミングにフレームワークから呼び出されます
        /// </summary>
        protected override void LoadContent()
        {
            // スプライトバッチの作成
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // スプライトフォントの作成
            font = Content.Load<SpriteFont>(@"SpriteFont1");

            LoadSkinnedModel(@"princeandslime");

            SetStageTransform();

            Bone = animationPlayer.GetSkinTransforms();

            mainComponent.boneComponent.Bone = Bone;
            //@"C_Skinman"
            //prince
            //surfer
        }
        ///<summary>
        ///ステージのボーン設定
        ///</summary>
        private void SetStageTransform()
        {
            sikakuTransform = new Matrix[sikaku.Bones.Count];
            sikaku.CopyAbsoluteBoneTransformsTo(sikakuTransform);

            groundTransform = new Matrix[ground.Bones.Count];
            ground.CopyAbsoluteBoneTransformsTo(groundTransform);

            rengaTransform = new Matrix[renga.Bones.Count];
            renga.CopyAbsoluteBoneTransformsTo(rengaTransform);

            renga2Transform = new Matrix[renga2.Bones.Count];
            renga2.CopyAbsoluteBoneTransformsTo(renga2Transform);

            stageTransform = new Matrix[stage.Bones.Count];
            stage.CopyAbsoluteBoneTransformsTo(stageTransform);

            stage2Transform = new Matrix[stage2.Bones.Count];
            stage2.CopyAbsoluteBoneTransformsTo(stage2Transform);

            stage3Transform = new Matrix[stage3.Bones.Count];
            stage3.CopyAbsoluteBoneTransformsTo(stage3Transform);

            princeTransform = new Matrix[prince.Bones.Count];
            prince.CopyAbsoluteBoneTransformsTo(princeTransform);

            gRoadTransform = new Matrix[gRoad.Bones.Count];
            gRoad.CopyAbsoluteBoneTransformsTo(gRoadTransform);

            gClifTransform = new Matrix[glassClif.Bones.Count];
            glassClif.CopyAbsoluteBoneTransformsTo(gClifTransform);

            dartClifTransform = new Matrix[dartClif.Bones.Count];
            dartClif.CopyAbsoluteBoneTransformsTo(dartClifTransform);

            stoneTransform = new Matrix[stone.Bones.Count];
            stone.CopyAbsoluteBoneTransformsTo(stoneTransform);

            stoneRoadTransform = new Matrix[stoneRoad.Bones.Count];
            stoneRoad.CopyAbsoluteBoneTransformsTo(stoneRoadTransform);

            needleTransform = new Matrix[needle.Bones.Count];
            needle.CopyAbsoluteBoneTransformsTo(needleTransform);

            bridgeTransform = new Matrix[bridge.Bones.Count];
            needle.CopyAbsoluteBoneTransformsTo(needleTransform);

            //backDartClifTransform = new Matrix[backDartClif.Bones.Count];
            //backDartClif.CopyAbsoluteBoneTransformsTo(backDartClifTransform);
        }

        /// <summary>
        /// スキンモデルの読み込み処理
        /// </summary>
        private void LoadSkinnedModel(string assetName)
        {
            // モデルを読み込む
            prince = Content.Load<Model>(assetName);

            sikaku = Content.Load<Model>("sikaku");

            ground = Content.Load<Model>("yuka");

            renga = Content.Load<Model>("Nomal brick");
            renga2 = Content.Load<Model>("Nomalbrick2");

            stage = Content.Load<Model>("stage1-1"); //ichi
            stage2 = Content.Load<Model>("stage1-2"); //ni
            stage3 = Content.Load<Model>("stage1-3");
                            
            bridge = Content.Load<Model>("Model\\bridge");
            dartClif = Content.Load<Model>("Model\\dart_clif");
            //backDartClif = Content.Load<Model>("Model\\dart_clif_back");
            glassClif = Content.Load<Model>("Model\\glass_clif");
            //backGlassClif = Content.Load<Model>("Model\\glass_clif_back");
            gRoad = Content.Load<Model>("Model\\glass_road");
            needle = Content.Load<Model>("Model\\needle");
            stone = Content.Load<Model>("Model\\stone");
            stoneRoad = Content.Load<Model>("Model\\stone_road");

            // SkinningDataを取得
            skinningData = prince.Tag as SkinningData;

            if (skinningData == null)
                throw new InvalidOperationException
                    ("This model does not contain a SkinningData tag.");

            // AnimationPlayerを作成
            animationPlayer = new AnimationPlayer(skinningData);

            // アニメーションを再生する
            ChangeAnimationClip("Take 001", loopEnable, 0.0f);


            vec0.X = 9.8f; vec0.Y = 30f;
            veci.X = 5000f; veci.Y = 30f;
        }
        #endregion

        #region コンテンツの解放処理
        /// <summary>
        /// コンテンツ解放のタイミングにフレームワークから呼び出されます
        /// </summary>
        protected override void UnloadContent()
        {
        }
        #endregion

        #region アニメーションの操作
        /// <summary>
        /// アニメーションの切替処理
        /// </summary>
        public void ChangeAnimationClip(string clipName, bool loop, float weight)
        {
            // クリップ名からAnimationClipを取得して再生する
            AnimationClip clip = skinningData.AnimationClips[clipName];

            animationPlayer.StartClip(clip);
        }
        #endregion

        #region ゲームの更新処理
        /// <summary>
        /// アップデートのタイミングにフレームワークから呼び出されます
        /// </summary>
        /// <param name="gameTime">ゲームタイム</param>
        protected override void Update(GameTime gameTime)
        {
            // インプットマネージャーのアップデート
            InputManager.Update();

            // 終了ボタンのチェック
            if (InputManager.IsJustKeyDown(Keys.Escape) || InputManager.IsJustButtonDown(PlayerIndex.One, Buttons.Back))
                Exit();

            // 入力を取得する
            UpdateInput(gameTime);

            mainComponent.cameraComponent.camera.Target = mainComponent.boneComponent.position;            
            Console.WriteLine("position = " + mainComponent.boneComponent.position);

            // アニメーションの更新
            UpdateAnimation(gameTime, true, worldMatrix);

            oldGamePad = gamePad;
            gamePad = GamePad.GetState(PlayerIndex.One);

            //デバッグ用（ボタンひとつでゴール）
            if (gamePad.IsButtonDown(Buttons.Start) && oldGamePad.IsButtonUp(Buttons.Start) && flg == true)
            {
                flg = false;
            }
            else if (gamePad.IsButtonDown(Buttons.Start) && oldGamePad.IsButtonUp(Buttons.Start) && flg == false)
            {
                flg = true;
            }
            
            base.Update(gameTime);
        }        

        /// <summary>
        /// アニメーションの更新
        /// </summary>
        private void UpdateAnimation(GameTime gameTime, bool relativeToCurrentTime, Matrix transform)
        {
            // 一時停止状態でないか？
            if (pauseEnable)
                return;

            // スローモーションが有効か？
            if (slowMotionOrder > 0)
            {
                if (slowMotionCount > 0)
                {
                    slowMotionCount--;
                    return;
                }
                slowMotionCount = slowMotionOrder;
            }

            // アニメーションの更新
            animationPlayer.Update(gameTime.ElapsedGameTime, true, transform);
        }
        #endregion

        #region 入力による処理
        /// <summary>
        /// 入力による処理
        /// </summary>
        private void UpdateInput(GameTime gameTime)
        {
            // モデルの座標を更新
            UpdateModelCoordinates(gameTime);

            // アニメーションの操作
            animationPlayer.Update(gameTime.ElapsedGameTime, true, Matrix.Identity);
        }

        /// <summary>
        /// モデルの座標を更新
        /// </summary>
        private void UpdateModelCoordinates(GameTime gameTime)
        {
            // 移動速度として取得
            float velocity = (float)gameTime.ElapsedGameTime.TotalMilliseconds * 0.1f;

            // 計算用のベクトル
            Vector3 vec = Vector3.Zero;
            Vector3 logVec = Vector3.Zero;
            //oldposition = mainComponent.boneComponent.position;
            oldposition = position;


            // 左右スティックの入力を取得する
            Vector2 leftStick = Vector2.Zero;
            Vector2 rightStick = Vector2.Zero;

            leftStick = InputManager.GetThumbSticksLeft(PlayerIndex.One);
            rightStick = InputManager.GetThumbSticksRight(PlayerIndex.One);

            //vec.Z = leftStick.Y * 0;
            vec.X = leftStick.X;

            if (leftStick.X >= 0.5f)
            {
                vec.X = leftStick.X * 6;
                clipIndex = 2;
            }
            else if (leftStick.X <= -0.5)
            {
                vec.X = leftStick.X * 6;
                clipIndex = 2;
            }
            else
            {
                vec.X = leftStick.X;
                clipIndex = 1;
            }

            if (leftStick.Y >= 0.5f)
            {
                vec.Y = leftStick.Y * 6;
            }
            else if (leftStick.Y <= -0.5)
            {
                vec.Y = leftStick.Y * 6;
            }
            else
            {
                vec.Y = leftStick.Y;
            }


            if (mainComponent.boneComponent.position.Y != 0)
            {
                air = true;
            }

            //ジャンプ //キーボもパッドも一緒。

            if (InputManager.IsKeyDown(Keys.Space) && logBotton == false || InputManager.IsButtonDown(PlayerIndex.One, Buttons.A) && logBotton == false)
            {

                if (position.Y <= 400)
                {
                    vec.Y = 5.0f;
                }
                else
                {
                    vec.Y = 0f;
                    logBotton = true;
                }

                air = true;

            }

            else if (InputManager.IsKeyUp(Keys.Space) || InputManager.IsButtonUp(PlayerIndex.One, Buttons.A))
            {
                logBotton = true;
            }
            

            // 左右移動
            if (InputManager.IsKeyDown(Keys.Left))
            {
                vec.X = -1f;

                if (InputManager.IsKeyDown(Keys.LeftShift) || InputManager.IsKeyDown(Keys.RightShift))
                {
                    vec.X = vec.X * 4f;
                    clipIndex = 2;
                }

            }
            if (InputManager.IsKeyDown(Keys.Right))
            {
                vec.X = 1f;

                if (InputManager.IsKeyDown(Keys.LeftShift) || InputManager.IsKeyDown(Keys.RightShift))
                {
                    vec.X = vec.X * 4f;
                    clipIndex = 2;
                }

                if (vec.X == -10f || vec.X == 10)
                {
                    vec.X = logVec.X;
                }
            }
            // 入力があったときのみ処理する(入力がなければ長さは0.0fとなるため)
            if (vec.Length() == 0.0f)
            {
                clipIndex = 0;
            }

            if (vec.Length() > 0.0f)
            {
                clipIndex = 1;

                if (InputManager.IsKeyDown(Keys.LeftShift) || InputManager.IsKeyDown(Keys.RightShift))
                {
                    clipIndex = 3;
                }

                if (vec.X > 0)
                {
                    rotation.Y = MathHelper.ToRadians(90);
                }

                if(vec.X < 0)
                {
                    rotation.Y = MathHelper.ToRadians(-90);
                }
                if (vec.Z < 0)
                {
                    rotation.Y = MathHelper.ToRadians(180);
                }
                if (vec.Z > 0)
                {
                    rotation.Y = MathHelper.ToRadians(0);
                }

                if (vec.X > 0 && vec.Z > 0)
                {
                    rotation.Y = MathHelper.ToRadians(45);
                }
                else if (vec.X > 0 && vec.Z < 0)
                {
                    rotation.Y = MathHelper.ToRadians(135);
                }
                if (vec.X < 0 && vec.Z > 0)
                {
                    rotation.Y = MathHelper.ToRadians(-45);
                }
                else if (vec.X < 0 && vec.Z < 0)
                {
                    rotation.Y = MathHelper.ToRadians(-135);
                }

            }
            //if (hitModel.Intersects(airBox) || hitModel.Intersects(airBox))
            //{
            //    vec.Y = 0;
            //    position = oldposition;

            //    if (vec.X != 0)
            //    {
            //        vec.X = 0;
            //    }
            //}

            //if (vec.Y == 0)
            //{
            //    if (mainComponent.boneComponent.position.Y >= 0)
            //    {
            //        vec.Y = gravity; //-3.6f;
            //    }
            //    if (mainComponent.boneComponent.position.Y <= 0 || hitModel.Intersects(dropPoint))
            //    {
            //        air = false;
            //        logBotton = false;
            //        vec.Y = 0f;
            //    }
            //    vec0.X = 9.8f; vec0.Y = 9.8f;
            //    //if (hitModel.Intersects(dropPoint) || hitModel.Intersects(drop2Point))
            //    //{
            //    //    vec.Y = gravity;
            //    //}
            //    //else if (mainComponent.boneComponent.position.Y <= -30.0f)
            //    //{
            //    //    mainComponent.boneComponent.position.Y = 9.8f;
            //    //    mainComponent.boneComponent.position.X = 30f;
            //    //    hitModel.Max = vec0;
            //    //    hitModel.Min = vec0;
            //    //}
            //    if (mainComponent.boneComponent.position.Y < -200)
            //    {
            //        mainComponent.boneComponent.position.Y = 9.8f;
            //        mainComponent.boneComponent.position.X = 30f;
            //        hitModel.Max = vec0;
            //        hitModel.Min = vec0;
            //    }

            //}
            if (air == true)
            {
                clipIndex = 2;
            }


            mainComponent.boneComponent.position += vec * velocity;
                        
            hitModel.Max += vec;
            hitModel.Min += vec;
            
            // 回転行列の作成
            Matrix rotationMatrix = Matrix.CreateRotationX(rotation.X) *
                                    Matrix.CreateRotationY(rotation.Y) *
                                    Matrix.CreateRotationZ(rotation.Z);

            // 平行移動行列の作成
            Matrix translationMatrix = Matrix.CreateTranslation(mainComponent.boneComponent.position);

            // ワールド変換行列を計算する
            // モデルを拡大縮小し、回転した後、指定の位置へ移動する。
            worldMatrix = rotationMatrix * translationMatrix;

            //右スティック押し込みで位置をリセット
            if (InputManager.IsJustButtonDown(PlayerIndex.One, Buttons.RightStick) || InputManager.IsJustKeyDown(Keys.R))
            {
                mainComponent.boneComponent.position.Y = 9.8f;      mainComponent.boneComponent.position.X = 9.8f;
                hitModel.Max = vec0;    hitModel.Min = vec0;
            }
            
        }

        ///// <summary>
        ///// アニメーションの操作
        ///// </summary>
        //private void UpdateAnimationControl(GameTime gameTime)
        //{
        //    // 範囲を超えたら初期化
        //    if (slowMotionOrder <= 0)
        //    {
        //        slowMotionOrder = 0;
        //        slowMotionCount = 0;
        //    }

        //    // 一時停止操作
        //    if (InputManager.IsJustButtonDown(PlayerIndex.One, Buttons.Start) || InputManager.IsJustKeyDown(Keys.V))
        //        pauseEnable = (pauseEnable) ? false : true;

        //    // クリップ名変更操作
        //    if (InputManager.IsJustPressedDPadUp(PlayerIndex.One) || InputManager.IsJustKeyDown(Keys.W))
        //    {
        //        clipIndex++;
        //        loopEnable = true;

        //        // ループ再生を禁止するか？
        //        if (InputManager.IsButtonDown(PlayerIndex.One, Buttons.B) || InputManager.IsKeyDown(Keys.LeftControl))
        //            loopEnable = false;

        //    }
        //    if (InputManager.IsJustPressedDPadDown(PlayerIndex.One) || InputManager.IsJustKeyDown(Keys.S))
        //    {
        //        clipIndex--;
        //        loopEnable = true;

        //        // ループ再生を禁止するか？
        //        if (InputManager.IsButtonDown(PlayerIndex.One, Buttons.B) || InputManager.IsKeyDown(Keys.LeftControl))
        //            loopEnable = false;
        //    }

        //    // 範囲を超えたら初期化
        //    if (clipIndex >= clipNames.Length)
        //        clipIndex = clipNames.Length - 1;
        //    if (clipIndex < 0)
        //        clipIndex = 0;

        //    //// クリップに変更があったか？
        //    //if (animationPlayer.CurrentClip.Name.CompareTo(clipNames[clipIndex]) != 0)
        //    //    // クリップを切り替える
        //    //    ChangeAnimationClip(clipNames[clipIndex], loopEnable, 0.0f);


        //    // 初期値に戻す
        //    if (InputManager.IsJustButtonDown(PlayerIndex.One, Buttons.X) || InputManager.IsJustKeyDown(Keys.N))
        //    {
        //        // アニメーション用データを初期化
        //        InitializeAnimationValue();
        //        // クリップを切り替える
        //        ChangeAnimationClip(clipNames[0], true, 0.0f);
        //    }
        //}
        #endregion

        #region ゲームの描画処理
        /// <summary>
        /// 描画のタイミングにフレームワークから呼び出されます
        /// </summary>
        /// <param name="gameTime">ゲームタイム</param>
        protected override void Draw(GameTime gameTime)
        {
            if (flg == true)
            {
                graphics.GraphicsDevice.Clear(Color.Black); //ConrflowerBlue

                //背景を塗りつぶす
                //if (hitModel.Intersects(airBox))
                //{
                //    graphics.GraphicsDevice.Clear(Color.Red);
                //}
                //else
                //{
                //    graphics.GraphicsDevice.Clear(Color.Black);
                //}


                Matrix[] bones = animationPlayer.GetSkinTransforms();
                Matrix view = mainComponent.cameraComponent.camera.View;
                Matrix projection = mainComponent.cameraComponent.camera.Projection;

                DrawModel(renga, rengaTransform, rengaWorld);

                //DrawModel(stage, stageTransform, stageWorld);
                //DrawModel(stage2, stage2Transform, stage2World);
                //DrawModel(stage3, stage3Transform, stage3World);

                
                for (int i = 0; i < 31; i++) //道
                {
                    DrawModel(gRoad, gRoadTransform, gRoadWorld[i]);
                }
                for (int i = 0; i < 38; i++) //崖中身
                {
                    DrawModel(dartClif, dartClifTransform, dartClifWorld[i]);
                }
                for (int i = 0; i < 29; i++) //崖中身反転
                {
                    DrawModel(dartClif, dartClifTransform, backDartClifWorld[i]);
                }
                for (int i = 0; i < 21; i++) //石壁　天井
                {
                    DrawModel(stone, stoneTransform, stoneWorld[i]);
                }
                for (int i = 0; i < 12; i++) //石床
                {
                    DrawModel(stoneRoad, stoneRoadTransform, stoneRoadWorld[i]);
                }
                for (int i = 0; i < 15; i++) //崖頭
                {
                    DrawModel(glassClif, gClifTransform, gClifWorld[i]);
                }
                for (int i = 0; i < 27; i++) //トゲ
                {
                    DrawModel(needle, needleTransform, needleWorld[i]);
                }
                DrawModel(bridge, bridgeTransform, bridgeWorld[0]);

                // モデルを描画
                foreach (ModelMesh mesh in prince.Meshes)
                {
                    string name = mesh.Name;
                    foreach (SkinnedEffect effect in mesh.Effects)
                    {
                        effect.SetBoneTransforms(mainComponent.boneComponent.Bone);
                        effect.View = view;
                        effect.Projection = projection;
                        effect.World = princeTransform[mesh.ParentBone.Index] * princeWorld;
                    }

                    mesh.Draw();
                }
            }
            else if (flg == false)
            {
                graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
                spriteBatch.Begin();
                spriteBatch.DrawString(font, "GOAL", new Vector2(0,0), Color.White);
                spriteBatch.End();
            }

            base.Draw(gameTime);
        }
        #endregion

        //★　追加
        private void DrawModel(Model model, Matrix[] transforms, Matrix world)
        {
            //モデル内のメッシュをすべて描画する
            foreach (ModelMesh mesh in model.Meshes)
            {
                //メッシュ内のエフェクトに対してパラメータを設定する
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.PreferPerPixelLighting = true;

                    //デフォルトライティングを有効にする
                    effect.EnableDefaultLighting();

                    //必要な行列を設定する
                    effect.View = mainComponent.cameraComponent.camera.View;
                    effect.Projection = mainComponent.cameraComponent.camera.Projection;
                    effect.World = transforms[mesh.ParentBone.Index] * world;

                    effect.DirectionalLight0.Enabled = true;
                    effect.DirectionalLight1.Enabled = false;
                    effect.DirectionalLight2.Enabled = false;
                }

                //メッシュの描画
                mesh.Draw();
            }
        }
    }
}
