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

namespace Prince_rapidity_99
{
    /// <summary>
    /// 基底 Game クラスから派生した、ゲームのメイン クラスです。
    /// </summary>
    public class PlayComponent: Microsoft.Xna.Framework.DrawableGameComponent
    {
        #region フィールド
        
        /// <summary>
        /// カメラ
        /// </summary>
        public Camera camera;
        private GraphicsDeviceManager graphicsDeviceManager;

        Player Prince;

        private int glassRoadCount;
        private int dartClifCount;
        private int glassClifCount;
        private int stoneCount;
        private int stoneRoadCount;
        private int needleCount;
        private int dartCount;
        private int hitBoxCount;


        Vector3[] glassRoadPosition = new Vector3[32];

        Vector3[] glassClifPosition = new Vector3[15];

        Vector3[] dartClifPosition = new Vector3[73];

        Vector3[] stonePosition = new Vector3[242];

        Vector3[] stoneRoadPosition = new Vector3[9];

        Vector3[] needlePosition = new Vector3[30];

        Vector3[] dartPosition = new Vector3[312];

        Vector3 stagePosition;


        GlassRoad[] glassRoad = new GlassRoad[32];
        GlassClif[] glassClif = new GlassClif[15];
        DartClif[] dartClif = new DartClif[73];
        Stone[] stone = new Stone[242];
        StoneRoad[] stoneRoad = new StoneRoad[9];
        Needle[] needle = new Needle[30];
        Dart[] dart = new Dart[312];
        Stage stage;

        bool ended = false;
        bool[] glassRoadFlg = new bool[32];
        bool[] DartClifFlg = new bool[73];
        bool[] glassClifFlg = new bool[15];
        bool[] stoneFlg = new bool[242];
        bool[] stoneRoadFlg = new bool[9];
        bool[] needleFlg = new bool[30];
        bool[] dartFlg = new bool[312];
        bool[] stageFlg = new bool[100];


        Vector3 rot = Vector3.Zero;

        #region 追加のフィールド
        DynamicVertexBuffer vertexBuffer = null;
        BasicEffect basicEffect = null;

        const int numberOfVertex = 24;  // 頂点数
        const int numberOfBox = 2;      // 箱の数
        int totalOfVertex;              //

        const float boxSize = 20.0f;   // 箱の１辺の長さ

        VertexPositionColor[] vertexes;　//

        private GamePadState padState;   //

        Vector3 boxPosition1;           // 箱の位置
        Vector3 boxPosition2;           //
        Vector3 boxPosition3;

        Vector3[] stageRoadPositon = new Vector3[57];
        Vector3[] stageStonePosition = new Vector3[15];
        Vector3[] stageNeedlePosition = new Vector3[12];

        BoundingBox box1;
        BoundingBox box2;
        BoundingBox box3;

        BoundingBox[] stageRoad = new BoundingBox[57];
        BoundingBox[] stageStone = new BoundingBox[15];
        BoundingBox[] stageNeedle = new BoundingBox[12];

        bool hit = false;

        #endregion

        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PlayComponent(Game game,GraphicsDeviceManager graphicsManager,Camera MainCamera) : base(game)
        {
            camera = MainCamera;
            graphicsDeviceManager = graphicsManager;
        }
        #endregion

