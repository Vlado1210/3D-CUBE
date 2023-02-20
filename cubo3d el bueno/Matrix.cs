using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cubo3d_el_bueno
{
    public class Matrix
    {
        int[,] projectionMatrix;
        double[,] xRotation;
        double[,] yRotation;
        double[,] zRotation;
        public Matrix()
        {
            projectionMatrix = new int[,]
            {
                {1, 0, 0},
                {0, 1, 0}
            };
        }

        public float[] rotationX(int[] array, double angle)
        {
            float[] pts = new float[3];
            xRotation = new double[,]
            {
                {1, 0, 0},
                {0, Math.Cos(angle), -Math.Sin(angle)},
                {0, Math.Sin(angle), Math.Cos(angle)}
            };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    pts[i] += (float)xRotation[i, j] * array[j];
                }
            }

            return pts;
        }
        public float[] rotationY(int[] array, double angle)
        {
            float[] pts = new float[3];
            yRotation = new double[,]
            {
                {Math.Cos(angle), 0, Math.Sin(angle)},
                {0, 1, 0},
                {-Math.Sin(angle), 0, Math.Cos(angle)}
            };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    pts[i] += (float)yRotation[i, j] * array[j];
                }
            }

            return pts;
        }
        public float[] rotationZ(int[] array, double angle)
        {
            float[] pts = new float[3];
            zRotation = new double[,]
            {
                {Math.Cos(angle), -Math.Sin(angle), 0},
                {Math.Sin(angle), Math.Cos(angle), 0},
                {0, 0, 1}
            };

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    pts[i] += (float)zRotation[i, j] * array[j];
                }
            }

            return pts;
        }

        public float[] multiply(float[] array, int distance)
        {
            float[] pts = new float[2];
            pts[0] = array[0] / (distance - array[2]);
            pts[1] = array[1] / (distance - array[2]);
            return pts;
        }
    }
}
