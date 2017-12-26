using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawDiamondInWinForm
{
    public partial class Form1 : Form
    {
        List<Point> DiamondPoint = new List<Point>(); // 정마름모의 좌표

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics brush = ((Panel)sender).CreateGraphics();

            for (int i = 0; i < DiamondPoint.Count; i++)
            {
                brush.DrawEllipse(new Pen(Color.Red), DiamondPoint[i].X + panel1.Width / 2 - 1, DiamondPoint[i].Y + panel1.Height / 2 - 1, 1, 1);
            }
        }

        /// <summary>
        /// 해당 중심점을 기준으로 마름모 칸에 해당하는 외각선의 좌표를 구한다.
        /// </summary>
        /// <param name="nRange">기준으로 부터 거리</param>
        /// <param name="nCenterX">기준X</param>
        /// <param name="nCenterY">기준Y</param>
        /// <returns>외각선 좌표 리스트</returns>
        private List<Point> DiamondTile(int nRange, int nCenterX, int nCenterY)
        {
            // 외각선 좌표
            List<Point> pointRange = new List<Point>();

            // 범위가 한칸 늘어날때마다 4칸씩 추가 됩니다.
            //      1       2       3       4       5       6       7
            //      4       8       12      16      18      24      28
            // 등차 수열입니다. a + ( n - 1 )d
            // 0 + ( 1 - 1 )4 = 0
            // 0 + ( 2 - 1 )4 = 4
            // 0 + ( 3 - 1 )4 = 8


            for (int i = 0; i < nRange; ++i)
            {
                //1.왼쪽에서 위로
                pointRange.Add(new Point(nCenterX - i, nCenterY - nRange + i));

                //2.왼쪽에서 아래쪽으로
                pointRange.Add(new Point(nCenterX - nRange + i, nCenterY + i));

                //3.아래에서 오른쪽으로
                pointRange.Add(new Point(nCenterX + i, nCenterY + nRange - i));

                //4.오른쪽에서 윗쪽으로
                pointRange.Add(new Point(nCenterX + nRange - i, nCenterY - i));
            }

            return pointRange;
        }

        // 정마름모를 그립니다.
        private void button1_Click(object sender, EventArgs e)
        {

            // 정마름모의 좌표를 구한다.
            DiamondPoint = DiamondTile(70, 0, 0);         

            // 정마름모를 그린다.
            panel1.Invalidate();
        }
    }

    public class 
}