        #region 初期化
        /// <summary>
        /// 初期化のタイミングにフレームワークから呼び出されます
        /// </summary>
        public override void Initialize()
        {
            // インプットマネージャーの初期化
            InputManager.Initialize();

            Prince = new Player(camera);

            #region //道 glassRoadPosition

            //int glassRoadPoint = 0;
            for (int count = 0; count < 6; count++)
            { //6
                glassRoadPosition[glassRoadCount] = new Vector3(-40.0f + (20.0f * count), -10.0f, 0.0f);
                glassRoadCount++;
            }

            for (int count = 0; count < 6; count++)
            { //12
                glassRoadPosition[glassRoadCount] = new Vector3(140.0f + (20.0f * count), -10.0f, 0.0f);
                glassRoadCount++;
            }
            glassRoadPosition[glassRoadCount] = new Vector3(240, 10.0f, 0.0f); //13
            glassRoadCount++;

            for (int count = 0; count < 3; count++)
            { //16
                glassRoadPosition[glassRoadCount] = new Vector3(260 + (20.0f * count), 30.0f, 0.0f);
                glassRoadCount++;
            }

            for (int count = 0; count < 7; count++)
            { //23
                glassRoadPosition[glassRoadCount] = new Vector3(480.0f + (20.0f * count), 30.0f, 0.0f);
                glassRoadCount++;
            }

            glassRoadPosition[glassRoadCount] = new Vector3(620.0f, 10.0f, 0.0f);      //24 
            glassRoadCount++;

            glassRoadPosition[glassRoadCount] = new Vector3(760.0f, -30.0f, 0.0f);     //25 
            glassRoadCount++;

            for (int count = 0; count < 6; count++) //31
            {
                glassRoadPosition[glassRoadCount] = new Vector3(780.0f + (20.0f * count), 70.0f, 0.0f);
            }

            glassRoadPosition[glassRoadCount] = new Vector3(980.0f, 10.0f, 0.0f); //32       
            glassRoadCount++;

            #endregion

            #region //崖頭 glassClifPosition
            glassClifPosition[0] = new Vector3(-40.0f, 90.0f, 0.0f);
            glassClifPosition[1] = new Vector3(80.0f, -10.00f, 0.0f);
            glassClifPosition[2] = new Vector3(320.0f, 30.0f, 0.0f);
            glassClifPosition[3] = new Vector3(400.0f, 10.0f, 0.0f);
            glassClifPosition[4] = new Vector3(620.0f, 30.0f, 0.0f);
            glassClifPosition[5] = new Vector3(640.0f, 10.0f, 0.0f);
            glassClifPosition[6] = new Vector3(900.0f, 70.0f, 0.0f);
            //こっから反対
            glassClifPosition[7] = new Vector3(120.0f, -10.0f, 0.0f);
            glassClifPosition[8] = new Vector3(220.0f, 10.0f, 0.0f);
            glassClifPosition[9] = new Vector3(240.0f, 29.79f, 0.0f);
            glassClifPosition[10] = new Vector3(380.0f, 10.0f, 0.0f);
            glassClifPosition[11] = new Vector3(460.0f, 29.79f, 0.0f);
            glassClifPosition[12] = new Vector3(740.0f, -29.81f, 0.0f);
            glassClifPosition[13] = new Vector3(760.0f, 70.0f, 0.0f);
            glassClifPosition[14] = new Vector3(960.0f, 10.0f, 0.0f);

            glassClifCount = 15;
            #endregion

            #region //壁中身 dartClifPosition
            dartClifCount = 0;
            for (int i = 0; i < 4; i++)
            { //4
                dartClifPosition[dartClifCount] = new Vector3(-40.0f, 10.0f + (20.0f * i), 0.0f);
                dartClifCount++;
            }

            for (int i = 0; i < 5; i++)
            { //9
                dartClifPosition[dartClifCount] = new Vector3(80.0f, -30.0f + (-20.0f * i), 0.0f);
                dartClifCount++;
            }

            for (int i = 0; i < 7; i++)
            { //16
                dartClifPosition[dartClifCount] = new Vector3(320.0f, 10.0f + (-20.0f * i), 0.0f);
                dartClifCount++;
            }

            for (int i = 0; i < 6; i++)
            { //22
                dartClifPosition[dartClifCount] = new Vector3(400.0f, -10.0f + (-20.0f * i), 0.0f);
                dartClifCount++;
            }

            for (int i = 0; i < 7; i++)
            { //29
                dartClifPosition[dartClifCount] = new Vector3(640.0f, -10.0f + (-20.0f * i), 0.0f);
                dartClifCount++;
            }
            for (int i = 0; i < 10; i++)
            { //39
                dartClifPosition[dartClifCount] = new Vector3(900.0f, 50.0f + (-20.0f * i), 0.0f);
                dartClifCount++;
            }

            for (int i = 0; i < 5; i++) //44
            {
                dartClifPosition[dartClifCount] = new Vector3(120.0f, -30.0f + (-20.0f * i), 0.0f);
                dartClifCount++;
            }
            for (int i = 0; i < 6; i++) //50
            {
                dartClifPosition[dartClifCount] = new Vector3(380.0f, -10.0f + (-20.0f * i), 0.0f);
                dartClifCount++;
            }
            for (int i = 0; i < 8; i++) //58
            {
                dartClifPosition[dartClifCount] = new Vector3(460.0f, 10.0f + (-20.0f * i), 0.0f);
                dartClifCount++;
            }

            for (int i = 0; i < 4; i++) //62
            {
                dartClifPosition[dartClifCount] = new Vector3(740.0f, -50.0f + (-20.0f * i), 0.0f);
                dartClifCount++;
            }

            for (int i = 0; i < 4; i++) //66
            {
                dartClifPosition[dartClifCount] = new Vector3(760.0f, 50.0f + (-20.0f * i), 0.0f);
                dartClifCount++;
            }

            for (int i = 0; i < 6; i++) //72
            {
                dartClifPosition[dartClifCount] = new Vector3(960.0f, -10.0f + (-20.0f * i), 0.0f);
                dartClifCount++;
            }


            #endregion

            #region  //石壁　stonePosition

            for (int i = 0; i < 8; i++)
            { //8
                stonePosition[stoneCount] = new Vector3(900.0f, -130.0f + (-20.0f * i), 0.0f);
                stoneCount++;
            }
            for (int i = 0; i < 4; i++)
            { //12
                stonePosition[stoneCount] = new Vector3(960.0f, -130.0f + (-20.0f * i), 0.0f);
                stoneCount++;
            }
            for (int i = 0; i < 6; i++)
            { //18
                stonePosition[stoneCount] = new Vector3(980.0f + (20.0f * i), -190.0f, 0.0f);
                stoneCount++;
            }
            for (int i = 0; i < 3; i++)
            { //21
                stonePosition[stoneCount] = new Vector3(1160.0f + (20.0f * i), -190.0f, 0.0f);
                stoneCount++;
            }

            for (int i = 0; i < 8; i++)
            {
                for (int y = 0; y < 8; y++)
                { //85
                    stonePosition[stoneCount] = new Vector3(740.0f + (20.0f * y), -130.0f + (-20.0f * i), 0.0f);
                    stoneCount++;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int y = 0; y < 12; y++)
                {//121
                    stonePosition[stoneCount] = new Vector3(980.0f + (20.0f * y), -130.0f + (-20.0f * i), 0.0f);
                    stoneCount++;
                }
            }

            stonePosition[stoneCount] = new Vector3(1160.0f, -210.0f, 0.0f);
            stoneCount++; //122

            for (int i = 0; i < 5; i++)
            {
                for (int y = 0; y < 24; y++) //242
                {
                    stonePosition[stoneCount] = new Vector3(740.0f + (20.0f * y), -290.0f + (-20.0f * i), 0.0f);
                    stoneCount++;
                }
            }

            #endregion

            #region //石道  stoneRoadPosition
            stoneRoadCount = 0;
            for (int i = 0; i < 6; i++) //6
            {
                stoneRoadPosition[stoneRoadCount] = new Vector3(980.0f + (20.0f * i), -270.0f, 0.0f);
                stoneRoadCount++;
            }
            for (int i = 0; i < 3; i++) //9
            {
                stoneRoadPosition[stoneRoadCount] = new Vector3(1160.0f + (20.0f * i), -270.0f, 0.0f);
                stoneRoadCount++;
            }

            #endregion

            #region //針　needle

            needleCount = 0;
            needlePosition[0] = new Vector3(100.0f, -50.0f, 0.0f);
            needlePosition[1] = new Vector3(340.0f, -30.0f, 0.0f);
            needlePosition[2] = new Vector3(360.0f, -30.0f, 0.0f);
            needlePosition[3] = new Vector3(420.0f, -30.0f, 0.0f);
            needlePosition[4] = new Vector3(440.0f, -30.0f, 0.0f);

            needleCount = 5; //5
            for (int i = 0; i < 4; i++)
            { //9
                needlePosition[needleCount] = new Vector3(660.0f + (20.0f * i), -50.0f, 0.0f);
                needleCount++;
            }
            for (int i = 0; i < 3; i++)
            { //12
                needlePosition[needleCount] = new Vector3(1100.0f + (20.0f * i), -270.0f, 0.0f);
                needleCount++;
            }
            for (int i = 0; i < 3; i++)
            { //15
                needlePosition[needleCount] = new Vector3(1100.0f + (20.0f * i), -190.0f, 0.0f);
                needleCount++;
            }
            for (int i = 0; i < 11; i++)
            { //26
                needlePosition[needleCount] = new Vector3(1000.0f + (20.0f * i), 10.0f, 0.0f);
                needleCount++;
            }

            for (int i = 0; i < 3; i++)
            { //29
                needlePosition[needleCount] = new Vector3(920.0f + (20.0f * i), -270.0f, 0.0f);
                needleCount++;
            }

            needlePosition[needleCount] = new Vector3(940.0f, -130.0f, 0.0f);
            needleCount++; //30


            #endregion

            #region //土 dartPosition
            dartCount = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int y = 0; y < 6; y++) //30
                {
                    dartPosition[dartCount] = new Vector3(-40.0f + (20.0f * y), -30.0f + (-20.0f * i), 0.0f);
                    dartCount++;
                }
            }

