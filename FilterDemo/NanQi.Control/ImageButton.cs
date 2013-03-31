
/* By NanQi 201209 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace NanQi.Controls
{
   [ToolboxBitmap(typeof (Button))]
   public class ImageButton : Button
   {
      #region field

      private Image _imageDown;
      private Image _imageHover;
      private Image _imageNormal;

      #endregion

      public ImageButton()
      {
         SetStyle(ControlStyles.UserPaint, true); //�Ի�
         SetStyle(ControlStyles.DoubleBuffer, true); // ˫����
         SetStyle(ControlStyles.ResizeRedraw, true); //������Сʱ�ػ�
         SetStyle(ControlStyles.AllPaintingInWmPaint, true); // ��ֹ��������.
         SetStyle(ControlStyles.OptimizedDoubleBuffer, true); // ˫����
         //this.SetStyle(ControlStyles.Opaque, true);//���Ϊ�棬�ؼ�������Ϊ��͸���������Ʊ���
         SetStyle(ControlStyles.SupportsTransparentBackColor, true); //͸��Ч��

         base.FlatStyle = FlatStyle.Flat;
         base.FlatAppearance.BorderSize = 0;
         base.FlatAppearance.MouseDownBackColor = base.FlatAppearance.MouseOverBackColor = Color.Transparent;
         BackColor = Color.Transparent;
         BackgroundImageLayout = ImageLayout.None;
         Text = string.Empty;
         base.Width = 80;
         base.Height = 30;
         base.SetStyle(ControlStyles.Selectable, false);
      }

      [Description("��갴��ʱ��ͼƬ"), Category("ImageButton")]
      public Image ImageDown
      {
         get { return _imageDown; }
         set { _imageDown = value; }
      }

      [Description("��꾭��ʱ��ͼƬ"), Category("ImageButton")]
      public Image ImageHover
      {
         get { return _imageHover; }
         set { _imageHover = value; }
      }

      [Description("��ʼ״̬�µ�ͼƬ"), Category("ImageButton")]
      public Image ImageNormal
      {
         get { return _imageNormal; }
         set
         {
            _imageNormal = value;
            BackgroundImage = _imageNormal;
         }
      }

      protected override void OnMouseDown(MouseEventArgs mevent)
      {
         BackgroundImage = _imageDown;
         base.OnMouseDown(mevent);
      }

      protected override void OnMouseEnter(EventArgs e)
      {
         BackgroundImage = _imageHover;
         base.Invalidate(false);
         base.OnMouseEnter(e);
      }

      protected override void OnMouseLeave(EventArgs e)
      {
         BackgroundImage = _imageNormal;
         base.Invalidate(false);
         base.OnMouseLeave(e);
      }

      protected override void OnMouseUp(MouseEventArgs mevent)
      {
         BackgroundImage = _imageHover;
         base.OnMouseUp(mevent);
      }
   }
}