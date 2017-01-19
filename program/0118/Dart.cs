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
namespace Prince_rapidity_99
{
    class Dart : ModelData
    {
        #region フィールド

        #endregion

        #region コンストラクタ
        public Dart(Camera camera)
        {
            modelCamera = camera;
        }
        #endregion

        #region モデル読み込み
        public void DartLoad()
        {
            modelTransform = new Matrix[modelData.Bones.Count];
            modelData.CopyAbsoluteBoneTransformsTo(modelTransform);
            modelWorld = ModelMatrix(modelRotation, modelPosition);
        }
        #endregion

        #region モデルの描画
        public void ModelDraw(GameTime gametime)
        {
            //モデル内のメッシュをすべて描画する
            foreach (ModelMesh mesh in modelData.Meshes)
            {
                //メッシュ内のエフェクトに対してパラメータを設定する
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.PreferPerPixelLighting = true;

                    //デフォルトライティングを有効にする
                    effect.EnableDefaultLighting();

                    //必要な行列を設定する
                    effect.View = modelCamera.View;
                    effect.Projection = modelCamera.Projection;
                    effect.World = modelTransform[mesh.ParentBone.Index] * modelWorld;

                    effect.DirectionalLight0.Enabled = true;
                    effect.DirectionalLight1.Enabled = false;
                    effect.DirectionalLight2.Enabled = false;
                }

                //メッシュの描画
                mesh.Draw();
            }
            base.ModelDraw();
        }
        #endregion

    }
}