            for (int i = 0; i < 5; i++)
            {
                for (int y = 0; y < 9; y++) //75
                {
                    dartPosition[dartCount] = new Vector3(-60.0f + (-20.0f * i), 70.0f + (-20.0f * y), 0.0f);
                    dartCount++;
                }
            }

            for (int i = 0; i < 5; i++)
            {
                for (int y = 0; y < 9; y++) //120
                {
                    dartPosition[dartCount] = new Vector3(140.0f + (20.0f * y), -30.0f + (-20.0f * i), 0.0f);
                    dartCount++;
                }
            }

            for (int i = 0; i < 2; i++)
            {
                for (int y = 0; y < 3; y++) //126
                {
                    dartPosition[dartCount] = new Vector3(260.0f + (20.0f * y), 10.0f + (-20.0f * i), 0.0f);
                    dartCount++;
                }
            }

            dartPosition[dartCount] = new Vector3(240.0f, -10.0f, 0.0f);
            dartCount++; //127

            for (int i = 0; i < 7; i++)
            {
                for (int y = 0; y < 7; y++) //176
                {
                    dartPosition[dartCount] = new Vector3(480.0f + (20.0f * y), 10.0f + (-20.0f * i), 0.0f);
                    dartCount++;
                }
            }

            for (int i = 0; i < 6; i++) //182
            {
                dartPosition[dartCount] = new Vector3(620.0f, -10.0f + (-20.0f * i), 0.0f);
                dartCount++;
            }

