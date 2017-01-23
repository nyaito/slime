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
    public class Player : CharacterData
    {
        #region フィールド

        Vector2 leftStick = InputManager.GetThumbSticksLeft(PlayerIndex.One);

        public SkinningData charaModelSkinningData;

        public AnimationPlayer charaModelAnimation;

        int clipIndex;

        string[] clipNames = { "", "", "" };

        enum ClipNames
        {

        };

        bool loopEnable;

        bool pauseEnable;

        //移動量
        protected float moveVec = 5.0f;

        #endregion

        #region コンストラクタ

        public Player(Model modelData)
        {
            characterModel = modelData;
        }
        #endregion

        #region プレイヤーを操作する

        public void OperateCharacter()
        {
            #region 左右に移動する処理
            if (leftStick.X > 0.0f)
            {
                charaModelPosition.X += moveVec;
                //clipIndex = "clipIndexの値";
            }
            else if (leftStick.X < 0.0f)
            {
                charaModelPosition.X -= moveVec;
                //clipIndex = "clipIndexの値";
            }
            #endregion

            InputManager.Update();
        }
        #endregion

        #region アニメーションの切替
        public void ChangeAnimationClip(string clipName, bool loop, float weight)
        {
            AnimationClip clip = charaModelSkinningData.AnimationClips[clipName];

            charaModelAnimation.StartClip(clip, loop, weight);
        }
        #endregion

        #region アニメーション更新
        public void UpdateAnimation(GameTime gameTime, bool relativeToCurrentTime, Matrix transform)
        {
            charaModelAnimation.Update(gameTime.ElapsedGameTime, true, transform);

        }
        #endregion

        #region アニメーションの実行・停止

        public void UpdateAnimationControl(GameTime gameTime)
        {
            pauseEnable = (pauseEnable) ? false : true;
        }
        #endregion

        #region プレイヤー情報を更新

        public void UpdateModelCoordinates(GameTime gameTime)
        {
            #region 行列更新 拡大・縮小 * 回転 * 平行移動

            //拡大・縮小行列
            Matrix scaleMatrix = Matrix.CreateScale(scaleData);
            
            //回転行列
            Matrix rotationMatrix = Matrix.CreateRotationX(charaModelRotation.X) *
                                    Matrix.CreateRotationY(charaModelRotation.Y) *
                                    Matrix.CreateRotationZ(charaModelRotation.Z);

            //平行移動行列
            Matrix translationMatrix = Matrix.CreateTranslation(charaModelPosition);
            #endregion

            //Playerの行列を更新
            charaModelWorld = scaleData * rotationMatrix * translationMatrix;

        }
        #endregion

    }
}
