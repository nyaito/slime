using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    
    public class Player : ModelData
    {

        #region フィールド

        public SkinningData playerSkinningData;

        public AnimationPlayer playerAnimation;

        private AnimationClip playerClip;        

        int clipIndex = 0;

        public string[] clipNames = { "stayRight", "stayLeft", "Run" };

        enum ClipNames
        {
            stayRight,
            stayLeft,
            Run
        };

        bool loopEnable = true;


        Vector2 leftStick;
        Vector3 jumpPosition = Vector3.Zero;
        private GamePadState oldState;
        private GamePadState currentState;
        private bool jumpFlg = false;
        private bool air_StopFlg = false;
        private bool warp_Flg = false;
        public bool checkHit = false;
        private int jumpCount = 0;
        private const float jumpFps = 30;
        private const float FPS = 60;
        private int Acount = 0;

        //当たり判定
        private Vector3 boundingSize = new Vector3(10.0f,14.0f,10.0f);

        //初期座標、初期角度
        private Vector3 initialize_Position = Vector3.Zero;
        private Vector3 initialize_Rotation = new Vector3(MathHelper.ToRadians(0.0f),MathHelper.ToRadians(0.0f),MathHelper.ToRadians(0.0f));

        //移動量
        private float moveVec = 1.0f;
        private float jumpVec = 0.5f;
        

        private Vector3 oldPosition = Vector3.Zero;


        #region 拡大・縮小、回転、平行移動行列

        private Matrix scaleMatrix = Matrix.Identity;
        private Matrix rotationMatrix = Matrix.Identity;
        private Matrix translationMatrix = Matrix.Identity;

        #endregion

        #endregion

        #region コンストラクタ
        public Player(Camera playerCamera)
        {
            camera = playerCamera;
        }
        #endregion

        #region プレイヤー読み込み
        public void PlayerLoad()
        {
            modelTransform = new Matrix[modelData.Bones.Count];
            modelData.CopyAbsoluteBoneTransformsTo(modelTransform);

            playerSkinningData = modelData.Tag as SkinningData;
            playerAnimation = new AnimationPlayer(playerSkinningData);
            
            ChangeAnimationClip(clipNames[clipIndex],loopEnable,0.0f);
        }
        #endregion

        #region プレイヤー要素を初期化
        public void Initialize_element()
        {          

            //プレイヤーの角度、座標を初期化
            modelPosition = initialize_Position;
            modelRotation = initialize_Rotation;

            modelHitBox.Min = (-boundingSize * 0.5f) + modelPosition;
            modelHitBox.Max = (boundingSize * 1.0f) + modelPosition;

        }
        #endregion

        #region アニメーションの切り替え
        public void ChangeAnimationClip(string clipName, bool loop, float weight)
        {
            playerClip = playerSkinningData.AnimationClips[clipName];

            playerAnimation.StartClip(playerClip, loop, weight);
            
        }
        #endregion

        #region ループをするかをチェック
        public bool LoopCheck(bool loop)
        {
            return loop;
        }   

        #endregion

        #region キャラクターを操作する
        public void OperateCharacter()
        {
            #region ジャンプ処理(実装)
            if (currentState.IsButtonDown(Buttons.B) && oldState.IsButtonUp(Buttons.B) && jumpFlg == false)
            {
                jumpFlg = true;
                jumpPosition.Y = modelPosition.Y;
            }

            //ジャンプボタンを押したらカウントが進む
            if (jumpFlg == true && air_StopFlg == false)
            {
                jumpCount++;
            }

            //カウントが60を超えてなければ上に上昇する
            if (jumpCount <= jumpFps && jumpFlg == true && air_StopFlg == false)
            {
                modelPosition.Y += jumpVec;

                modelHitBox.Min.Y += jumpVec;

                modelHitBox.Max.Y += jumpVec;

            }
            //下に下降する
            else if (jumpCount >= jumpFps && jumpPosition.Y < modelPosition.Y)
            {
                modelPosition.Y -= jumpVec;
                modelHitBox.Min.Y -= jumpVec;
                modelHitBox.Max.Y -= jumpVec;
            }

            //ジャンプする前の高さになったら全てリセットをして停止する
            if (jumpPosition.Y >= modelPosition.Y && jumpCount > jumpFps || jumpPosition.Y == modelPosition.Y && warp_Flg == true)
            {
                jumpFlg = false;
                warp_Flg = false;
                jumpPosition.Y = modelPosition.Y;
                jumpCount = 0;
            }

            #endregion

            #region ワープ移動(実装?)←岸本

            //空中停止をする処理
            if (currentState.IsButtonDown(Buttons.A) && air_StopFlg == false && modelPosition.Y > 0)
            {
                air_StopFlg = true;
                //warp_Flg = true;
                clipIndex = 0;
                //ある距離だけ移動する処理
            }
       
            if (currentState.IsButtonUp(Buttons.A) && air_StopFlg == true)
            {
                air_StopFlg = false;
            }

            if (air_StopFlg == true && leftStick.Length() > 0.0f)
            {
                modelPosition.X += leftStick.X * 2.5f;
                modelPosition.Y += leftStick.Y * 2.5f;

                modelHitBox.Min.X += leftStick.X * 2.5f;
                modelHitBox.Min.Y += leftStick.Y * 2.5f;

                modelHitBox.Max.X += leftStick.X * 2.5f;
                modelHitBox.Max.Y += leftStick.Y * 2.5f;
                air_StopFlg = false;
                warp_Flg = true;

            }

            #endregion

            #region 左右に移動する処理(実装)

            //ジャンプしていない場合の移動
            if (jumpFlg == false && air_StopFlg == false)
            {
                RunMove();
            }
            //ジャンプしているときの移動
            else if (jumpFlg == true && air_StopFlg == false)
            {
                JumpMove();
            }
            #endregion         

        }

        #region ジャンプしていないときの移動←岸本
            private void RunMove()
            {
                    if (leftStick.X > 0.0f)
                    {
                        if (checkHit == false)
                        {
                            modelPosition.X += leftStick.X * moveVec;
                            modelHitBox.Min.X += leftStick.X * moveVec;
                            modelHitBox.Max.X += leftStick.X * moveVec;
                            clipIndex = 2;
                        }
                        //else
                        //{
                        //    modelPosition.X -= moveVec;
                        //    modelHitBox.Min.X -= moveVec;
                        //    modelHitBox.Max.X -= moveVec;
                        //    clipIndex = 2;
                        //}
                       
                    }
                    else if (leftStick.X < 0.0f)
                    {
                        if (checkHit == false)
                        {
                            modelPosition.X += leftStick.X * moveVec;
                            modelHitBox.Min.X += leftStick.X * moveVec;
                            modelHitBox.Max.X += leftStick.X * moveVec;
                            clipIndex = 2;
                        }
                        //else
                        //{
                        //    modelPosition.X += moveVec;
                        //    modelHitBox.Min.X += moveVec;
                        //    modelHitBox.Max.X += moveVec;
                        //    clipIndex = 2;
                        //}
                    }
                    else if (leftStick.X == 0.0f)
                    {
                        clipIndex = 0;
                    }
                
            }
        #endregion

            #region ジャンプしているときの移動
            private void JumpMove()
            {
                if (leftStick.X > 0.0f)
                {
                    modelPosition.X += moveVec;
                    modelHitBox.Min.X += moveVec;
                    modelHitBox.Max.X += moveVec;
                    clipIndex = 2;
                }
                else if (leftStick.X < 0.0f)
                {
                    modelPosition.X -= moveVec;
                    modelHitBox.Min.X -= moveVec;
                    modelHitBox.Max.X -= moveVec;
                    clipIndex = 2;
                }
                else if (leftStick.X == 0.0f)
                {
                    clipIndex = 0;
                }
            }

            #endregion  
     
        #endregion     

        #region Playerクラスの更新
        public void PlayerUpdate(GameTime playerTime)
        {
            //課題
            //当たり判定の実装

            leftStick = InputManager.GetThumbSticksLeft(PlayerIndex.One);

            oldState = currentState;
            currentState = GamePad.GetState(PlayerIndex.One);

            oldPosition = modelPosition;

            OperateCharacter();
            
            modelWorld = ModelMatrix(modelRotation, modelPosition);

            playerAnimation.Update(playerTime.ElapsedGameTime, true, modelWorld);

            // クリップに変更があったか？
            if (playerAnimation.CurrentClip.Name.CompareTo(clipNames[clipIndex]) != 0)
                // クリップを切り替える
                ChangeAnimationClip(clipNames[clipIndex], loopEnable, 0.0f);

            camera.Target = (modelPosition + new Vector3(20.0f,15.0f,0.0f)) * 2;
            camera.Update(playerTime);

        }
        #endregion

        #region プリンスの描画
        public void ModelDraw(GameTime gameTime)
        {
            Matrix[] bones = playerAnimation.GetSkinTransforms();
            Matrix view = camera.View;
            Matrix projection = camera.Projection;

            foreach (ModelMesh mesh in modelData.Meshes)
            {
                string name = mesh.Name;
                foreach (SkinnedEffect effect in mesh.Effects)
                {
                    effect.Alpha = 1.0f;
                    effect.SetBoneTransforms(bones);
                    effect.View = view;
                    effect.Projection = projection;
                    effect.World = modelTransform[mesh.ParentBone.Index] * modelWorld;
                    effect.AmbientLightColor = Vector3.One;
                }

                mesh.Draw();
            }
        }
        #endregion

    }
}