            for (int i = 0; i < 9; i++)
            {
                for (int y = 0; y < 6; y++) //236
                {
                    dartPosition[dartCount] = new Vector3(780.0f + (20.0f * y), 50.0f + (-20.0f * i), 0.0f);
                    dartCount++;
                }
            }

            for (int i = 0; i < 4; i++) //240
            {
                dartPosition[dartCount] = new Vector3(760.0f, -50.0f + (-20.0f * i), 0.0f);
                dartCount++;
            }

            for (int i = 0; i < 6; i++)
            {
                for (int y = 0; y < 12; y++)
                {
                    dartPosition[dartCount] = new Vector3(980.0f + (20.0f * y), -10.0f + (-20.0f * i), 0.0f);
                    dartCount++;
                }
            }


            #endregion

            #region //ゴール辺り stagePosition

            stagePosition = new Vector3(1220.0f, -450.0f, 0.0f);

            #endregion



            for (int count = 0; count < glassRoadCount; count++)
            {
                glassRoad[count] = new GlassRoad(camera);
            }

            for (int count = 0; count < glassClifCount; count++)
            {
                glassClif[count] = new GlassClif(camera);
            }
            //反対の向きのモデル
            for (int count = 7; count < glassClifCount; count++)
            {
                glassClif[count].modelRotation = new Vector3(0.0f, 180.0f, 0.0f);
            }

            for (int count = 0; count < dartClifCount; count++)
            {
                dartClif[count] = new DartClif(camera);
            }
            for (int count = 39; count < dartClifCount; count++)
            {
                dartClif[count].modelRotation = new Vector3(0.0f, 180.0f, 0.0f);
            }

            for (int count = 0; count < stoneCount; count++)
            {
                stone[count] = new Stone(camera);
            }

            for (int count = 0; count < stoneRoadCount; count++)
            {
                stoneRoad[count] = new StoneRoad(camera);
            }

            for (int count = 0; count < needleCount; count++)
            {
                needle[count] = new Needle(camera);
            }

            for (int count = 0; count < dartCount; count++)
            {
                dart[count] = new Dart(camera);
            }

            stage = new Stage(camera);

