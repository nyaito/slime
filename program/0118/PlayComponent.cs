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
    /// ��� Game �N���X����h�������A�Q�[���̃��C�� �N���X�ł��B
    /// </summary>
    public class PlayComponent: Microsoft.Xna.Framework.DrawableGameComponent
    {
        #region �t�B�[���h
        
        /// <summary>
        /// �J����
        /// </summary>
        public Camera camera;

        
        #endregion

        #region �R���X�g���N�^
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PlayComponent(Game game,GraphicsDeviceManager graphicsManager) : base(game)
        {
            
        }
        #endregion

        #region ������
        /// <summary>
        /// �������̃^�C�~���O�Ƀt���[�����[�N����Ăяo����܂�
        /// </summary>
        public override void Initialize()
        {
            // �C���v�b�g�}�l�[�W���[�̏�����
            InputManager.Initialize();

            base.Initialize();
        }

        #endregion

        #region �R���e���c�̓ǂݍ��ݏ���
        /// <summary>
        /// �R���e���c�ǂݍ��݂̃^�C�~���O�Ƀt���[�����[�N����Ăяo����܂�
        /// </summary>
        protected override void LoadContent()
        {

        }



        #endregion

        #region �R���e���c�̉������
        /// <summary>
        /// �R���e���c����̃^�C�~���O�Ƀt���[�����[�N����Ăяo����܂�
        /// </summary>
        protected override void UnloadContent()
        {
        }
        #endregion

        #region �Q�[���̍X�V����
        /// <summary>
        /// �A�b�v�f�[�g�̃^�C�~���O�Ƀt���[�����[�N����Ăяo����܂�
        /// </summary>
        /// <param name="gameTime">�Q�[���^�C��</param>
        public override void Update(GameTime gameTime)
        {
            // �C���v�b�g�}�l�[�W���[�̃A�b�v�f�[�g
            InputManager.Update();

            // �I���{�^���̃`�F�b�N
            if (InputManager.IsJustKeyDown(Keys.Escape) || InputManager.IsJustButtonDown(PlayerIndex.One, Buttons.Back))
                Game.Exit();

            // ���͂��擾����
            UpdateInput(gameTime);

            
            base.Update(gameTime);
        }

        /// <summary>
        /// �A�j���[�V�����̍X�V
        /// </summary>
        private void UpdateAnimation(GameTime gameTime, bool relativeToCurrentTime, Matrix transform)
        {
            
        }
        #endregion

        #region ���͂ɂ�鏈��
        /// <summary>
        /// ���͂ɂ�鏈��
        /// </summary>
        private void UpdateInput(GameTime gameTime)
        {


        }

        #region �Q�[���̕`�揈��
        /// <summary>
        /// �`��̃^�C�~���O�Ƀt���[�����[�N����Ăяo����܂�
        /// </summary>
        /// <param name="gameTime">�Q�[���^�C��</param>
        public override void Draw(GameTime gameTime)
        {            
            base.Draw(gameTime);
        }
        #endregion
        
    }
}
