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

        
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PlayComponent(Game game,GraphicsDeviceManager graphicsManager) : base(game)
        {
            
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

            base.Initialize();
        }

        #endregion

        #region コンテンツの読み込み処理
        /// <summary>
        /// コンテンツ読み込みのタイミングにフレームワークから呼び出されます
        /// </summary>
        protected override void LoadContent()
        {

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
            // インプットマネージャーのアップデート
            InputManager.Update();

            // 終了ボタンのチェック
            if (InputManager.IsJustKeyDown(Keys.Escape) || InputManager.IsJustButtonDown(PlayerIndex.One, Buttons.Back))
                Game.Exit();

            // 入力を取得する
            UpdateInput(gameTime);

            
            base.Update(gameTime);
        }

        /// <summary>
        /// アニメーションの更新
        /// </summary>
        private void UpdateAnimation(GameTime gameTime, bool relativeToCurrentTime, Matrix transform)
        {
            
        }
        #endregion

        #region 入力による処理
        /// <summary>
        /// 入力による処理
        /// </summary>
        private void UpdateInput(GameTime gameTime)
        {


        }

        #region ゲームの描画処理
        /// <summary>
        /// 描画のタイミングにフレームワークから呼び出されます
        /// </summary>
        /// <param name="gameTime">ゲームタイム</param>
        public override void Draw(GameTime gameTime)
        {            
            base.Draw(gameTime);
        }
        #endregion
        
    }
}