            base.Initialize();
        }

        #endregion

        #region コンテンツの読み込み処理
        /// <summary>
        /// コンテンツ読み込みのタイミングにフレームワークから呼び出されます
        /// </summary>
        protected override void LoadContent()
        {            
            PrinceInitialize();
            Prince.Initialize_element();
            StageModelInitialize();
            #region 追加の読み込み
            basicEffect = new BasicEffect(GraphicsDevice);

            // 頂点カラーを有効にする
            basicEffect.VertexColorEnabled = true;

            basicEffect.View = camera.View;
            basicEffect.Projection = camera.Projection;
            // 頂点バッファ作成
            totalOfVertex = numberOfVertex * numberOfBox;
            vertexBuffer = new DynamicVertexBuffer(GraphicsDevice,
                typeof(VertexPositionColor), totalOfVertex, BufferUsage.None);

            vertexes = new VertexPositionColor[totalOfVertex];

            // 箱の初期位置
            boxPosition1 = new Vector3(-20.0f, -10.0f, 0.0f);
            boxPosition2 = new Vector3(200.0f, 0.0f, 0.0f);
            boxPosition3 = new Vector3(100.0f, 0.0f, 300.0f);

            CreateBox(0, boxSize, boxPosition1);    // 箱1
            CreateBox(1, boxSize, boxPosition2);    // 箱2

            // 頂点バッファをセット
            vertexBuffer.SetData(vertexes, 0, vertexBuffer.VertexCount, SetDataOptions.NoOverwrite);

            box1.Min = new Vector3(-boxSize * 0.5f) + boxPosition1;
            box1.Max = new Vector3(boxSize * 0.5f) + boxPosition1;

            box2.Min = new Vector3(-boxSize * 0.5f) + boxPosition2;
            box2.Max = new Vector3(boxSize * 0.5f) + boxPosition2;

            #endregion

            #region ミツハシの弄った場所。

            #region 土Position
            stageRoadPositon[0] = new Vector3(1340.0f, -390.0f, 0.0f);
            stageRoadPositon[1] = new Vector3(1360.0f, -390.0f, 0.0f);
            stageRoadPositon[2] = new Vector3(1380.0f, -390.0f, 0.0f);
            stageRoadPositon[3] = new Vector3(1400.0f, -390.0f, 0.0f);
            stageRoadPositon[4] = new Vector3(1420.0f, -390.0f, 0.0f);
            stageRoadPositon[5] = new Vector3(1440.0f, -390.0f, 0.0f);
            
            stageRoadPositon[6] = new Vector3(1440.0f, -370.0f, 0.0f);
            stageRoadPositon[7] = new Vector3(1460.0f, -350.0f, 0.0f);
            stageRoadPositon[8] = new Vector3(1460.0f, -370.0f, 0.0f);

            stageRoadPositon[9] = new Vector3(1480.0f, -330.0f, 0.0f);
            stageRoadPositon[10] = new Vector3(1480.0f, -350.0f, 0.0f);
            stageRoadPositon[11] = new Vector3(1480.0f, -370.0f, 0.0f);
            stageRoadPositon[12] = new Vector3(1480.0f, -390.0f, 0.0f);

            stageRoadPositon[13] = new Vector3(1340.0f, -270.0f, 0.0f);
            stageRoadPositon[14] = new Vector3(1340.0f, -290.0f, 0.0f);
            stageRoadPositon[15] = new Vector3(1340.0f, -310.0f, 0.0f);

            stageRoadPositon[16] = new Vector3(1360.0f, -290.0f, 0.0f);
            stageRoadPositon[17] = new Vector3(1360.0f, -310.0f, 0.0f);

            stageRoadPositon[18] = new Vector3(1380.0f, -290.0f, 0.0f);
            stageRoadPositon[19] = new Vector3(1380.0f, -310.0f, 0.0f);

            stageRoadPositon[20] = new Vector3(1440.0f, -310.0f, 0.0f);

            stageRoadPositon[21] = new Vector3(1380.0f, -250.0f, 0.0f);
            stageRoadPositon[22] = new Vector3(1400.0f, -250.0f, 0.0f);
            stageRoadPositon[23] = new Vector3(1420.0f, -250.0f, 0.0f);
            stageRoadPositon[24] = new Vector3(1440.0f, -250.0f, 0.0f);
            stageRoadPositon[25] = new Vector3(1460.0f, -250.0f, 0.0f);
            stageRoadPositon[26] = new Vector3(1480.0f, -250.0f, 0.0f);
            stageRoadPositon[27] = new Vector3(1500.0f, -250.0f, 0.0f);

            stageRoadPositon[28] = new Vector3(1580.0f, -310.0f, 0.0f);
            stageRoadPositon[29] = new Vector3(1580.0f, -330.0f, 0.0f);
            stageRoadPositon[30] = new Vector3(1580.0f, -350.0f, 0.0f);
            stageRoadPositon[31] = new Vector3(1580.0f, -370.0f, 0.0f);
            stageRoadPositon[32] = new Vector3(1580.0f, -390.0f, 0.0f);

            stageRoadPositon[33] = new Vector3(1600.0f, -290.0f, 0.0f);
            stageRoadPositon[34] = new Vector3(1620.0f, -290.0f, 0.0f);
            stageRoadPositon[35] = new Vector3(1640.0f, -290.0f, 0.0f);
            stageRoadPositon[36] = new Vector3(1660.0f, -290.0f, 0.0f);
            stageRoadPositon[37] = new Vector3(1680.0f, -290.0f, 0.0f);

            stageRoadPositon[38] = new Vector3(1700.0f, -210.0f, 0.0f);
            stageRoadPositon[39] = new Vector3(1700.0f, -230.0f, 0.0f);
            stageRoadPositon[40] = new Vector3(1700.0f, -250.0f, 0.0f);
            stageRoadPositon[41] = new Vector3(1700.0f, -270.0f, 0.0f);
            stageRoadPositon[42] = new Vector3(1700.0f, -290.0f, 0.0f);

            stageRoadPositon[43] = new Vector3(1320.0f, 10.0f, 0.0f);
            stageRoadPositon[44] = new Vector3(1320.0f, -10.0f, 0.0f);
            stageRoadPositon[45] = new Vector3(1320.0f, -30.0f, 0.0f);
            stageRoadPositon[46] = new Vector3(1320.0f, -50.0f, 0.0f);
            stageRoadPositon[47] = new Vector3(1320.0f, -70.0f, 0.0f);
            stageRoadPositon[48] = new Vector3(1320.0f, -90.0f, 0.0f);
            stageRoadPositon[49] = new Vector3(1320.0f, -110.0f, 0.0f);
            stageRoadPositon[50] = new Vector3(1320.0f, -130.0f, 0.0f);
            stageRoadPositon[51] = new Vector3(1320.0f, -150.0f, 0.0f);
            stageRoadPositon[52] = new Vector3(1320.0f, -170.0f, 0.0f);
            stageRoadPositon[53] = new Vector3(1320.0f, -190.0f, 0.0f);
            stageRoadPositon[54] = new Vector3(1320.0f, -210.0f, 0.0f);
            stageRoadPositon[55] = new Vector3(1320.0f, -230.0f, 0.0f);
            stageRoadPositon[56] = new Vector3(1320.0f, -250.0f, 0.0f);

            #endregion

            #region 石Position
            stageStonePosition[0] = new Vector3(1220.0f, -190.0f, 0.0f);
            stageStonePosition[1] = new Vector3(1240.0f, -190.0f, 0.0f);
            stageStonePosition[2] = new Vector3(1240.0f, -210.0f, 0.0f);
            stageStonePosition[3] = new Vector3(1240.0f, -230.0f, 0.0f);
            stageStonePosition[4] = new Vector3(1240.0f, -250.0f, 0.0f);
            stageStonePosition[5] = new Vector3(1240.0f, -270.0f, 0.0f);
            stageStonePosition[6] = new Vector3(1260.0f, -270.0f, 0.0f);
            stageStonePosition[7] = new Vector3(1280.0f, -270.0f, 0.0f);
            stageStonePosition[8] = new Vector3(1300.0f, -270.0f, 0.0f);
            stageStonePosition[9] = new Vector3(1320.0f, -270.0f, 0.0f);
            stageStonePosition[10] = new Vector3(1280.0f, -330.0f, 0.0f);
            stageStonePosition[11] = new Vector3(1280.0f, -350.0f, 0.0f);
            stageStonePosition[12] = new Vector3(1280.0f, -370.0f, 0.0f);
            stageStonePosition[13] = new Vector3(1280.0f, -390.0f, 0.0f);
            stageStonePosition[14] = new Vector3(1580.0f, -290.0f, 0.0f);
            #endregion

            #region //針position
            stageNeedlePosition[0] = new Vector3(1220.0f, -330.0f, 0.0f);
            stageNeedlePosition[1] = new Vector3(1240.0f, -330.0f, 0.0f);
            stageNeedlePosition[2] = new Vector3(1260.0f, -330.0f, 0.0f);
            stageNeedlePosition[3] = new Vector3(1300.0f, -390.0f, 0.0f);
            stageNeedlePosition[4] = new Vector3(1320.0f, -390.0f, 0.0f);
            stageNeedlePosition[5] = new Vector3(1400.0f, -310.0f, 0.0f);
            stageNeedlePosition[6] = new Vector3(1420.0f, -310.0f, 0.0f);
            stageNeedlePosition[7] = new Vector3(1500.0f, -390.0f, 0.0f);
            stageNeedlePosition[8] = new Vector3(1520.0f, -390.0f, 0.0f);
            stageNeedlePosition[9] = new Vector3(1540.0f, -390.0f, 0.0f);
            stageNeedlePosition[10] = new Vector3(1560.0f, -390.0f, 0.0f);
            stageNeedlePosition[11] = new Vector3(1580.0f, -270.0f, 0.0f);
            #endregion



            for (int count = 0; count < 57; count++)
            {
                stageRoad[count].Min = new Vector3(-boxSize * 0.5f) + stageRoadPositon[count];
                stageRoad[count].Max = new Vector3(boxSize * 0.5f) + stageRoadPositon[count];
            }
            for (int count = 0; count < 15; count++)
            {
                stageStone[count].Min = new Vector3(-boxSize * 0.5f) + stageStonePosition[count];
                stageStone[count].Max = new Vector3(boxSize * 0.05f) + stageStonePosition[count];
            }
            for (int count = 0; count < 12; count++)
            {
                stageNeedle[count].Min = new Vector3(-boxSize * 0.5f) + stageNeedlePosition[count];
                stageNeedle[count].Max = new Vector3(boxSize * 0.5f) + stageNeedlePosition[count];
            }

            #endregion
        }


        #endregion

        #region ステージデータの読み込み
        private void StageModelInitialize()
        {
            //glassClifの読み込み
            for (int count = 0; count < glassClifCount; count++)
            {
                glassClif[count].modelData = Game.Content.Load<Model>(@"Model\\StageModel\glass_clif");
                glassClif[count].modelPosition = glassClifPosition[count];
                glassClif[count].GlassClifLoad();
            }

            //glassRoadの読み込み
            for (int count = 0; count < glassRoadCount; count++)
            {
                glassRoad[count].modelData = Game.Content.Load<Model>("Model\\StageModel\\glass_road");
                glassRoad[count].modelPosition = glassRoadPosition[count];
                glassRoad[count].GlassRoadLoad();
            }

            //dartClifの読み込み
            for (int count = 0; count < dartClifCount; count++)
            {
                dartClif[count].modelData = Game.Content.Load<Model>("Model\\StageModel\\dart_clif");
                dartClif[count].modelPosition = dartClifPosition[count];
                dartClif[count].DartClifLoad();
            }

            //stoneの読み込み
            for (int count = 0; count < stoneCount; count++)
            {
                stone[count].modelData = Game.Content.Load<Model>("Model\\StageModel\\stone");
                stone[count].modelPosition = stonePosition[count];
                stone[count].StoneLoad();
            }

            //stoneRoadの読み込み
            for (int count = 0; count < stoneRoadCount; count++)
            {
                stoneRoad[count].modelData = Game.Content.Load<Model>("Model\\StageModel\\stone_road");
                stoneRoad[count].modelPosition = stonePosition[count];
                stoneRoad[count].StoneRoadLoad();
            }

            //needleの読み込み
            for (int count = 0; count < needleCount; count++)
            {
                needle[count].modelData = Game.Content.Load<Model>("Model\\StageModel\\needle");
                needle[count].modelPosition = needlePosition[count];
                needle[count].NeedleLoad();
            }

            //dartの読み込み
            for (int count = 0; count < dartCount; count++)
            {
                dart[count].modelData = Game.Content.Load<Model>("Model\\StageModel\\dart");
                dart[count].modelPosition = dartPosition[count];
                dart[count].DartLoad();
            }

            //stageの読み込み
            stage.modelData = Game.Content.Load<Model>("Model\\StageModel\\stage");
            stage.modelPosition = stagePosition;
            stage.StageLoad();

        }
        #endregion

        #region プリンスの初期化
        private void PrinceInitialize()
        {
            Prince.modelData = Game.Content.Load<Model>("Model\\prince_motiondata_base_1129");
            Prince.PlayerLoad();
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

        #region ゲームの更新処理
        /// <summary>
        /// アップデートのタイミングにフレームワークから呼び出されます
        /// </summary>
        /// <param name="gameTime">ゲームタイム</param>
        public override void Update(GameTime gameTime)
        {           
            // 入力を取得する
            Prince.PlayerUpdate(gameTime);
            camera.Update(gameTime);

            for (int count = 0; count < glassRoadCount; count++)
            {
                if (glassRoad[count].modelHitBox.Intersects(Prince.modelHitBox))
                {
                    glassRoadFlg[count] = true;
                }
            }
            for (int count = 0; count < dartClifCount; count++)
            {
                if (dartClif[count].modelHitBox.Intersects(Prince.modelHitBox))
                {
                    DartClifFlg[count] = true;
                }
            }
            for (int count = 0; count < glassClifCount; count++)
            {
                if (glassClif[count].modelHitBox.Intersects(Prince.modelHitBox))
                {
                    glassClifFlg[count] = true;
                }
            }
            for (int count = 0; count < stoneCount; count++)
            {
                if (stone[count].modelHitBox.Intersects(Prince.modelHitBox))
                {
                    stoneFlg[count] = true;
                }
            }
            for (int count = 0; count < stoneRoadCount; count++)
            {
                if (stoneRoad[count].modelHitBox.Intersects(Prince.modelHitBox))
                {
                    stoneRoadFlg[count] = true;
                }
            }
            for (int count = 0; count < needleCount; count++)
            {
                if (needle[count].modelHitBox.Intersects(Prince.modelHitBox))
                {
                   needleFlg[count] = true;
                }
            }
            
        }

        //箱を制作するメソッド
        private void CreateBox(int boxNo, float length, Vector3 center)
        {
            float half = length / 2;
            int i = boxNo * numberOfVertex;

            // 正面
            vertexes[i] = new VertexPositionColor(
                                new Vector3(-half + center.X, -half + center.Y, half + center.Z), Color.Red); i++;
            vertexes[i] = new VertexPositionColor(
                                new Vector3(half + center.X, -half + center.Y, half + center.Z), Color.Red); i++;
            vertexes[i] = new VertexPositionColor(
                                new Vector3(half + center.X, -half + center.Y, half + center.Z), Color.Red); i++;
            vertexes[i] = new VertexPositionColor(
                                new Vector3(half + center.X, half + center.Y, half + center.Z), Color.Red); i++;
            vertexes[i] = new VertexPositionColor(
                                new Vector3(half + center.X, half + center.Y, half + center.Z), Color.Red); i++;
            vertexes[i] = new VertexPositionColor(
                                new Vector3(-half + center.X, half + center.Y, half + center.Z), Color.Red); i++;
            vertexes[i] = new VertexPositionColor(
                                new Vector3(-half + center.X, half + center.Y, half + center.Z), Color.Red); i++;
            vertexes[i] = new VertexPositionColor(
                                new Vector3(-half + center.X, -half + center.Y, half + center.Z), Color.Red); i++;

            // 上面
            vertexes[i] = new VertexPositionColor(
                                new Vector3(-half + center.X, half + center.Y, -half + center.Z), Color.Blue); i++;
            vertexes[i] = new VertexPositionColor(
                                new Vector3(-half + center.X, half + center.Y, half + center.Z), Color.Blue); i++;
            vertexes[i] = new VertexPositionColor(
                                new Vector3(half + center.X, half + center.Y, -half + center.Z), Color.Blue); i++;
            vertexes[i] = new VertexPositionColor(
                                new Vector3(half + center.X, half + center.Y, half + center.Z), Color.Blue); i++;
            vertexes[i] = new VertexPositionColor(
                                new Vector3(half + center.X, half + center.Y, -half + center.Z), Color.Blue); i++;
            vertexes[i] = new VertexPositionColor(
                                new Vector3(-half + center.X, half + center.Y, -half + center.Z), Color.Blue); i++;

            // 下面
            vertexes[i] = new VertexPositionColor(
                                new Vector3(-half + center.X, -half + center.Y, half + center.Z), Color.Green); i++;
            vertexes[i] = new VertexPositionColor(
                                new Vector3(-half + center.X, -half + center.Y, -half + center.Z), Color.Green); i++;
            vertexes[i] = new VertexPositionColor(
                                new Vector3(half + center.X, -half + center.Y, half + center.Z), Color.Green); i++;
            vertexes[i] = new VertexPositionColor(
                                new Vector3(half + center.X, -half + center.Y, -half + center.Z), Color.Green); i++;
            vertexes[i] = new VertexPositionColor(
                                new Vector3(half + center.X, -half + center.Y, -half + center.Z), Color.Green); i++;
            vertexes[i] = new VertexPositionColor(
                                new Vector3(-half + center.X, -half + center.Y, -half + center.Z), Color.Green); i++;

            // 奥面
            vertexes[i] = new VertexPositionColor(
                                new Vector3(-half + center.X, half + center.Y, -half + center.Z), Color.Yellow); i++;
            vertexes[i] = new VertexPositionColor(
                                new Vector3(-half + center.X, -half + center.Y, -half + center.Z), Color.Yellow); i++;
            vertexes[i] = new VertexPositionColor(
                                new Vector3(half + center.X, half + center.Y, -half + center.Z), Color.Yellow); i++;
            vertexes[i] = new VertexPositionColor(
                                new Vector3(half + center.X, -half + center.Y, -half + center.Z), Color.Yellow); i++;

        }
        #endregion

        #region 入力による処理
        /// <summary>
        /// 入力による処理
        /// </summary>

        #endregion

        #region ゲームの描画処理
        /// <summary>
        /// 描画のタイミングにフレームワークから呼び出されます
        /// </summary>
        /// <param name="gameTime">ゲームタイム</param>
        public override void Draw(GameTime gameTime)
        {
            

            //glassClifの描画
            for (int count = 0; count < glassClifCount; count++)
            {
                glassClif[count].ModelDraw(gameTime);
                //if (glassClifFlg[count] == true)
                //{
                //    GraphicsDevice.Clear(Color.Violet);
                //}
            }

            //glassRoadの描画
            for (int count = 0; count < glassRoadCount; count++)
            {
                glassRoad[count].ModelDraw(gameTime);
                //if (glassRoadFlg[count] == true)
                //{
                //    GraphicsDevice.Clear(Color.Yellow);
                //}
            }

            //dartClifの描画
            for (int count = 0; count < dartClifCount; count++)
            {
                dartClif[count].ModelDraw(gameTime);
                //if (DartClifFlg[count] == true)
                //{
                //    GraphicsDevice.Clear(Color.YellowGreen);
                //}
            }
            //stoneの描画
            for (int count = 0; count < stoneCount; count++)
            {
                stone[count].ModelDraw(gameTime);
            }

            //stoneRoadの描画
            for (int count = 0; count < stoneRoadCount; count++)
            {
                stoneRoad[count].ModelDraw(gameTime);
            }

            //needleの描画
            for (int count = 0; count < needleCount; count++)
            {
                needle[count].ModelDraw(gameTime);
            }

            //dartの描画
            for (int count = 0; count < dartCount; count++)
            {
                dart[count].ModelDraw(gameTime);
            }

            //Stageの描画
            stage.ModelDraw(gameTime);

            DefaultDraw();
            Prince.ModelDraw(gameTime);

            GraphicsDevice.SetVertexBuffer(vertexBuffer);
            foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
            {
                // パスの開始
                pass.Apply();
                // LineListで描画
                GraphicsDevice.DrawPrimitives(PrimitiveType.LineList, 0, totalOfVertex / 2);
            }
            base.Draw(gameTime);
        }
        #endregion

        #region ゲーム描画の初期化
        private void DefaultDraw()
        {
            GraphicsDevice.BlendState = BlendState.AlphaBlend;
            GraphicsDevice.DepthStencilState = DepthStencilState.Default;
            GraphicsDevice.SamplerStates[0] = SamplerState.LinearWrap;
        }
        #endregion

        #region 終了フラグを返す
        public bool IsEnded()
        {
            return ended;
        }
        #endregion

    }
}
